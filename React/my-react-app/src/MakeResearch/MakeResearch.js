import { useNavigate } from 'react-router-dom';
import './MakeResearch.css';

export function MakeResearch (props)
{

    const navigate = useNavigate();

    return(<>
        <div className="MakeResearch-div">
            <div>
                <button className="BackButton" 
                    aria-label="Pagina sluiten" 
                    onClick={() =>  navigate('/')}>X
                </button>
                <h2 className="Titel">Titel Onderzoek</h2>
                <h4>Invoervelden met een * moeten verplicht ingevuld worden</h4>

                <h3 className="TitelResearch">Titel Onderzoek:</h3>
                <h3 className="TypeResearch">Type Onderzoek:</h3>
                <h3 className="LinkResearch">Link Onderzoek:</h3>
                <h3 className="PostcodeRange">Postcode Range:</h3>
                <h3 className="AgeCategory">Leeftijdcategorieën:</h3>
                <h3 className="TypeDisability">Type Beperking:</h3>
                <h3 className="Description">Beschrijving:</h3>
            </div>
            <div className="button-div">
                <button 
                    className="BlueButton" 
                    aria-label="MakeResearch" 
                    onClick={() =>  navigate('/')}>Maak Onderzoek
                </button>
                <button 
                    className="WhiteButton" 
                    aria-label="Cancel" 
                    onClick={() =>  navigate('/')}>Annuleren
                </button>
            </div>
        </div>
        
        </>
    );
}