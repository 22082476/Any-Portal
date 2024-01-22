import '../Account/Account.css';
import { useState } from 'react';
import { v4 as uuidv4 } from 'uuid';

export function ResgisterCompany(props) {
    const [compantId, setCompanyId] = useState(null);
    const [companyName, setCompanyName] = useState(null);
    const [email, setEmail] = useState(null);
    const [location, setLocation] = useState(null);
    const [website, setWebsite] = useState(null);
    const [description, setDescription] = useState(null);
    const [account, setAccount] = useState({userId:"", email:"", password:""});

  useEffect(() => {
    setCompanyId(uuidv4());
    setAccount({userId: compantId})
  }, []);

  const handleUpdate = () => {
    console.log(props.userId);
    const update = () => {
      fetch(`https://315d6kkf-5177.euw.devtunnels.ms/Company`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            userId: compantId,
            email: email,
            companyName: companyName,
            location: location,
            website: website,
            description: description,
            isValid: props.data.isValid
        }) // Zet de URLSearchParams om naar een string
      })
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.error('Error:', error));



      fetch('https://315d6kkf-5097.euw.devtunnels.ms/api/Login/register', {
        method: 'POST',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(account),
      })
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.error('Error:', error));
  
      props.state(false);
    };

    update();

    alert("wijzigingen opgeslagen");
    props.state(false)
  };

  return (
    <div style={{display: "flex", justifyContent: "center"}}>
      <form onSubmit={() => handleUpdate()}>
        <table className="alterCompany-table">
            <tr>
                <td>
                    <label className="input-label" htmlFor="name"><b>Bedrijfsnaam</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="name" onChange={(e) => setCompanyName(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="email"><b>Email</b></label>
                </td>
                <td>
                    <input className="inputfield" type="email" id='email' onChange={(e) => {setEmail(e.target.value), setAccount({...account, email:e.target.value})}}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="Password"><b>Password</b></label>
                </td>
                <td className="blue-text">
                    <input className="inputfield" type="password" id='Password' onChange={(e) => setAccount({...account, password: e.target.value})}></input>
                    *
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="location"><b>Locatie</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="location" onChange={(e) => setLocation(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="website"><b>Website</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="website" onChange={(e) => setWebsite(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="description"><b>Omschrijving</b></label>
                </td>
                <td>
                    <textarea className="inputfield" type="text" id="description" onChange={(e) => setDescription(e.target.value)}></textarea>
                </td>
            </tr>
        </table>
        <div className="button-div">
        <button className="WhiteButton" aria-label="Annuleren" onClick={() => props.setBool(false)}>Annuleren</button>
        <input className="BlueButton" value="Registreer" type="submit"></input>
      </div>
      </form>
    </div>
  );
}