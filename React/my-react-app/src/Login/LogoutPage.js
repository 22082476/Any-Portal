import { useNavigate } from 'react-router-dom';
import './LoginStyle.css';

export function Logout ()
{

    const navigate = useNavigate();

    return(<>
    <div className="Container">
        <div className="Login-div">
            <h2 className='TitleLogout'>Weet u zeker dat u wilt uitloggen?</h2>
            <div className='ButtonContainer'>
            <button className='LogoutButton'>Log uit</button>
            <button className='CancelButton'>Ga terug</button>
            </div>
        </div>
    </div>
    </>
    );
}