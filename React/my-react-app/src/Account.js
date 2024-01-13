import { useNavigate } from 'react-router-dom';
import { useState } from 'react';
import './Account.css';

import { AccountPanelMember } from './AccountPanelMember';
import { AccountCompany } from './AccountCompany';
import { AccountAdmin } from './AccountAdmin';

import { AlterAccountPanelMember } from './AlterAccountPanelMember';
import { AlterAccountCompany } from './AlterAccountCompany';
import { AlterAccountAdmin } from './AlterAccountAdmin';

export function Account (props)
{
    const [ isEdit, setEdit ] = useState(false);
    const [ editData, setEditData ] = useState(null);
    const navigate = useNavigate();

    return(<>
        {!isEdit && ( 
            <div className="AccountInfo-div">
                <div>
                    <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  navigate('/')}>X</button>
                    <h2>Accountgegevens</h2>
                    {props.Role === "PanelMember" ? <AccountPanelMember state={setEditData} userId=""/> : null}
                    {props.Role === "Company" ? <AccountCompany state={setEditData} userId=""/> : null}
                    {props.Role === "Administrator" ? <AccountAdmin state={setEditData} userId=""/> : null}
                </div>
                <div className="button-div">
                <button className="BlueButton" aria-label="Account wijzigen" onClick={() =>  setEdit(true)}>Account wijzigen</button>
                </div>
            </div>
        )}
        {isEdit && (
            <div className="AccountInfo-div">
                <div>
                    <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  setEdit(false)}>X</button>
                    <h2>Accountgegevens wijzigen</h2>
                    {props.Role === "PanelMember" ? <AlterAccountPanelMember state={setEdit} editData={editData}/> : null}
                    {props.Role === "Company" ? <AlterAccountCompany state={setEdit} editData={editData}/> : null}
                    {props.Role === "Administrator" ? <AlterAccountAdmin state={setEdit} editData={editData}/> : null}
                </div>
            </div>
        )}
        
        </>
    );
}