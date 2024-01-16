import React, { useState, useEffect } from 'react';
import './All_Researches_Administrator.css';
import Kruisje from './Kruisje.png';
import Vinkje from './Vinkje.png';

export function AllResearches() {
  const [researchList, setResearches] = useState(null);
  const [searchText, setSearchText] = useState('');

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5064/Research");
        const responseData = await response.json();
        setResearches(responseData);
      } catch (error) {
        console.error("Error fetching data from Researchapi:", error);
      }
    };

    fetchData();
  }, []);

  const checkSearch = (event) => {
    setSearchText(event.target.value);
  };

  const filteredResearchList = researchList
    ? researchList.filter(research =>
        research.company.toLowerCase().includes(searchText.toLowerCase())
      )
    : [];

  return (
    <div className="Researchbox-div">
      <h1 className='Researchlist'>Alle Onderzoeken</h1>
      <label htmlFor="companySearch">Zoek op bedrijfsnaam:</label>
      <input
        type="text"
        id="companySearch"
        value={searchText}
        onChange={checkSearch}
      />
      {filteredResearchList.length > 0 ? (
        <table className='Researchlist'>   {/* Makes the table*/}
        <thead className='Researchlist'> {/*Head elements table*/}
          <tr className='Researchlist'> {/* Makes a row in the head for multiple head names*/}
              <th className='Researchlist'>Titel</th>
              <th className='Researchlist'>Bedrijf</th>
              <th className='Researchlist'>Status</th>
            </tr>
          </thead>
          <tbody> {/*Table body*/}
            {filteredResearchList.map(research => (
              <tr key={research.rcode} className='Researchlist'>
                <td className='Researchlist'>{research.title}</td>
                <td className='Researchlist'>{research.company}</td>
                <td className='Researchlist'>
                  {research.active ? (
                    <img className = "ResearchPicture"
                      src={Vinkje}
                      alt="Actief"
                    />
                  ) : (
                    <img className = "ResearchPicture"
                      src={Kruisje}
                      alt="Niet Actief"
                    />
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <p>Geen overeenkomstige onderzoeken gevonden.</p>
      )}
    </div>
  );
}
