import './Admin.css';
import { useState } from 'react';
import { v4 as uuidv4 } from 'uuid';
import { useNavigate } from 'react-router-dom';

export function AddAdministrator() 
{   
    const navigate = useNavigate();
    const [administrator, setAdministrator] = useState({userId: uuidv4(), email: "", firstName: "", lastName: "", phoneNumber: "", isAdmin: false});
    const handleUpdate = () => {
        const data = {
            userId: administrator.userId,
            email: administrator.email,
            firstName: administrator.firstName,
            lastName: administrator.lastName,
            phoneNumber: administrator.phoneNumber,
            isAdmin: administrator.isAdmin
        }

        var newPassword = uuidv4();
        var password = newPassword.slice(0,6)+ "Q!";
        const adminAccount = {
            userId: administrator.userId,
            email: administrator.email,
            password: password,
        }

    const update = () => {
      fetch(`https://315d6kkf-5177.euw.devtunnels.ms/Administrator`, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(data)
      })
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.error('Error:', error));
    }
        const updateLogin = async () => {
            await fetch(`http://localhost:5091/api/Login/register`, {
              method: 'POST',
              headers: {
                  'Content-type': 'application/json'
              },
              body: JSON.stringify(adminAccount)
            })
              .then(response => response.json())
              .then(result => console.log(result))
              .catch(error => console.error('Error:', error));
          
    };

    update();
    updateLogin();
    window.alert("uw nieuwe wachtwoord is" + adminAccount.password);
    
    navigate("/Admin");
  };

  return (
    <div className='AccountInfo-div'>
        <div>
            <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  navigate("/Admin")}>X</button>
            <h1>Beheerder toevoegen</h1>
            <p className="blue-title">De invoervelden met een * zijn verplicht</p>
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
                    <button className="WhiteButton" aria-label="Wijzigen annuleren" onClick={() => navigate("/Admin")}>Wijzigen annuleren</button>
                    <input className="BlueButton" value="Wijzigen opslaan" type="submit"></input>
                </div>
            </form>
        </div>
    </div>
  );
}
