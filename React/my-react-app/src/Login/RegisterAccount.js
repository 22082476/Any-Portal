import './Register.css';
import { useState, useEffect } from 'react';
import { AgeDropDown } from '../Account/AlterAccount/AgeDropDown';
import { AvailabilityDropDown } from '../Account/AlterAccount/AvailabilityDropDown'
import { v4 as uuidv4 } from 'uuid';

export function Register(props) {

  const [panelMember, setPanelMember] = useState({userId:uuidv4(), email:"", phoneNumber:"", firstName:"", lastName:"", ageId:1, postalCode:"", preferred_contact:"", Availability:"", CaretakerId:""});
  const [account, setAccount] = useState({userId:panelMember.userId, email:"", password:""});
  const [caretaker, setCaretaker] = useState(null);
  const [deleteCare, setDeleteCare] = useState(false);

  const updateAge = (newAge) => setPanelMember({...panelMember, ageId: newAge});
  const updateAvailability = (newAvailability) => setPanelMember({...panelMember, availability: newAvailability});

  useEffect(() => {
    if (panelMember.caretakerId !== null) {
        addCareTaker(false);
      }
    }, []);
  const addCareTaker = (e) => {
    if (e) setPanelMember({ ...panelMember, caretakerId:  panelMember.userId});
    setCaretaker({
      caretakerId: panelMember.userId,
      firstName: '',
      lastName: '',
      email: '',
      phoneNumber: ' ',
    });
  };

  const del = () => {
    setPanelMember({ ...panelMember, caretakerId: null });
    setDeleteCare(true);
  };

  const handleUpdate = () => {
    const data = {
      panelMemberNew: { ...panelMember, caretakerId: deleteCare ? null : panelMember.caretakerId},
      caretaker: deleteCare ? null : caretaker,
    };

    console.log(data);
    console.log(account);
    
    fetch('http://localhost:5177/PanelMember', {
      method: 'POST',
      headers: { 'Content-type': 'application/json' },
      body: JSON.stringify(data),
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

  return (
    <div className="AccountInfo-div">
      <div>
        <button className="BackButton" aria-label="Pagina sluiten" onClick={props.onClick}>X</button>
        <h1>Register</h1>
        <div>
          <form onSubmit={handleUpdate}>
            <table>
              <tr>
                <td>
                  <label className="input-label" htmlFor="fname"><b>Voornaam</b></label>
                </td>
                <td className="blue-text">
                  <input className="inputfield" type="text" id="fname" onChange={(e) => setPanelMember({ ...panelMember, firstName: e.target.value })}></input>
                  *
                </td>
              </tr>
              <tr>
                <td>
                  <label className="input-label" htmlFor="lname"><b>Achternaam</b></label>
                </td>
                <td className="blue-text">
                  <input className="inputfield" type="text" id="lname" onChange={(e) => setPanelMember({ ...panelMember, lastName: e.target.value })}></input>
                  *
                </td>
              </tr>
              <tr>
                    <td>
                        <label className="input-label" htmlFor="email"><b>Email</b></label>
                    </td>
                    <td className="blue-text">
                        <input className="inputfield" type="email" id='email' onChange={(e) => {setPanelMember({ ...panelMember, email: e.target.value }); setAccount({...account, email: e.target.value})}}></input>
                        *
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
                        <label className="input-label" htmlFor="phonenumber"><b>Telefoonnummer</b></label>
                    </td>
                    <td>
                        <input className="inputfield" type="tel" id="phonenumber" onChange={(e) => setPanelMember({ ...panelMember, phoneNumber: e.target.value })}></input>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label className="input-label" htmlFor="postalcode"><b>Postcode</b></label>
                    </td>
                    <td className="blue-text">
                        <input className="inputfield" type="zip" id="postalcode" onChange={(e) => setPanelMember({ ...panelMember, postalCode: e.target.value })}></input>
                        *
                    </td>
                </tr>
                <tr>
                    <td>
                        <label className="input-label" htmlFor="age"><b>Leeftijdscategorie</b></label>
                    </td>
                    <td>
                        <AgeDropDown update={updateAge} ageId={1}/>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <label className="input-label" htmlFor="preferred_contact"><b>Voorkeur benadering</b></label>
                    </td>
                    <td className="blue-text">
                        <input className="inputfield" type="text" id="preferred_contact" onChange={(e) => setPanelMember({ ...panelMember, preferred_contact: e.target.value })}></input>
                        *
                    </td>
                </tr>
                <tr>
                    <td>
                        <label className="input-label" htmlFor="availability"><b>Beschikbaarheid</b></label>
                    </td>
                    <td className="blue-text">
                        <AvailabilityDropDown update={updateAvailability} availability={"Niet"}/>
                        *
                    </td>
                </tr>
            </table>

            {panelMember.caretakerId !== null ? (
              <>
                <h2>Ouder/verzorger gegevens</h2>
                <p className="blue-title">De invoervelden met een * zijn verplicht</p>
                <table>
                  <tr>
                    <td>
                      <label className="input-label" htmlFor="cfirstname"><b>Voornaam</b></label>
                    </td>
                    <td className="blue-text">
                      <input className="inputfield" type="text" id="cfirstname" onChange={(e) => setCaretaker({ ...caretaker, firstName: e.target.value })}></input>
                      *
                    </td>
                  </tr>
                  <tr>
                    <td>
                        <label className="input-label" htmlFor="clastname"><b>Achternaam</b></label>
                    </td>
                    <td className="blue-text">
                        <input className="inputfield" type="text" id="clastname" onChange={(e) => setCaretaker({ ...caretaker, lastName: e.target.value })}></input>
                        *
                    </td>
                </tr>
                <tr>
                    <td>
                        <label className="input-label" htmlFor="cemail"><b>Email</b></label>
                    </td>
                    <td className="blue-text">
                        <input className="inputfield" type="email" id="cemail" onChange={(e) => setCaretaker({ ...caretaker, email: e.target.value })}></input>
                        *
                    </td>
                </tr>
                <tr>
                    <td>
                        <label className="input-label" htmlFor="cphone"><b>Telefoonnummer</b></label>
                    </td>
                    <td>
                        <input className="inputfield" type="tel" id="cphone" onChange={(e) => setCaretaker({ ...caretaker, phoneNumber: e.target.value })}></input>
                    </td>
                </tr>
                </table>
                <div className="button-div">
                  <button className="WhiteButton secondary-button" onClick={del}>
                  Ouder/Voogd verwijderen
              </button>
            </div>
              </>
            ) : (
              <div className="button-div">
                <button className="WhiteButton secondary-button" onClick={() => addCareTaker(true)}>
                  Ouder/Voogd toevoegen
                </button>
              </div>
            )}

            <div className="button-div">
              <button className="WhiteButton secondary-button" aria-label="Annuleren" onClick={() =>props.state(false)}>
                Annuleren
              </button>
              <input className="BlueButton" value="Registreren" type="submit" />
            </div>
          </form>
        </div>
      </div>
    </div>
  )};