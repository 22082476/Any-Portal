import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Account.css';

export function Account() {
  const [userData, setUserData] = useState(null);
  const [medicalData, setMedicalData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5177/PanelMember/string");
        const responseData = await response.json();
        setUserData(responseData);

              } catch (error) {
        console.error("Error fetching data from userapi:", error);
      }

      try {
        const response2 = await fetch("http://localhost:5173/string");
        const responseData2 = await response2.json();
        setMedicalData(responseData2);

              } catch (error) {
        console.error("Error fetching data from medicalapi:", error);
      }
    };

    fetchData();
  }, []);
 
  const navigate = useNavigate();

  return (
    <div className="AccountInfo-div">
      {userData ? (
        <div>
          <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  navigate('/')}>X</button>
          <p>Voornaam: {userData.firstName}</p>
          <p>Achternaam: {userData.lastName}</p>
          <p>Email: {userData.email}</p>
          <p>Telefoonnummer Number: {userData.phoneNumber}</p>
          <p>Postcode: {userData.postalCode}</p>
          <p>AgeRange: {userData.ageId}</p>
          <p>Voorkeur benadering: {userData.preferred_contact}</p>
        </div>
        ) : (
        <p>Loading...</p>
      )}
      {medicalData ? (
        <div>
          
          <p>Beperking: {medicalData.disiblity}</p>
          <p>Type beperking: {medicalData.type} </p>
          <p>Hulpmiddel: {medicalData.tool}</p>
        
        </div>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
}
