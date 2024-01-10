import { useNavigate } from 'react-router-dom';
import './Account.css';

import { AccountPanelMember } from './AccountPanelMember';
import { AccountCompany } from './AccountCompany';
import { AccountAdmin } from './AccountAdmin';

export function Account (props)
{

    const navigate = useNavigate();

    return(
        <div className="AccountInfo-div">
            <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  navigate('/')}>X</button>
            <h2>Accountgegevens</h2>
            {props.Role === "PanelMember" ? <AccountPanelMember /> : null}
            {props.Role === "Company" ? <AccountCompany /> : null}
            {props.Role === "Administrator" ? <AccountAdmin /> : null}
        </div>
    );
}