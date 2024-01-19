import '../Account.css';
import { useState } from 'react';

export function AlterAccountAdmin(props) 
{   
  const [administrator, setAdministrator] = useState(props.data);
  const handleUpdate = () => {
    const data = {
        userId: administrator.userId,
        email: administrator.email,
        firstName: administrator.firstName,
        lastName: administrator.lastName,
        phoneNumber: administrator.phoneNumber,
        isAdmin: administrator.isAdmin
    }
    const update = () => {
      fetch(`https://315d6kkf-5177.euw.devtunnels.ms/Administrator`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(data)
      })
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.error('Error:', error));
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
                    <label className="input-label" htmlFor="fname"><b>Voornaam</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="fname" value={administrator.firstName} onChange={(e) => setAdministrator({...administrator, firstName: e.target.value})}></input>
                    *
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="lname"><b>Achternaam</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id='lname' value={administrator.lastName} onChange={(e) => setAdministrator({...administrator, lastName: e.target.value})}></input>
                    *
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="email"><b>Email</b></label>
                </td>
                <td>
                    <input className="inputfield" type="text" id="email" value={administrator.email} onChange={(e) => setAdministrator({...administrator, email: e.target.value})}></input>
                    *
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="phoneNumber"><b>Telefoonnummer</b></label>
                </td>
                <td>
                    <input className="inputfield" type="tel" id="phoneNumber" value={administrator.phoneNumber} onChange={(e) => setAdministrator({...administrator, phoneNumber: e.target.value})}></input>
                </td>
            </tr>
            <tr>
                <td>
                    <label className="input-label" htmlFor="role"><b>Rol</b></label>
                </td>
                <td>
                    <select style={{width: "66%", border: "solid 0.1rem"}} value={administrator.isAdmin} onChange={(e) => setAdministrator({...administrator, isAdmin: e.target.value === "true"})} className="inputfield" id="role" size={1}>
                        <option value={true}>Admin</option>
                        <option value={false}>Beheerder</option>
                    </select>
                    *
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
