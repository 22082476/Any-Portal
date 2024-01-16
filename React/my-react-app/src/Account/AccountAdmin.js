import { useEffect, useState } from 'react';

export function AccountAdmin(props) {
  const [userData, setUserData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5177/Administrator/" + props.userId);
        const responseData = await response.json();
        setUserData(responseData);
              } catch (error) {
        console.error("Error fetching data from userapi:", error);
        }
    };

    fetchData();
    props.data(userData);
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
