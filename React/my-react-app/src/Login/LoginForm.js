import './Register.css';
import Logo from './icon_accessibility.png';
import { useState, useEffect } from 'react';
import { AgeDropDown } from '../Account/AlterAccount/AgeDropDown';
import { AvailabilityDropDown } from '../Account/AlterAccount/AvailabilityDropDown'

export function LoginForm(props) {
    
    const [loginData, setLoginData] = useState(null);
    // Create a function to update this value
    const updateUserInformation = (userInformation) => {
    setUserInformation(userInformation)
    };

    const handleLoginSubmit = async (e) => {
        e.preventDefault();
        await Login();
        location.reload();
       
    };
        
        async function Login(){
            sessionStorage.clear();
            try {
                const response = await fetch("https://315d6kkf-5097.euw.devtunnels.ms/api/Login/login", {
                    method: "POST",
                    headers: { 'Content-type': 'application/json' },
                    body: JSON.stringify(loginData)
                });
        
                if (!response.ok) {
                    // Handle non-OK responses here
                    window.alert("Er zijn incorrecte inlog gegevens ingevoerd");
                    console.error('Error:', response.statusText);
                    return;
                }
                const data = await response.json();
                await sessionStorage.setItem("UserId", data.userId);
            } catch (error) {
                console.error('Error:', error);
            }
                try {
                    const response2 = await fetch('https://315d6kkf-5177.euw.devtunnels.ms/Role/' + sessionStorage.getItem("UserId"), {
                        method: "GET",
                        headers: { 'Content-type': 'application/text' },
                    });
            
                    if (!response2.ok) {
                        // Handle non-OK responses here
                        return;
                    }
                    const data2 = await response2.text();
                    console.log(data2);
                    sessionStorage.setItem("Role", data2);

            } catch (error2) {
                console.error('Error:', error2);
            }
    }

  return (
    // Render the login form when not logged in
    <div className="Container">
        <div className="Logo">
            <h1 className='ThreeRem-FontSize'>Welkom bij Any-Portal</h1>
            <img className='LogoImg' src={Logo} alt="Logo" />
        </div>
        <div className="Login-div">
            <form onSubmit={ handleLoginSubmit}>
                <h2>Inloggen</h2>
                <table>
                <tbody>
                    <tr>
                    <td>
                        <label className='input-label' htmlFor='email'>Email</label>
                    </td>
                    <td>
                        <input className='inputfield' id='email' type='text' onChange={(e) => setLoginData({...loginData, userName: e.target.value})} />
                    </td>
                    </tr>
                    <tr>
                    <td>
                        <label className='input-label' htmlFor='password'>Wachtwoord</label>
                    </td>
                    <td>
                        <input className='inputfield' type='password' id='password' onChange={(e) => setLoginData({...loginData, password: e.target.value})} />
                    </td>
                    </tr>
                </tbody>
                </table>
                <div className='ButtonContainer'>
                <button className='WhiteButton' aria-label="Registeren" onClick={() => props.state(true)}>Registeren</button>
                <input type='submit' className='BlueButton' value={"Inloggen"} />
                </div>
            </form>
        </div>
    </div>
  );
}
