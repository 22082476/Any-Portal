

export function AlterAccountAdmin (props)
{
    
    return (
        <div>
            
            
            <div className="button-div">
                <button className="BlueButton" aria-label="Wijzigen opslaan" onClick={() =>  props.state(false)}>Account wijzigen</button>
            </div>

        </div>
    );
}