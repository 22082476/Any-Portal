import { useNavigate } from 'react-router-dom';
import { useState } from 'react';
import './Account.css';

import { AccountPanelMember } from './AccountPanelMember';
import { AccountCompany } from './AccountCompany';
import { AccountAdmin } from './AccountAdmin';

import { AlterAccountPanelMember } from './AlterAccount/AlterAccountPanelMember';
import { AlterAccountCompany } from './AlterAccount/AlterAccountCompany';

export function Account (props)
{
    const [ isEdit, setEdit ] = useState(false);
    const [ userData, setUserData] = useState(null);
    const [ exUserData, setExUserData] = useState(null);
    const navigate = useNavigate();

    const dataUpdate = (newdata) => { setUserData(newdata);};
    const dataUpdate2 = (newdata) => { setExUserData(newdata);};

    return(<>
        {!isEdit && ( 
            <div className="AccountInfo-div">
                <div>
                    <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  navigate('/')}>X</button>
                    <h1>Accountgegevens</h1>
                    {props.Role === "PanelMember" ? <AccountPanelMember data={dataUpdate} data2={dataUpdate2} userId={props.userId}/> : null}
                    {props.Role === "Company" ? <AccountCompany data={dataUpdate} userId={props.userId}/> : null}
                    {props.Role === "Administrator" || props.Role === "Admin" ? <AccountAdmin data={dataUpdate} userId={props.userId}/> : null}
                </div>
                <div className="button-div">
                {userData != null &&   !(props.Role === "Administrator" || props.Role === "Admin") ? (   
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
                    <p>De invoervelden met een * zijn verplicht</p>
                    {console.log(userData)}
                    {props.Role === "PanelMember" ? <AlterAccountPanelMember state={setEdit} data={userData} data2={exUserData}/> : null}
                    {props.Role === "Company" ? <AlterAccountCompany state={setEdit} data={userData}/> : null}
                </div>
            </div>
        )}
        </>
    );
}