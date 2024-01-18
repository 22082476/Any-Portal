import { useEffect, useState } from 'react';

export function AccountPanelMember(props) {
  const [userData, setUserData] = useState(null);
  const [medicalData, setMedicalData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5177/PanelMember/" + props.userId);
        const responseData = await response.json();
        setUserData(responseData);
              } catch (error) {
        console.error("Error fetching data from userapi:", error);
      }

      try {
        const response2 = await fetch("http://localhost:5247/Medical/" + props.userId);
        const responseData2 = await response2.json();
        setMedicalData(responseData2);

              } catch (error) {
        console.error("Error fetching data from medicalapi:", error);
      }
    };

     fetchData();
    props.data(userData);
    props.data2(medicalData);
  });
 
 

  return (
    <>      
        {userData ? (
          <div>
            <p><b>Voornaam:</b> {userData.panelMember.firstName}</p>
            <p><b>Achternaam:</b> {userData.panelMember.lastName}</p>
            <p><b>Email:</b> {userData.panelMember.email}</p>
            <p><b>Telefoonnummer:</b> {userData.panelMember.phoneNumber ? userData.panelMember.phoneNumber : "geen telefoonnummer"}</p>
            <p><b>Postcode:</b> {userData.panelMember.postalCode}</p>
            <p><b>Leeftijdscategorie:</b> {userData.ageRange.ageStart} t/m {userData.ageRange.ageEnd} jaar</p>
            <p><b>Voorkeur benadering:</b> {userData.panelMember.preferred_contact}</p>
            <p><b>Beschikbaarheid:</b> {userData.panelMember.availability}</p>
            <br /> 
            {userData.caretaker ? (
              <div>
                <h2>Gegevens Ouder/verzorger</h2>
                <p><b>Voornaam: </b> {userData.caretaker.firstName}</p>
                <p><b>Achternaam: </b> {userData.caretaker.lastName}</p>
                <p><b>Email: </b> {userData.caretaker.email}</p>
                <p><b>Telefoonnummer: </b> {userData.caretaker.phoneNumber ? userData.caretaker.phoneNumber : "geen telefoonnummer"}</p>
              </div>
            ) : (
              <></>
            )}
        </div>
        ) : (
        <p>Loading...</p>
      )}
      <h2>Medische gegevens</h2>
      {console.log(medicalData)}
      {medicalData ? (
        <div>
          <table>
            <thead>
              <tr>
                <th>Typebeperking</th>
                <th>Naam</th>
                <th>Hulpmiddelen</th>
              </tr>
            </thead>
            <tbody>
              {medicalData.map((item) => (
                <tr key={item.disability.dcode}>
                  <td>{item.disability.type}</td>
                  <td>{item.disability.name}</td>
                  <td>
                    <ul>
                      {item.tools.length ? (<>
                        {item.tools.map((tool) => (
                          <li key={tool.id}>{tool.name}</li>
                        ))}
                      </>) : (
                        <li>Geen hulpmiddelen</li>
                      )}
                      
                    </ul>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      ) : (
        <p>Loading...</p>
      )}
    </>
  );
}