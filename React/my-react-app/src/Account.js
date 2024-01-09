import { useEffect, useState } from "react";
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
        console.error("Error fetching userdata:", error);
      }

      try {
        const response2 = await fetch("http://localhost:5170/PanelMember/string");
        const responseData2 = await response2.json();
        setMedicalData(responseData);
      } catch (error) {
        console.error("Error fetching userdata:", error);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="accountInfo-div">
        <h2>Accountgegevens</h2>
      {userData ? (
        <div>
          <p>Voornaam: {userData.firstName}</p>
          <p>Achternaam: {userData.lastName}</p>
          <p>Email: {userData.email}</p>
          <p>Telefoonnumer: {userData.phoneNumber}</p>
          <p>Leeftijdscategorie: {userData.ageId}</p>
          <p>postcode: {userData.postalCode}</p>
          <p>Voorkeur benadering: {userData.prefferd_contact}</p>
          <p>Beschikbaarheid: {}</p>          
        </div>
      ) : (
        <p>Loading...</p>
      )}
      {medicalData ? (
        <div>
          <p>Beperking: {medicalData.disiblity}</p>
          <p>Type: {medicalData.type}</p>
          <p>Hulpmiddel: {medicalData.tool}</p>         
        </div>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
}
