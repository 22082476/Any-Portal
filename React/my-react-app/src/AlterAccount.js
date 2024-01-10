
export function AlterAccount (props)
{

    const navigate = useNavigate();

    return (
        <div className="AccountInfo-div">
            <div>
                <button className="BackButton" aria-label="Pagina sluiten" onClick={() =>  navigate('/')}>X</button>
                <h2>Accountgegevens</h2>
                {props.Role === "PanelMember" ? <AlterAccountPanelMember /> : null}
                {props.Role === "Company" ? <AlterAccountCompany /> : null}
                {props.Role === "Administrator" ? <AlterAccountAdmin /> : null}
            </div>
            <div className="button-div">
            <button className="BlueButton" aria-label="Wijzigen opslaan" onClick={() =>  navigate('/AlterAccount')}>Account wijzigen</button>
            </div>
        </div>
    );
}