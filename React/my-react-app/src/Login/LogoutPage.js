import { useNavigate } from 'react-router-dom';
import './LoginStyle.css';

export function Logout ()
{

    const navigate = useNavigate();

    return(<>
    <div className="Container">
        <div className="Logout-div">
            <h2 className='TitleLogout'>Weet u zeker dat u wilt uitloggen?</h2>
            <div className='ButtonContainer'>
            <button className='LogoutButton'>Log uit</button>
            <button className='CancelButton' onClick={() =>  navigate('/')}>Terug naar Home</button>
            </div>
        </div>
    </div>
    </>
    );
}