import React, { useState, useEffect } from 'react';
import './All_Research_Updatescherm.css';

export const UpdateResearch = (props) => {
  const [researchId, setResearchId] = useState(props.id);
  const [research, setResearch] = useState({});
  const [postalCode, setPostalCode] = useState(null);
  const [allowedAgeRange, setAllowedAgeRange] = useState(null);
  const [selectedDisabilityTypes, setSelectedDisabilityTypes] = useState([]);
  const [newPostalCodeRange, setNewPostalCodeRange] = useState({from_Postalcode: '', till_Postalcode: ''});
  const [postalCodeRanges, setPostalCodeRanges] = useState([]);
  const [markedForDeletion, setMarkedForDeletion] = useState([]);


  useEffect(() => { 
    const fetchData = async () => {
      try {
        const researchResponse = await fetch(`http://localhost:5064/Research/ByResearchId/${researchId}`);
        const researchData = await researchResponse.json();
        setResearch(researchData);
  
        const postalCodeResponse = await fetch(`http://localhost:5064/Research/ByPostalCode/${researchId}`);
        const postalCodeData = await postalCodeResponse.json();
  
        if (Array.isArray(postalCodeData)) { // Controle om te checken of postalCodeData een array is
          setPostalCode(postalCodeData);
        } else if (postalCodeData.hasOwnProperty('from_Postalcode')) {
          setPostalCode([postalCodeData]);
        }
  
        const allowedAgeRangeResponse = await fetch(`http://localhost:5064/Research/ByAgeRange/${researchId}`); 
        const allowedAgeRangeData = await allowedAgeRangeResponse.json();
        setAllowedAgeRange(allowedAgeRangeData);
  
        setSelectedDisabilityTypes(researchData.disability_Type || []);
      } catch (error) {
        console.error('Error fetch data:', error);
      }
    };
  
    fetchData();
  }, [researchId]);

  const handleDisabilityChange = (type, isChecked) => { // controle om the checken of iets wel of niet aangevinkt is met een reactie om het weg te halen of te adden
    setSelectedDisabilityTypes((prevTypes) => {
      if (isChecked) {
        return [...prevTypes, type];
      } else {
        return prevTypes.filter((selectedType) => selectedType !== type);
      }
    });
  };
  
  const handleUpdate = async () => {
    try {  
      await fetch(`http://localhost:5064/Research/Research/${researchId}`, {
        method: 'PUT', 
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          ...research,
          disability_Type: selectedDisabilityTypes,
        }),
      });
  
      await fetch(`http://localhost:5064/Research/UpdateAllowed_AgeRange/${allowedAgeRange.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(allowedAgeRange),
      });
    } catch (error) {
      console.error('Error updating data:', error);
    }
  };

  const handleMarkForDeletion = (id) => {
    setMarkedForDeletion((Marked) => [...Marked, id]);
    const NieuweElement =document.getElementById(id);
    NieuweElement.innerHTML = "Verwijderd";
  };

  const handleCreatePostalCodeRange = () => {
    if (newPostalCodeRange.from_Postalcode && newPostalCodeRange.till_Postalcode) {
      setPostalCodeRanges((PostalCode) => [...PostalCode, newPostalCodeRange]);
      setNewPostalCodeRange({ from_Postalcode: '', till_Postalcode: '' });
    }
  };

  const handleRemovePostalCodeRange = (index) => {
    setPostalCodeRanges((PostalCode) => PostalCode.filter((_, i) => i !== index));
  };

  const handleSavePostalCodeRanges = async () => {
    try {
      for (const range of postalCodeRanges) {
        const response = await fetch('http://localhost:5064/Research/PostalCode_Range', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            researchId: researchId,
            from_Postalcode: range.from_Postalcode,
            till_Postalcode: range.till_Postalcode,
          }),
        });
      }

    } catch (error) {
      console.error('Error creating Postal Code Ranges:', error);
    }
  };

  const handleFinalDelete = async () => {
    try {
      for (const idToDelete of markedForDeletion) {
        await fetch(`http://localhost:5064/Research/DeletePostalcode?id=${idToDelete}`, {
          method: 'DELETE',
          headers: {
            'Content-Type': 'application/json',
          },
        });

        console.log('Postal Code marked for deletion:', idToDelete);
      }

      setMarkedForDeletion([]);
    } catch (error) {
      console.error('Error during final deletion:', error);
    }
  };

  return (
      <div>
       <div>
        <h1>Onderzoek</h1>
        {research && (
          <div>
            <label>Titel: </label>
            <input className='Textfields' type="text" value={research.title || ''} onChange={(e) => setResearch({ ...research, title: e.target.value })} />

            <label>Compensatie: </label>
            <input className='Textfields' type="number" value={research.compensation || ''} onChange={(e) => setResearch({ ...research, compensation: e.target.value })} />
        
            <label>Link onderzoek: </label>
            <input className='Textfields' type="text" value={research.link_Research || ''} onChange={(e) => setResearch({ ...research, link_Research: e.target.value })} />

            <label>Beschrijving: </label>
            <input className='Textfields' type="text" value={research.description || ''} onChange={(e) => setResearch({ ...research, description: e.target.value })} />
          </div>
        )}

        <h2>Allowed Age Range</h2>
        {allowedAgeRange && (
          <div>
            <label>Age Range ID: </label>
            <input className='Textfields' type="number" value={allowedAgeRange.allowed_AgeRangeId || ''} onChange={(e) => setAllowedAgeRange({ ...allowedAgeRange, allowed_AgeRangeId: e.target.value })} />
          </div>
        )}
      </div>

      <div>
        <h3>Maak nieuw Postcode </h3>
        <label>Van Postcode: </label>
        <input
          className='Textfields'
          type="text"
          value={newPostalCodeRange.from_Postalcode}
          onChange={(e) => setNewPostalCodeRange({ ...newPostalCodeRange, from_Postalcode: e.target.value })}
        />

        <label>Tot Postcode: </label>
        <input
          className='Textfields'
          type="text"
          value={newPostalCodeRange.till_Postalcode}
          onChange={(e) => setNewPostalCodeRange({ ...newPostalCodeRange, till_Postalcode: e.target.value })}
        />

        <button className='BlueButton' onClick={handleCreatePostalCodeRange}>Voeg postcode toe</button>
      </div>

      <div>
        <h4>Toegevoegde Postcodes</h4>
        {postalCodeRanges.length > 0 && (
          <ul>
            {postalCodeRanges.map((range, index) => (
              <li key={index}>
                {range.from_Postalcode} - {range.till_Postalcode}
                <button className='Buttongrey' onClick={() => handleRemovePostalCodeRange(index)}>Remove</button>
              </li>
            ))}
          </ul>
        )}
      </div>
      <div>
        <h5>Bestaande Postcodes</h5>
        <table className="ResearchTable">
          <thead>
            <tr>
              <th>ID</th>
              <th>Van Postcode</th>
              <th>Tot Postcode</th>
              <th>Deletefunctie</th>
            </tr>
          </thead>
          <tbody>
            {postalCode &&
              postalCode.map((code) => (
                <tr key={code.id}>
                  <td>{code.id}</td>
                  <td>{code.from_Postalcode}</td>
                  <td>{code.till_Postalcode}</td>
                  <td>
                    <button id = {code.id} className='Buttongrey'  onClick={() => handleMarkForDeletion(code.id)}>Druk om te verwijderen</button>
                  </td>
                </tr>
              ))}
          </tbody>
        </table>
      </div>

      <div className="CheckboxContainer">
        <div className="CheckboxSection">
          <label><h6>Disability Types</h6></label>
          {['Visueel', 'Fysiek', 'Cognitief', 'Auditief', 'Spraak', 'Ouderen'].map((type) => (
            <div key={type}>
              <label>
                <input
                  type="checkbox"
                  value={type}
                  checked={selectedDisabilityTypes.includes(type)}
                  onChange={(e) => handleDisabilityChange(type, e.target.checked)}
                />
                {type}
              </label>
            </div>
          ))}
        </div>

        <div className="CheckboxSection">
          <label ><h2>Actief</h2></label>
          <input type="checkbox" checked={research.active} onChange={(e) => setResearch({ ...research, active: e.target.checked })} />
        </div>
      </div>

      <div className='Buttoncontainer'>
        <button className='WhiteButton' onClick={() => {props.update(null);}} >Annuleren</button>
        <button className='BlueButton' onClick={() => { handleUpdate(); handleSavePostalCodeRanges(); handleFinalDelete();  alert("De wijzigingen zijn opgeslagen"); location.reload(); props.update(null); }}>Opslaan</button>
      </div>
    </div>
  );
};
