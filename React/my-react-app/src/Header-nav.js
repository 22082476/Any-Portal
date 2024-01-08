import img from './icon_accessibility.png';
import './Header.css'


export function HeaderNav()
{
    return (
        <div className="nav-bar">
            <img src={img} alt='Logo stichting accesibility'></img>
            <h1 className='Title'>Any-Portal</h1>
            <div className='nav'>
                <a href="/"><h2>Thuispagina</h2></a>
                <a href="Onderzoek"><h2>Onderzoek</h2></a>
                <a href="Account"><h2>Account</h2></a>
                <a href="Logout"><h2>Logout</h2></a>
            </div>
        </div>
    );
}