import { useState, useEffect} from "react";
import { HomeInfo } from "./HomeInfo";
import "./Home.css";

export function Home (props)
{
    const [researchTitle, setResearchTitle] = useState("");

    useEffect(() => {
        const ResearchTitle = (Role) => {
            switch (Role)
            {
            case "Company": setResearchTitle("Jouw actieve onderzoeken");
            break;
            case "PanelMember": setResearchTitle("Nieuwe onderzoeken");
            break;
            case "Admin" || "Administrator": setResearchTitle("Bedrijfs aanvragen");
            break;
            default: 
            setResearchTitle("Loading");
            break;
            };
        }

       ResearchTitle(props.Role); 
    }, []);
    
    
    return (
        <div className="HomeScreen-div">
            <div className="HomeScreen-div-left">
                <div className="Welcome-div">
                    <h1>Welkom {props.Name}</h1>
                </div>
                <div className="News-div">
                    <h2>Nieuws</h2>
                </div>    
            </div>
            <div className="Info-div">
                <h2> {researchTitle} </h2>
                <div>
                    <HomeInfo Role="Admin"/>
                </div>
            </div>  
        </div>
    );
}