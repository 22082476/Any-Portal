import '../Account.css';
import { useState } from 'react';

export function AlterAccountCompany(props) {
  const [companyName, setCompanyName] = useState(props.data.companyName);
  const [email, setEmail] = useState(props.data.email);
  const [location, setLocation] = useState(props.data.location);
  const [website, setWebsite] = useState(props.data.website);
  const [description, setDescription] = useState(props.data.description);

  const handleUpdate = () => {
    console.log(props.userId);
    const update = () => {
      fetch(`https://315d6kkf-5177.euw.devtunnels.ms/Company`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            userId: props.data.userId,
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
    };

    update();

    alert("wijzigingen opgeslagen");
    location.reload();
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
                    <input className="inputfield" type="text" id="name" value={companyName} onChange={(e) => setCompanyName(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="email"><b>Email</b></label>
                </td>
                <td>
                    <input className="inputfield" type="email" id='email' value={email} onChange={(e) => setEmail(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="location"><b>Locatie</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="location" value={location} onChange={(e) => setLocation(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="website"><b>Website</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="website" value={website} onChange={(e) => setWebsite(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="description"><b>Omschrijving</b></label>
                </td>
                <td>
                    <textarea className="inputfield" type="text" id="description" value={description} onChange={(e) => setDescription(e.target.value)}></textarea>
                </td>
            </tr>
        </table>
        <div className="button-div">
        <button className="WhiteButton" aria-label="Wijzigen annuleren" onClick={() => props.state(false)}>Wijzigen annuleren</button>
        <input className="BlueButton" value="Wijzigen opslaan" type="submit"></input>
      </div>
      </form>
    </div>
  );
}
