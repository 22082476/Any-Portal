import React, { useState, useEffect } from 'react';
import Kruisje from './Kruisje.png';
import Vinkje from './Vinkje.png';
import './All_Researches_Company.css';

export function Companyresearches() {
  const [researchList, setResearches] = useState(null);
  const companyId = "1";

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(`https://315d6kkf-5064.euw.devtunnels.ms/Research/ByCompanyId/${companyId}`);
        const responseData = await response.json();
        setResearches(responseData);
      } catch (error) {
        console.error("Error fetching data from Researchapi:", error);
      }
    };

    fetchData();
  }, []);

  return (
    <div className='Companybox-div'>
      <div className='Companybox-container'>
        <h1>Onderzoeken</h1>
        <button className='Createbutton' onClick={() => handleCreateResearch()}>
          Maak Onderzoek
        </button>
      </div>
      {researchList && researchList.length > 0 ? (
        <table className='Researchlist'>
          <thead className='Researchlist'>
            <tr className='Researchlist'>
              <th className='Researchlist'>Titel</th>
              <th className='Researchlist'>Actief</th>
            </tr>
          </thead>
          <tbody>
            {researchList.map(research => (
              <tr key={research.id} className='Researchlist'>
                <td className='Researchlist'>{research.title}</td>
                <td className='Researchlist'>
                  {research.active ? (
                    <img className="ResearchPicture" src={Vinkje} alt="Onderzoek is actief" />
                  ) : (
                    <img className="ResearchPicture" src={Kruisje} alt="Onderzoek is niet actief" />
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <p>Geen onderzoeken beschikbaar.</p>
      )}
    </div>
  );

  function handleCreateResearch() {
    console.log("knop gedrukt");
  }
}
