import { useNavigate } from 'react-router-dom';
import './LoginStyle.css';

export function LoginPage ()
{

    const navigate = useNavigate();

    return(<>
        <div className='coloredCornerRight'></div>
        <div className="Container">
            <div className="Logo">
                <img href = "./icon_accessibility"/>
                <h1>Any-Portal</h1>
            </div>
            <div className="Login-div">
                <h2>login</h2>
                <button>Log in</button>
            </div>
        </div>
        <div className='coloredCornerLeft'></div>
        </>
    );
}