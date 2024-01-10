import { useEffect, useState } from 'react';

export function AccountAdmin() {
  const [userData, setUserData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5177/Administrator/string12");
        const responseData = await response.json();
        setUserData(responseData);
              } catch (error) {
        console.error("Error fetching data from userapi:", error);
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
        </div>
        ) : (
        <p>Loading...</p>
      )}
    </>);
}
