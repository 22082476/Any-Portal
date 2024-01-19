import { useNavigate } from 'react-router-dom';
import './DeleteResearch.css';
import React, { useState } from 'react';

export function DeleteResearch(props) {

    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        Title: '',
    });


return (
    <div className="DeleteResearch-div">
            <button className="BackButton"
                aria-label="Pagina sluiten"
                onClick={() => navigate('/')}>X
            </button>

            <h2>Onderzoek </h2>

            <div className="Name-R-div">
                <h3 className="NameResearch">Onderzoeknaam:</h3>
            </div>

            <div className="Type-R-div">
                <h3 className="TypeResearch">Onderzoeksoort:</h3>
            </div>

            <div className="Type-D-div">
                <h3 className="TypeDisability">Type Beperking:</h3>
            </div>

            <div className="Link-R-div">
                <h3 className="LinkResearch">Link:*</h3>
            </div>

            <div className="D-div">
                <h3 className="Description">Beschrijving:</h3>
            </div>

            <div className="button-div">
                <button
                    className="WhiteButton"
                    aria-label="Delete"
                    onClick={() => navigate('/')}>Verwijder
                </button>
            </div>
    </div>
);
}