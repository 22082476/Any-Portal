import './LoginStyle.css';
import Logo from './icon_accessibility.png';
import { useState, useEffect } from "react";
import { Register } from './RegisterAccount';
import { RegisterCompany } from './RegisterCompany';

    

export function SelectRegisterType(props) {
    const [isCompany, setIsCompany] = useState(null);

    const setBool = (e) => setIsCompany(e);
  
    return (
      <>
        {isCompany == null ? (<>

            <div className="Container">
              <div className="Logo">
                  <h1 className='ThreeRem-FontSize'>Welkom bij Any-Portal</h1>
                  <img className='LogoImg' src={Logo} alt="Logo" />
              </div>
              <div className="Login-div">
                  <div className='ButtonContainer'>
                  <button className='WhiteButton' aria-label="Annulleren" onClick={() => props.state(false)}>Annuleren</button>
                  <button className='BlueButton' aria-label="Ga naar Ervaringsdeskundige registratie" onClick={() => setBool(false)}>Registreer Account</button>
                  <button className='BlueButton' aria-label="Ga naar Bedrijfs registratie" onClick={() => setBool(true)}>Registreer Bedrijf</button>
              </div>
            </div>
            </div>
            
            
            </>
        ) : (
          <>
            {isCompany ? (
              <RegisterCompany state={props.state} />   
            ) : (
              <Register state={props.state}/>
            )}
          </>
        )}
      </>
    );
  }