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
                <p>Bedrijfsnaam</p><input type="text" id='name' value={props.data.companyName}></input>
                <p>Locatie</p><input type="text" value={props.data.location}></input>
                <p>Website</p><input type="text" value={props.data.website}></input>
                <p>Omschrijving</p><input type="text" value={props.data.description}></input>
            </div>
            <div className="button-div">
                <button className="WhiteButton" aria-label="Wijzigen annuleren" onClick={() => props.state(false)}>Wijzigen annuleren</button>
                <button className="BlueButton" aria-label="Wijzigen opslaan" onClick={handleUpdate}>Wijzigen opslaan</button>
            </div>
        </div>
    );
}