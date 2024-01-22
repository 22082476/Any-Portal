import { Companyresearches } from './All_Researches_Company/All_Researches_Company';
import {AllResearches} from './All_Researches_Administrator/All_Researches_Administrator';
import { useNavigate } from 'react-router-dom';
import { PanelmemberResearches } from './PanellidResearches/PanellidResearches'



export function Research (props)
{
    const navigate = useNavigate();

    return (
        <div className="AccountInfo-div">
            <div>
                <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  navigate("/")}>X</button>
                {props.Role === "Company" && <Companyresearches companyId={props.userId} />}
                {props.Role === "PanelMember" && <PanelmemberResearches />}
                {props.Role === "Administrator" && <AllResearches />}
                {props.Role === "Admin" && <AllResearches />}
            </div>
        </div>
    );
}