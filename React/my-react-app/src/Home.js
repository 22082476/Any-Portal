export function Home (props)
{
    const ResearchTitle = ({Role}) => {
        let text = "";
        switch (Role)
        {
        case "Company": text = "Jouw actieve onderzoeken";
        break;
        case "PanelMember": text = "Nieuwe onderzoeken";
        break;
        case "Admin" || "Administrator": text = "Bedrijfs aanvragen";
        break;
        default: 
        break;
        };

        return text;
    }
    
    return (
        <div  style={{display: "flex", justifyContent:"center"}}>
            <div>
                <div>
                    <h2>Welkom {props.Name}</h2>
                </div>
                <div>
                    <h2>Nieuws</h2>
                </div>    
            </div>
            <div>
                <h2> {ResearchTitle(props.Role)}</h2>
            </div>  
        </div>
    );
}