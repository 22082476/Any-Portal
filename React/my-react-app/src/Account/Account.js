import { useNavigate } from 'react-router-dom';
import { useState } from 'react';
import './Account.css';

import { AccountPanelMember } from './AccountPanelMember';
import { AccountCompany } from './AccountCompany';
import { AccountAdmin } from './AccountAdmin';

import { AlterAccountPanelMember } from './AlterAccount/AlterAccountPanelMember';
import { AlterAccountCompany } from './AlterAccount/AlterAccountCompany';
import { AlterAccountAdmin } from './AlterAccount/AlterAccountAdmin';

export function Account (props)
{
    const [ isEdit, setEdit ] = useState(false);
    const [ userData, setUserData] = useState(null);
    const navigate = useNavigate();

    const dataUpdate = (newdata) => { setUserData(newdata);};

    return(<>
        {!isEdit && ( 
            <div className="AccountInfo-div">
                <div>
                    <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  navigate('/')}>X</button>
                    <h1>Accountgegevens</h1>
                    {props.Role === "PanelMember" ? <AccountPanelMember data={dataUpdate} userId={props.userId}/> : null}
                    {props.Role === "Company" ? <AccountCompany data={dataUpdate} userId={props.userId}/> : null}
                    {props.Role === "Administrator" ? <AccountAdmin data={dataUpdate} userId={props.userId}/> : null}
                </div>
                <div className="button-div">
                {userData ? (
                    <button className="BlueButton" aria-label="Account wijzigen" onClick={() =>  setEdit(true)}>Account wijzigen</button>
                )
                : (
                    <></>
                )}
                </div>
            </div>
        )}
        {isEdit && (
            <div className="AccountInfo-div">
                <div>
                    <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  setEdit(false)}>X</button>
                    <h1>Accountgegevens wijzigen</h1>
                    {props.Role === "PanelMember" ? <AlterAccountPanelMember state={setEdit} data={userData}/> : null}
                    {props.Role === "Company" ? <AlterAccountCompany state={setEdit} data={userData}/> : null}
                    {props.Role === "Administrator" ? <AlterAccountAdmin state={setEdit} editData={userData}/> : null}
                </div>
            </div>
        )}
        
        </>
    );
}