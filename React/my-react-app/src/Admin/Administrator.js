import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './Administrator.css';
import { Account } from '../Account/Account';

export function Administrator () {
    const navigate = useNavigate();

    const [companies, setCompanies] = useState(null);
    const [panelMembers, setPanelMembers] = useState(null);
    const [detail, setDetail] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch("https://315d6kkf-5177.euw.devtunnels.ms/Company/");
                const responseData = await response.json();
                setCompanies(responseData);
            } catch (error) {
                console.error("Error fetching data from userapi:", error);
            }

            try {
                const response = await fetch("https://315d6kkf-5177.euw.devtunnels.ms/PanelMember/");
                const responseData = await response.json();
                setPanelMembers(responseData);
            } catch (error) {
                console.error("Error fetching data from userapi:", error);
            }
        };

        fetchData();
    }, []);

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
                    <h1>Gebruikers</h1>
                    <table className="Administrator-table">
                        {companies && (
                            <>
                                {companies.map((item, index) => (
                                    <tr  key={index}>
                                        <td className="table-data-Administrators" ><b>{item.companyName}</b></td>
                                        <td className="table-data-Administrators"><b>Bedrijf</b></td>
                                        <td ><button className="detail-button"  onClick={() => setDetail({userId: item.userId, role:  "Company"})}><b>Details</b></button></td>
                                    </tr>
                                ))}
                            </>
                        )}
                        {panelMembers && (
                            <>
                                {panelMembers.map((item, index) => (
                                    <tr key={index}>
                                        <td className="table-data-Administrators"><b>{item.firstName} {item.lastName}</b></td>
                                        <td className="table-data-Administrators"><b>PanelLid</b></td>
                                        <td><button className="detail-button" onClick={() => setDetail({userId: item.userId, role:  "PanelMember"}) }><b>Details</b></button></td>
                                    </tr>
                                ))}
                            </>
                        )}
                    </table>
                </div>
            </div>
            )}
        </>    
    );
}
