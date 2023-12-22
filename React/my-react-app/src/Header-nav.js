import img from './icon_accessibility.png';
import './Header.css'

function HeaderNav()
{
    return (
        <div className="nav-bar">
            <img src={img}></img>
            <h1 className='Title'>Any-Portal</h1>
            <div className='nav'>
                <button ><h2>Thuispagina</h2></button>
                <button ><h2>Onderzoek</h2></button>
                <button ><h2>Account</h2></button>
                <button ><h2>Logout</h2></button>
            </div>
        </div>
    );
}

export default HeaderNav;