import '../Account.css';
import { useState, useEffect } from 'react';

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
    
    const [ careFirstName, setCareFirstName] = useState(null);
    const [ careLastName, setCareLastName] = useState(null);
    const [ careEmail, setCareEmail] = useState(null);
    const [ carePhoneNumber, setCarePhoneNumber] = useState(null);

    const [deleteCare, setDeleteCare ] = useState(false);

 useEffect(() =>
 {
    //   console.log(caretakerId);
    if(caretakerId !== null){
        if(props.data.caretaker !== null)
        {
            setCareFirstName(props.data.caretaker.firstName);
            setCareLastName(props.data.caretaker.lastName);
            setCareEmail(props.data.caretaker.email);
            setCarePhoneNumber(props.data.caretaker.phoneNumber);
        }else
        {
            addCareTaker(false);
        }
    }   

 }, []);


    const addCareTaker = (e) => {
        if(e)
            setCaretakerId(props.data.panelMember.userId);

        setCareFirstName("");
        setCareLastName("");
        setCareEmail("");
        setCarePhoneNumber("");
    };

    const del = () => { 
        setCaretakerId(null);
        setDeleteCare(true);
    }


  let data = {
    panelMemberNew: 
    {
        userId: props.data.panelMember.userId,
        email: email,
        phoneNumber: phoneNumber,
        firstName: firstName,
        lastName: lastName,
        ageId: ageId,
        postalCode: postalCode,
        preferred_contact: preferred_contact,
        availability: availability,
        caretakerId: deleteCare ? null : caretakerId,
    },
    caretaker: deleteCare ? null :
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
}

  const handleUpdate = () => {
    console.log(props.userId);
    const update = () => {
      fetch(`http://localhost:5177/PanelMember`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(data) // Zet de URLSearchParams om naar een string
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
                    <input className="inputfield" type="tel" id="cphone" value={carePhoneNumber} onChange={(e) => setCarePhoneNumber(e.target.value)}></input>
                </td>
            </tr>
        </table>
        <div className="button-div">
            <button className="WhiteButton" id="delete-button" onClick={() => del()}>Ouder/Voogd verwijderen</button>
        </div>
        </>
        ) :
        (
        <div className="button-div">
            <button className="WhiteButton" onClick={() => addCareTaker(true)}>Ouder/Voogd toevoegen</button>
        </div>
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
