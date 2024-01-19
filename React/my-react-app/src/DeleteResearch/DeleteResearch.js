import { useNavigate } from 'react-router-dom';
import React, { useState, useEffect } from 'react';
import './DeleteResearch.css';

export function DeleteResearch(props) {
    const navigate = useNavigate();
  
    const [constantsData, setConstantsData] = useState(null);
  
    const Title = '';

    const Compensation = '';

    const Disability_Type = [];
    const [showDisability_Type, setShowDisability_Type] = useState(false);
    const displayedDisabilities = showDisability_Type ? Disability_Type : Disability_Type.slice(0, 3);
    
    const Type_Research = '';
    
    const Link_Research = '';
    
    const Description = '';
    
    const [showFullDescription, setShowFullDescription] = useState(false);
    
    const From_Postalcode = [];
    const Till_Postalcode = [];
    const postalCodeRanges = From_Postalcode.map((from, index) => {
      const till = Till_Postalcode[index];
      return `${from} - ${till}`;
    });
    const [showAllPostalCodes, setShowAllPostalCodes] = useState(false);
    
    const Allowed_AgeRangeId = '';
  
    useEffect(() => {
      const fetchData = async () => {
        try {
          const response1 = await fetch('http://localhost:5064/Research/ByResearchId/{researchId}', {
            method: 'GET',
            headers: {
              'Content-Type': 'application/json',
            },
          });
  
          if (!response1.ok) {
            const errorMessage = await response1.text();
            console.error('Error in /Research/Research:', errorMessage);
            throw new Error('Failed to fetch research.');
          }
  
          const data = await response1.json();
          setConstantsData(data);
  
          console.log('Response Data:', data);
  
        } catch (error) {
          console.error('Error:', error);
        }
      };
  
      fetchData();
    }, []); // Empty dependency array ensures the effect runs only once after initial render  

return (
    <div className="DeleteResearch-div">
            <button className="BackButton"
                aria-label="Pagina sluiten"
                onClick={() => navigate('/')}>X
            </button>

            <h2>Gekozen Onderzoek </h2>

            <div className="Name-R-div">
                <h3 className="NameResearch">Onderzoeknaam:</h3>
                <p className="Name-R-Text">{Title}</p>
            </div>

            <div className="Com-div">
                <h3 className="Compensation">Compensatie in euro's:</h3>
                <p className="Com-Text">{Compensation}</p>
            </div>

            <div className="Type-D-div">
                <h3 className="TypeDisability">Type Beperking:</h3>
                    <ul>
                        {displayedDisabilities.map((disability, index) => (
                            <li key={index}>{disability}</li>
                        ))}
                    </ul>
                    {Disability_Type.length > 3 && (
                        <button onClick={() => setShowDisability_Type(!showDisability_Type)}>
                            {showDisability_Type ? 'Toon Minder' : 'Toon Meer'}
                        </button>
                    )}
            </div>

            <div className="Type-R-div">
                <h3 className="TypeResearch">Onderzoeksoort:</h3>
                <p className="Type-R-Text">{Type_Research}</p>
            </div>

            <div className="Link-R-div">
                <h3 className="LinkResearch">Link:</h3>
                <p className="Link-R-Text">{Link_Research}</p>
            </div>

            <div className="Des-div">
                <h3 className="Description">Beschrijving:</h3>
                <p className="Description-Text">
                    {showFullDescription ? Description : `${Description.slice(0, 100)}...`}
                </p>
                {Description.length > 100 && (
                    <button onClick={() => setShowFullDescription(!showFullDescription)}>
                        {showFullDescription ? 'Toon Minder' : 'Toon Meer'}
                    </button>
                )}
            </div>

            <div className="Pos-div">
                <h3 className="Postalcode">Postcode range's 'VAN - TOT':</h3>
                <ul>
                    {showAllPostalCodes
                        ? postalCodeRanges.map((code, index) => <li key={index}>{code}</li>)
                        : postalCodeRanges.slice(0, 3).map((code, index) => <li key={index}>{code}</li>)
                    }
                </ul>
                {postalCodeRanges.length > 3 && (
                    <button onClick={() => setShowAllPostalCodes(!showAllPostalCodes)}>
                        {showAllPostalCodes ? 'Toon Minder' : 'Toon Meer'}
                    </button>
                )}
            </div>

            <div className="Age-div">
                <h3 className="AgeRange">Leeftijdscategorie:</h3>
                <p className="Age-Text">{Allowed_AgeRangeId}</p>
            </div>

            <div className="button-div">
                <button
                    className="WhiteButton"
                    aria-label="Delete"
                    onClick={() => navigate('/')}>Verwijder
                </button>
            </div>
    </div>
);
}