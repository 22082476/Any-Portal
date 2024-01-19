import { useEffect, useState } from 'react';

export function AccountAdmin(props) 
{
  const [data, setData] = useState(null);
 
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5177/Administrator/" + props.userId);
        const responseData = await response.json();
        setData(responseData);
              } catch (error) {
        console.error("Error fetching data from userapi:", error);
        }
    };

    fetchData();
    props.data(data);
  });
 
  return (
    <>  {data ? (
          <div>
            <p><b>Voornaam:</b> {data.firstName}</p>
            <p><b>Achternaam:</b> {data.lastName}</p>
            <p><b>Email:</b> {data.email}</p>
            <p><b>Telefoonnummer:</b> {data.phoneNumber ? (data.phoneNumber) : "Geen telefoonnummer"}</p>
            <p><b>Rol:</b> {data.isAdmin ? ("Admin") : ("Beheerder")}</p>

        </div>
        ) : (
        <p>Loading...</p>
      )}
    </>);
}
