import { json, useNavigate } from 'react-router-dom';
import './LoginStyle.css';
import Logo from './icon_accessibility.png';

import {ChatBubble} from '../Chat/ChatBubble';
import App from '../App';
import { useState, useEffect } from "react";
    

    

export function LoginPage ()
{   
    const [loginData, setLoginData] = useState(null);

    const BadInput = false;
    const divStyle = { border: 'solid #131b56 0.2rem' };
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
            
            try {
                const response = await fetch("http://localhost:5097/api/Login/Login", {
                    method: "post",
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
                sessionStorage.setItem("UserId", data.userId)
            } catch (error) {
                console.error('Error:', error);
            }
        }

    return (
        <>
            {sessionStorage.getItem("UserId") !== null ? (
            // Render a different component or page when logged in
            <>
            <App /> 
            <ChatBubble />
            </>
            ) : (
            // Render the login form when not logged in
            <div className="Container">
                <div className="Logo">
                <h1 className='ThreeRem-FontSize'>Welkom bij Any-Portal</h1>
                <img className='LogoImg' src={Logo} alt="Logo" />
                </div>
                <div className="Login-div">
                <form onSubmit={ handleLoginSubmit}>
                    <h2>Login</h2>
                    <table>
                    <tbody>
                        <tr>
                        <td>
                            <label className='input-label'>Username:</label>
                        </td>
                        <td>
                            <input className='inputfield' type='text' onChange={(e) => setLoginData({...loginData, userName: e.target.value})} />
                        </td>
                        </tr>
                        <tr>
                        <td>
                            <label className='input-label'>Password:</label>
                        </td>
                        <td>
                            <input className='inputfield' type='password' onChange={(e) => setLoginData({...loginData, password: e.target.value})} />
                        </td>
                        </tr>
                    </tbody>
                    </table>
                    <div className='ButtonContainer'>
                    <button className='WhiteButton' aria-label="Close page">Register</button>
                    <input type='submit' className='BlueButton' value={"Inloggen"} />
                    </div>
                </form>
                </div>
            </div>
            )}
        </>
        );
}