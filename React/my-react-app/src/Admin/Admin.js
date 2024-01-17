import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './Admin.css';

export function Admin() {
    const navigate = useNavigate();

    const [ administrator, setAdministrators ] = useState(null);

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
    }, []);

    return (
        <>
            <div className="users-div">
                <div>
                    <button className="BackButton" aria-label="Pagina sluiten" onClick={() => navigate('/')}>X</button>
                    <h1>Beheerders</h1>
                    <table className="Admin-table">
                        <tr>
                            <th>
                                Voornaam
                            </th>
                            <th>
                                Achternaam
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
                        </tr>
                        {administrator && (
                            <>
                                {administrator.map((item, index) => (
                                    <tr  key={index}>
                                        <td className="table-data"><b>{item.firstName}</b></td>
                                        <td className="table-data"><b>{item.lastName}</b></td>
                                        <td className="table-data"><b>{item.email}</b></td>
                                        <td className="table-data"><b>{item.phoneNumber ? (item.phoneNumber) : ("Geen telefoonnummer")}</b></td>
                                        <td className="table-data"><b>{item.isAdmin ? ("Admin") : ("Beheerder")}</b></td>
                                    </tr>
                                ))}
                            </>
                        )}
                    </table>
                </div>
            </div>
        </>
    );
}
