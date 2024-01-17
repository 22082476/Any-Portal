import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './Administrator.css';

export function Administrator () {
    const navigate = useNavigate();

    const [companies, setCompanies] = useState(null);
    const [panelMembers, setPanelMembers] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch("http://localhost:5177/Company/");
                const responseData = await response.json();
                setCompanies(responseData);
            } catch (error) {
                console.error("Error fetching data from userapi:", error);
            }

            try {
                const response = await fetch("http://localhost:5177/PanelMember/");
                const responseData = await response.json();
                setPanelMembers(responseData);
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
                    <h1>Gebruikers</h1>
                    <table className="Administrator-table">
                        {companies && (
                            <>
                                {companies.map((item, index) => (
                                    <tr  key={index}>
                                        <td className="table-data-Adminstrators"><b>{item.companyName}</b></td>
                                        <td className="table-data-Adminstrators"><b>Bedrijf</b></td>
                                    </tr>
                                ))}
                            </>
                        )}
                        {panelMembers && (
                            <>
                                {panelMembers.map((item, index) => (
                                    <tr key={index}>
                                        <td className="table-data-Adminstrators"><b>{item.firstName} {item.lastName}</b> </td>
                                        <td className="table-data-Adminstrators"><b>PanelLid</b></td>
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
