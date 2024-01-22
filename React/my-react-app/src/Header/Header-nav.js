import img from './icon_accessibility.png';
import './Header.css';
import { useState, useEffect } from 'react';


export function HeaderNav()
{
    const [role, setRole] = useState("");

    useEffect(()=> {setRole(sessionStorage.getItem("Role"))}, []);

    return (
        <div className="nav-bar">
            <img src={img} alt='Logo stichting accesibility'></img>
             <p className='Title'>Any-Portal</p>
            <div className='nav'>
                <a className="nav-link" href="#/">Thuispagina</a>
                <a className="nav-link" href="#/Onderzoek">Onderzoek</a>
                {role === "Administrator" && <a className="nav-link" href="#/Administrator">Gebruikers</a>}
                {role === "Admin" && <a className="nav-link" href="#/Administrator">Gebruikers</a>}
                {role === "Admin" && <a className="nav-link" href="#/Admin">Admin</a>}
                <a className="nav-link" href="#/Account">Account</a>
                <a className="nav-link" href="#/Uitloggen">Uitloggen</a>
            </div>
        </div>
    );
}