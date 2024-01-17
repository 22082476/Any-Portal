import '../Account.css';
import { useState, useEffect } from 'react';
import { AgeDropDown } from './AgeDropDown';
import { AvailabilityDropDown } from './AvailabilityDropDown'

export function AlterAccountPanelMember(props) {
  const [panelMember, setPanelMember] = useState(props.data.panelMember);
  const [caretaker, setCaretaker] = useState(props.data.caretaker);
  const [deleteCare, setDeleteCare] = useState(false);

  const updateAge = (newAge) => setPanelMember({...panelMember, ageId: newAge});
  const updateAvailability = (newAvailability) => setPanelMember({...panelMember, availability: newAvailability});

  useEffect(() => {
    if (panelMember.caretakerId !== null) {
      if (props.data.caretaker !== null) {
        setCaretaker(props.data.caretaker);
      } else {
        addCareTaker(false);
      }
    }
  }, [panelMember.caretakerId, props.data.caretaker]);

  const addCareTaker = (e) => {
    if (e) setPanelMember({ ...panelMember, caretakerId: props.data.panelMember.userId });
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
      panelMemberNew: { ...panelMember, caretakerId: deleteCare ? null : panelMember.caretakerId },
      caretaker: deleteCare ? null : caretaker,
      panelMemberCurrent: props.data.panelMember,
    };

    console.log(data);

    fetch('http://localhost:5177/PanelMember', {
      method: 'PUT',
      headers: { 'Content-type': 'application/json' },
      body: JSON.stringify(data),
    })
      .then(response => response.json())
      .then(result => console.log(result))
      .catch(error => console.error('Error:', error));

    props.state(false);
  };

  return (
    <div>
      <form onSubmit={handleUpdate}>
        <table className="AlterAccount-table">
          <tr>
            <td>
              <label className="input-label" htmlFor="fname"><b>Voornaam</b></label>
            </td>
            <td className="blue-text">
              <input className="inputfield" type="text" id="fname" value={panelMember.firstName} onChange={(e) => setPanelMember({ ...panelMember, firstName: e.target.value })}></input>
              *
            </td>
          </tr>
          <tr>
            <td>
              <label className="input-label" htmlFor="lname"><b>Achternaam</b></label>
            </td>
            <td className="blue-text">
              <input className="inputfield" type="text" id="lname" value={panelMember.lastName} onChange={(e) => setPanelMember({ ...panelMember, lastName: e.target.value })}></input>
              *
            </td>
          </tr>
          <tr>
                <td>
                    <label className="input-label" htmlFor="email"><b>Email</b></label>
                </td>
                <td className="blue-text">
                    <input className="inputfield" type="email" id='email' value={panelMember.email} onChange={(e) => setPanelMember({ ...panelMember, email: e.target.value })}></input>
                    *
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="phonenumber"><b>Telefoonnummer</b></label>
                </td>
                <td>
                    <input className="inputfield" type="tel" id="phonenumber" value={panelMember.phoneNumber} onChange={(e) => setPanelMember({ ...panelMember, phoneNumber: e.target.value })}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="postalcode"><b>Postcode</b></label>
                </td>
                <td className="blue-text">
                    <input className="inputfield" type="zip" id="postalcode" value={panelMember.postalCode} onChange={(e) => setPanelMember({ ...panelMember, postalCode: e.target.value })}></input>
                    *
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="age"><b>Leeftijdscategorie</b></label>
                </td>
                <td>
                    <AgeDropDown update={updateAge} ageId={panelMember.ageId}/>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="preferred_contact"><b>Voorkeur benadering</b></label>
                </td>
                <td className="blue-text">
                    <input className="inputfield" type="text" id="preferred_contact" value={panelMember.preferred_contact} onChange={(e) => setPanelMember({ ...panelMember, preferred_contact: e.target.value })}></input>
                    *
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="availability"><b>Beschikbaarheid</b></label>
                </td>
                <td className="blue-text">
                    <AvailabilityDropDown update={updateAvailability} availability={panelMember.availability}/>
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
                  <input className="inputfield" type="text" id="cfirstname" value={caretaker.firstName} onChange={(e) => setCaretaker({ ...caretaker, firstName: e.target.value })}></input>
                  *
                </td>
              </tr>
              <tr>
                <td>
                    <label className="input-label" htmlFor="clastname"><b>Achternaam</b></label>
                </td>
                <td className="blue-text">
                    <input className="inputfield" type="text" id="clastname" value={caretaker.lastName} onChange={(e) => setCaretaker({ ...caretaker, lastName: e.target.value })}></input>
                    *
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="cemail"><b>Email</b></label>
                </td>
                <td className="blue-text">
                    <input className="inputfield" type="email" id="cemail" value={caretaker.email} onChange={(e) => setCaretaker({ ...caretaker, email: e.target.value })}></input>
                    *
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="cphone"><b>Telefoonnummer</b></label>
                </td>
                <td>
                    <input className="inputfield" type="tel" id="cphone" value={caretaker.phoneNumber} onChange={(e) => setCaretaker({ ...caretaker, phoneNumber: e.target.value })}></input>
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
          <button className="WhiteButton secondary-button" aria-label="Wijzigen annuleren" onClick={() => props.state(false)}>
            Wijzigen annuleren
          </button>
          <input className="BlueButton" value="Wijzigen opslaan" type="submit" />
        </div>
      </form>
    </div>
  )};