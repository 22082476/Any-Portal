import React, { useState, useEffect } from 'react';
import Kruisje from './Kruisje.png';
import Vinkje from './Vinkje.png';
import { UpdateResearch } from '../All_Researches_Updatescherm/All_Research_Updatescherm';
import './All_Researches_Company.css';
import { Navigate, useNavigate } from 'react-router-dom';



export function Companyresearches(props) {

  const [researchList, setResearches] = useState(null);
  const [editAccountId, setEditAccountId] = useState(null);

  const changeScreen = (change) => {setEditAccountId(change)}

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(`https://315d6kkf-5064.euw.devtunnels.ms/Research/ByCompanyId/${props.companyId}`);

        const responseData = await response.json();
        setResearches(responseData);
      } catch (error) {
        console.error("Error fetching data from Researchapi:", error);
      }
    };

    fetchData();
  });

  const navigate = useNavigate();

  return (
    <>
      {editAccountId === null ? (
        <div>
          <div>
            <h1>Onderzoeken</h1>
            <button className='Createbutton' onClick={() => navigate("/MaakOnderzoek")}>
              Maak Onderzoek
            </button>
          </div>
          {researchList && researchList.length > 0 ? (
            <table className='Researchlist'>
              <thead className='Researchlist'>
                <tr className='Researchlist'>
                  <th className='Researchlist'>Titel</th>
                  <th className='Researchlist'>Actief</th>
                  <th className='Researchlist'> Update</th>
                </tr>
              </thead>
              <tbody>
                {researchList.map(research => (
                  <tr key={research.id} className='Researchlist'>
                    <td className='Researchlist'>
                    {research.title}
                    </td>
                    <td className='Researchlist'>
                      {research.active ? (
                        <img className="ResearchPicture" src={Vinkje} alt="Onderzoek is actief" />
                      ) : (
                        <img className="ResearchPicture" src={Kruisje} alt="Onderzoek is niet actief" />
                      )}
                    </td>
                    <td>
                      {research.active ? (
                    <button className="Buttongrey">
                    kan onderzoek niet wijzigen  
                    </button>) :
                      (
                         <button className="Buttonblue" onClick={() => setEditAccountId(research.rcode)}>
                         wijzigen onderzoek  
                         </button>)
                      }
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          ) : (
            <p>Geen onderzoeken beschikbaar.</p>
          )}
        </div>
        ) : (<UpdateResearch id={editAccountId} update={changeScreen}/>)}
    </>
  );
}
