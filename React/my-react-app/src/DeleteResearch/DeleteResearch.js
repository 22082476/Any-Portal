import { useNavigate } from 'react-router-dom';
import React, { useState, useEffect } from 'react';
import './DeleteResearch.css';

export function DeleteResearch(props) {

    const navigate = useNavigate();

    const [constantsData, setConstantsData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [deleteStatus, setDeleteStatus] = useState(null);
    const [showConfirmationDialog, setShowConfirmationDialog] = useState(false);

    const researchId = 4;

    const [showDisability_Type, setShowDisability_Type] = useState(false);
    const displayedDisabilities = showDisability_Type ? constantsData?.disability_Type : constantsData?.disability_Type?.slice(0, 3);
    
    const [showFullDescription, setShowFullDescription] = useState(false);
    
    const From_Postalcode = []; //Test array but its supposed to be string
    const Till_Postalcode = []; //Test array but its supposed to be string
    const postalCodeRanges = From_Postalcode.map((from, index) => {
      const till = Till_Postalcode[index];
      return `${from} - ${till}`;
    });
    const [showAllPostalCodes, setShowAllPostalCodes] = useState(false);
    
    const Allowed_AgeRange = 0;
  
    useEffect(() => {
      const fetchData = async () => {
        try {
          const response1 = await fetch(`http://localhost:5064/Research/ByResearchId/${researchId}`, {
            method: 'GET',
            headers: {
              'Content-Type': 'application/json',
            },
          });
  
          if (!response1.ok) {
            const errorMessage = await response1.text();
            console.error('Error in /Research/ByResearchId/${researchId}:', errorMessage);
            throw new Error('Failed to fetch research.');
          }
  
          const data = await response1.json();
          setConstantsData(data);
          setLoading(false); 
  
          console.log('Response Data:', data);
  
        } catch (error) {
          console.error('Error:', error);
          setLoading(false);
        }
      };
  
      fetchData();
    }, []);

    useEffect(() => {
        if (deleteStatus === 'success') {
            navigate('/');
        }
    }, [deleteStatus, navigate]);

    const handleDelete = async () => {
        try {
            const response2 = await fetch(`http://localhost:5064/Research/Research/${researchId}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (!response2.ok) {
                const errorMessage = await response2.text();
                console.error('Error in DELETE request:', errorMessage);
                throw new Error('Failed to delete research.');
            }

            setDeleteStatus('success');
        } catch (error) {
            console.error('Error:', error);
            setDeleteStatus('error');
        }
    };

    const showConfirmation = () => {
        setShowConfirmationDialog(true);
    };

    const confirmDelete = () => {
        handleDelete();
        setShowConfirmationDialog(false);
    };

    const cancelDelete = () => {
        setShowConfirmationDialog(false);
    };

    if (loading) {
        return <div>Laden... Een ogenblik geduld.</div>;
    }

    if (!constantsData) {
        return <div>Er is een fout opgetreden bij het ophalen van de gegevens.</div>;
    }

return (
    <div className="DeleteResearch-div">
            <button className="BackButton"
                aria-label="Pagina sluiten"
                onClick={() => navigate('/')}>X
            </button>

            <h2>Gekozen Onderzoek </h2>

            <div className="Name-R-div">
                <label className="NameResearch">Onderzoeknaam:</label>
                <p className="Name-R-Text">{constantsData.title}</p>
            </div>

            <div className="Com-div">
                <label className="Compensation">Compensatie in euro's:</label>
                <p className="Com-Text">{constantsData.compensation}</p>
            </div>

            <div className="Type-D-div">
                <label className="TypeDisability">Type Beperking:</label>
                    <ul>
                    {displayedDisabilities !== null && displayedDisabilities.map((disability_Type, index) => (
                        <li key={index}>{disability_Type}</li>
                    ))}

                    </ul>
                    {constantsData.disability_Type.length > 3 && (
                        <button onClick={() => setShowDisability_Type(!showDisability_Type)}>
                            {showDisability_Type ? 'Toon Minder' : 'Toon Meer'}
                        </button>
                    )}
            </div>

            <div className="Type-R-div">
                <label className="TypeResearch">Onderzoeksoort:</label>
                <p className="Type-R-Text">{constantsData.type_Research}</p>
            </div>

            <div className="Link-R-div">
                <label className="LinkResearch">Link:</label>
                <p className="Link-R-Text">{constantsData.link_Research}</p>
            </div>

            <div className="Des-div">
                <label className="Description">Beschrijving:</label>
                <p className="Description-Text">
                    {showFullDescription ? constantsData.description : `${constantsData.description.slice(0, 100)}...`}
                </p>
                {constantsData.description.length > 100 && (
                    <div className="Des-Button">
                        <button onClick={() => setShowFullDescription(!showFullDescription)}>
                            {showFullDescription ? 'Toon Minder' : 'Toon Meer'}
                        </button>
                    </div>
                )}
            </div>

            <div className="Pos-div">
                <label className="Postalcode">Postcode range's 'VAN - TOT':</label>
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
                <label className="AgeRange">Leeftijdscategorie:</label>
                <p className="Age-Text">{constantsData.allowed_AgeRangeId}</p>
            </div>

            <div className="button-div">
                <button
                    className="WhiteButton"
                    aria-label="Delete"
                    onClick={showConfirmation}>
                    Verwijder
                </button>
            </div>

            {showConfirmationDialog && (
                <div className="confirmation-dialog">
                    <p>Weet u zeker dat u wilt verwijderen?</p>
                    <button onClick={confirmDelete}>Bevestigen</button>
                    <button onClick={cancelDelete}>Annuleren</button>
                </div>
            )}
        </div>
);
}