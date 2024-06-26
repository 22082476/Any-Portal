import { useNavigate } from 'react-router-dom';
import './LoginStyle.css';

export function Logout ()
{

    const navigate = useNavigate();

    async function Logout(){
            
        try {
            const response = await fetch("https://315d6kkf-5097.euw.devtunnels.ms/api/Login/Logout", {
                method: "post",
                headers: { 'Content-type': 'application/json'},
            });
    
            if (!response.ok) {
                // Handle non-OK responses here
                console.error('Error:', response.statusText);
                return;
            }

            if (response.ok) {
                // Handle OK responses here
                console.error('Success:', response.statusText);
            }

            sessionStorage.removeItem("UserId");
            sessionStorage.removeItem("Role");
            sessionStorage.clear();
        } catch (error) {
            console.error('Error:', error);
        }
    }

    return(<>
    <div className="Container">
        <div className="Logout-div">
            <h2 className='TitleLogout'>Weet u zeker dat u wilt uitloggen?</h2>
            <div className='ButtonContainer'>
            <button className='BlueButton' onClick={() =>  navigate('/')}>Annuleren</button>
            <button className='WhiteButton'onClick={async () =>  { await Logout();  navigate('/'); location.reload()}}>Uitloggen</button>
            </div>
        </div>
    </div>
    </>
    );
}