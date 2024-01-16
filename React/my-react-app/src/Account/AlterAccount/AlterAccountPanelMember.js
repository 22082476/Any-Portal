import '../Account.css';
import { useState } from 'react';

export function AlterAccountPanelMember(props) {
  const [ firstName, setFirstName ] = useState(props.data.panelMember.firstName);
  const [ lastName, setLastName ] = useState(props.data.panelMember.lastName);
  const [ email, setEmail ] = useState(props.data.panelMember.email);
  const [ phoneNumber, setPhoneNumber] = useState(props.data.panelMember.phoneNumber);
  const [ postalCode, setPostalCode] = useState(props.data.panelMember.postalcode);
  const [ availability, setAvailablity] = useState(props.data.panelMember.availability);
  const [ preferred_contact, setPreferred_contact] = useState(props.data.panelMember.preferred_contact);
  const [ ageId, setAgeId] = useState(props.data.panelMember.ageId);

  const [ caretakerId, setCaretakerId] = useState(props.data.panelMember.caretakerId);
  const [ careFirstName, setCareFirstName] = useState(props.data.caretaker.firstName);
  const [ careLastName, setCareLastName] = useState(props.data.caretaker.lastName);
  const [ careEmail, setCareEmail] = useState(props.data.caretaker.email);
  const [ carePhoneNumber, setCarePhoheNumber] = useState(props.data.caretaker.phoneNumber);

  

  const handleUpdate = () => {
    console.log(props.userId);
    const update = () => {
      fetch(`http://localhost:5177/PanelMember`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            panelMemberNew: 
            {
                userId: props.data.userId,
                email: email,
                phoneNumber: phoneNumber,
                firstName: firstName,
                lastName: lastName,
                ageId: ageId,
                postalCode: postalCode,
                preferred_contact: preferred_contact,
                availability: availability,
                caretakerId: caretakerId,
            },
            cartaker:
            {
                caretakerId: caretakerId,
                firstName: careFirstName,
                lastName: careLastName,
                email: careEmail,
                phoneNumber: carePhoneNumber

            },
            panelMemberCurrent:
            {
                userId: props.data.panelMember.userId,
                email: props.data.panelMember.email,
                phoneNumber: props.data.panelMember.phoneNumber,
                firstName: props.data.panelMember.firstName,
                lastName: props.data.lastName,
                ageId: props.data.panelMember.ageId,
                postalCode: props.data.panelMember.postalCode,
                preferred_contact: props.data.panelMember.preferred_contact,
                availability: props.data.panelMember.availability,
                caretakerId: props.data.panelMember.caretakerId,
            }
        }) // Zet de URLSearchParams om naar een string
      })
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.error('Error:', error));
    };

    update();
    props.state(false)
  };

  return (
    <div>
      <form onSubmit={() => handleUpdate()}>
        <table>
            <tr>
                <td>
                    <label className="input-label" htmlFor="fname"><b>Voornaam</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="fname" value={firstName} onChange={(e) => setFirstName(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="lname"><b>Achternaam</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="lname" value={lastName} onChange={(e) => setLastName(e.target.value)}></input>
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
                    <label className="input-label" htmlFor="phonenumber"><b>Telefoonnummer</b></label>
                </td>
                <td>
                    <input className="inputfield" type="tel" id="phonenumber" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="postalcode"><b>Postcode</b></label>
                </td>
                <td>
                    <input className="inputfield" type="zip" id="postalcode" value={postalCode} onChange={(e) => setPostalCode(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="age"><b>Leeftijdscategorie</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="age" value={ageId} onChange={(e) => setAgeId(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="preferred_contact"><b>Voorkeur benadering</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="preferred_contact" value={preferred_contact} onChange={(e) => setPreferred_contact(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="description"><b>Beschikbaarheid</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="description" value={availability} onChange={(e) => setAvailablity(e.target.value)}></input>
                </td>
            </tr> 
        </table>
        { caretakerId !== null ?
        (
        <>
        <h2>Ouder/verzorger gegevens</h2>
        <table>
            <tr>
                <td>
                    <label className="input-label" htmlFor="cfirstname"><b>Voornaam</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="cfirstname" value={careFirstName} onChange={(e) => setCareFirstName(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="clastname"><b>Achternaam</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="clastname" value={careLastName} onChange={(e) => setCareLastName(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="cemail"><b>Email</b></label>
                </td>
                <td>
                    <input className="inputfield" type="email" id="cemail" value={careEmail} onChange={(e) => setCareEmail(e.target.value)}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="cphone"><b>Telefoonnummer</b></label>
                </td>
                <td>
                    <input className="inputfield" type="tel" id="cphone" value={carePhoneNumber} onChange={(e) => setPhoneNumber(e.target.value)}></input>
                </td>
            </tr>
        </table>
        </>
        ) :
        (
        <></>
        )
        }
        <div className="button-div">
        <button className="WhiteButton" aria-label="Wijzigen annuleren" onClick={() => props.state(false)}>Wijzigen annuleren</button>
        <input className="BlueButton" value="Wijzigen opslaan" type="submit"></input>
      </div>
      </form>
    </div>
  );
}
