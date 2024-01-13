import './Account.css';

export function AlterAccountCompany (props)
{
    const handleUpdate = ()=> 
    {
        props.state(false)
    };

    return (
        <div>
            <div>
                <p>Bedrijfsnaam</p><input value={props.companyName}></input>
                <p>Locatie</p><input></input>
                <p>Website</p>
                <p>Omschrijving</p>
            </div>
            <div className="button-div">
                <button className="WhiteButton" aria-label="Wijzigen annuleren" onClick={() => props.state(false)}>Wijzigen annuleren</button>
                <button className="BlueButton" aria-label="Wijzigen opslaan" onClick={handleUpdate}>Wijzigen opslaan</button>
            </div>
        </div>
    );
}