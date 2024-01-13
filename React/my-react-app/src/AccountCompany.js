import { useEffect, useState } from 'react';

export function AccountCompany(props) {
  const [userData, setUserData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5177/Company/" + props.userId);
        const responseData = await response.json();
        setUserData(responseData);
              } catch (error) {
        console.error("Error fetching data from userapi:", error);
        }

        props.state(userData);
    };

    fetchData();
  }, []);
 
  return (
    <>
        {userData ? (
          <div>
            <p><b>Bedrijfsnaam:</b> {userData.companyName}</p>
            <p><b>locatie:</b> {userData.location}</p>
            <p><b>Email:</b> {userData.email}</p>
            <p><b>Omschrijving:</b> {userData.description}</p>
            <p><b>Website: </b> <a href={userData.website}>{userData.website}</a></p>
            <p><b>Gevalideerd: </b>{userData.isValid ? "gevalideerd" : "niet gevalideerd"}</p>
        </div>
        ) : (
        <p>Loading...</p>
      )}
    </>);
}
