import img from './icon_accessibility.png';
import './Header.css'


export function HeaderNav()
{
    return (
        <div className="nav-bar">
            <img src={img} alt='Logo stichting accesibility'></img>
             <p className='Title'>Any-Portal</p>
            <div className='nav'>
                <a className="nav-link" href="#/">Thuispagina</a>
                <a className="nav-link" href="#/Onderzoek">Onderzoek</a>
                <a className="nav-link" href="#/Account">Account</a>
                <a className="nav-link" href="#/Logout">Logout</a>
            </div>
        </div>
    );
}