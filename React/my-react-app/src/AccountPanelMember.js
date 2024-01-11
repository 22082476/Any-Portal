import { useEffect, useState } from 'react';

export function AccountPanelMember() {
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
 
 

  return (
    <>      
        {userData ? (
          <div>
            <p><b>Voornaam:</b> {userData.firstName}</p>
            <p><b>Achternaam:</b> {userData.lastName}</p>
            <p><b>Email:</b> {userData.email}</p>
            <p><b>Telefoonnummer:</b> {userData.phoneNumber ? userData.phoneNumber : "geen telefoonnummer"}</p>
            <p><b>Postcode:</b> {userData.postalCode}</p>
            <p><b>AgeRange:</b> {userData.ageId}</p>
            <p><b>Voorkeur benadering:</b> {userData.preferred_contact}</p>
            <p><b>Beschikbaarheid:</b> {userData.availability}</p>
            <br /> 
            {userData.caretaker ? (
              <div>
                <p><b>Voornaam ouder/verzorger: </b> {userData.caretaker.firstName}</p>
                <p><b>Achternaam ouder/verzorger: </b> {userData.caretaker.lastName}</p>
                <p><b>Email ouder/verzorger: </b> {userData.caretaker.email}</p>
                <p><b>Telefoonnummer ouder/verzorger: </b> {userData.caretaker.phoneNumber ? userData.phoneNumber : "geen telefoonnummer"}</p>
              </div>
            ) : (
              <></>
            )}
        </div>
        ) : (
        <p>Loading...</p>
      )}
    
      {medicalData ? (
        <div>
          <p><b>Beperking:</b> {medicalData.disiblity}</p>
          <p><b>Type:</b> {medicalData.type}</p>
          <p><b>Hulpmiddel:</b> {medicalData.tool}</p>         

        </div>
      ) : (
        <p>Loading...</p>
      )}
    </>);
}
