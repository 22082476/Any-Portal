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
    const [ isDelete, setDelete] = useState(false);
    const [ userData, setUserData] = useState(null);
    const [ exUserData, setExUserData] = useState(null);
    const navigate = useNavigate();

    const dataUpdate = (newdata) => { setUserData(newdata);};
    const dataUpdate2 = (newdata) => { setExUserData(newdata);};

    const deleteAccount = async () => 
    { 
        const response = await fetch("http://localhost:5177/" + props.Role + "/" + props.userId, 
        {
            method: "DELETE"
        });
        
        //Add delete medical stuff

        if(response.ok)
        {
            sessionStorage.removeItem("UserId");
            navigate("/");
        }
    };

    return(<>
        {!isEdit && ( 
            <>
            {!isDelete && 
            (
                <div className="AccountInfo-div">
                <div>
                    <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  navigate('/')}>X</button>
                    <h1>Accountgegevens</h1>
                    {props.Role === "PanelMember" ? <AccountPanelMember data={dataUpdate} data2={dataUpdate2} userId={props.userId}/> : null}
                    {props.Role === "Company" ? <AccountCompany data={dataUpdate} userId={props.userId}/> : null}
                    {props.Role === "Administrator" || props.Role === "Admin" ? <AccountAdmin data={dataUpdate} userId={props.userId}/> : null}
                </div>
                <div className="button-div">
                {userData != null &&   !(props.Role === "Administrator" || props.Role === "Admin") ? (   <>
                    <button className="WhiteButton secondary-button" style={{boxShadow: 'none'}} aria-label="Account verwijderen" onClick={() =>  setDelete(true)}>Account verwijderen</button>  
                    <button className="BlueButton" aria-label="Account wijzigen" onClick={() =>  setEdit(true)}>Account wijzigen</button>  
                    </>      
                )
                : (
                    <></>
                )}
                </div>
            </div>
            )}
            </>
        )}
        {isEdit && (
            <div className="AccountInfo-div">
                <div>
                    <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  setEdit(false)}>X</button>
                    <h1>Accountgegevens wijzigen</h1>
                    <p className="blue-title">De invoervelden met een * zijn verplicht</p>
                    {console.log(userData)}
                    {props.Role === "PanelMember" ? <AlterAccountPanelMember state={setEdit} data={userData} data2={exUserData}/> : null}
                    {props.Role === "Company" ? <AlterAccountCompany state={setEdit} data={userData}/> : null}
                </div>
            </div>
        )}
        {isDelete && (
            <div className="AccountInfo-div">
                <div>
                    <button className="BackButton" id="deleteButton" aria-label="Pagina sluiten" onClick={() =>  setDelete(false)}>X</button>
                    <h1>Weet u zeker dat u uw account wilt verwijderen?</h1>
                    <div className="button-div">
                        <button className="WhiteButton secondary-button" style={{boxShadow: 'none'}} aria-label="Account verwijderen" onClick={() =>  deleteAccount()}>Account verwijderen</button>  
                        <button className="BlueButton" aria-label="Annuleren" onClick={() =>  setDelete(false)}>Annuleren</button>  
                    </div>
                </div>
            </div>
        )}
        </>
    );
}