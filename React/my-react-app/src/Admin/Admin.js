import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './Admin.css';
import { Account } from '../Account/Account';

export function Admin() {
    const navigate = useNavigate();

    const [ administrator, setAdministrators ] = useState(null);
    const [ detail, setDetail ] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch("http://localhost:5177/Administrator/");
                const responseData = await response.json();
                setAdministrators(responseData);
            } catch (error) {
                console.error("Error fetching data from userapi:", error);
            }

        };

        fetchData();
    });

    const isVisibile = (e) => setDetail(e);

    return (
        <>
            {detail ? (<>
                {<Account userId={detail.userId} Role={detail.role} visability={isVisibile} />}
                </>
            ) 
            : 
            (
            <div className="users-div">
                <div>
                    <button className="BackButton" aria-label="Pagina sluiten" onClick={() => navigate('/')}>X</button>
                    <h1>Beheerders</h1>
                    <table className="Admin-table">
                        <tr>
                            <th>
                                Naam
                            </th>
                            <th>
                                Email
                            </th>
                            <th>
                                Telefoon
                            </th>
                            <th>
                                Rol
                            </th>
                            <th>
                                Details
                            </th>
                        </tr>
                        {administrator && (
                            <>
                                {administrator.map((item, index) => (
                                    <tr  key={index}>
                                        <td className="table-data"><b>{item.firstName} {item.lastName}</b></td>
                                        <td className="table-data"><b><a href={'mailto:' + item.email }>{item.email}</a></b></td>
                                        <td className="table-data-phone"><b>{item.phoneNumber ? (<a href={'tel:' + item.phoneNumber}>{item.phoneNumber}</a>) : ("Geen telefoonnummer")}</b></td>
                                        <td className="table-data"><b>{item.isAdmin ? ("Admin") : ("Beheerder")}</b></td>
                                        <td ><button className="detail-button"  onClick={() => setDetail({userId: item.userId, role: "Administrator"})}><b>Details</b></button></td>
                                    </tr>
                                ))}
                            </>
                        )}
                    </table>
                </div>
                <div className='button-div'>
                    <button className="BlueButton" aria-label="Account wijzigen" onClick={() =>  navigate("/Admin/Toevoegen")}>Beheerder toevoegen</button>  
                </div>
            </div>
            )}
        </>
    );
}
