import { json, useNavigate } from 'react-router-dom';
import './LoginStyle.css';
import Logo from './icon_accessibility.png';

import { useState, useEffect } from "react";
    

    

export function LoginPage ()
{   
    const [LoginData, SetLoginData] = useState(null);
    
        function Login(){
            console.log(LoginData)
                const response = fetch("http://localhost:5097/api/Login/Login"
            , {method:"post"
            ,headers:{ 'Content-type': 'application/json' }
            , body: JSON.stringify(LoginData)    
            })
            .then(response => response.json())
            .then(result => console.log(result))
            .catch(error => console.error('Error:', error));

        }


    return(<>
        
        <div className="Container">
            <div className="Logo">
                <h1 className='ThreeRem-FontSize'>Welkom bij Any-Portal</h1>
                <img className='LogoImg' src = {Logo}/>
            </div>
            <div className="Login-div">
                <form onSubmit={Login}>
                    <h2>login</h2>
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <label className='input-label'>GebruikersNaam:</label>
                            </td>
                            <td>
                                <input className='inputfield' type='String' onChange={(e) => SetLoginData({...LoginData, userName:e.target.value})}></input>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label className='input-label'>WachtWoord:</label>
                            </td>
                            <td>
                                <input className='inputfield' type='Password' onChange={(e) => SetLoginData({...LoginData, password:e.target.value})}></input>
                                <p className='TenPx-FontSize'>Een wachtwoord moet minimaal een hoofdletter, een getal en een speciaal character hebben</p>
                            </td>
                        
                            
                        </tr>
                    </tbody>
                </table>
                <input type='submit' className='BlueButton' value={"Log in"}/>
                <button className='WhiteButton' aria-label="Pagina sluiten" onClick={() =>  navigate('/')}>Register</button>
                </form>
                
            </div>
        </div>
        <div className='coloredCornerRight'></div>
        <div className='coloredCornerLeft'></div>
        </>
    );
}