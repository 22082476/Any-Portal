import { useNavigate } from 'react-router-dom';
import './MakeResearch.css';
import React, { useState } from 'react';

export function MakeResearch(props) {

    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        titelResearch: '',
        typeResearch: '',
        linkResearch: '',
        description: '',
        compensation: '',
        postcodeRange: '',
        ageCategory: '',
        typeDisability: '',
    });

    const handleSubmit = async () => {
        try {
            const response = await fetch('http://localhost:5064/api/CreateResearch', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),
            });

            if (!response.ok) {
                throw new Error('Netwerkreactie was niet in orde');
            }

            const data = await response.json();

            console.log(data);

            navigate('/');

        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <div className="MakeResearch-div">
            <div>
                <button className="BackButton"
                    aria-label="Pagina sluiten"
                    onClick={() => navigate('/')}>X
                </button>
                <h2 className="Title">Titel Onderzoek</h2>
                <h4>Invoervelden met een * moeten verplicht ingevuld worden</h4>

                <h3 className="TitleResearch">Titel Onderzoek:*</h3>
                <input
                    type="text"
                    className="TitleR-TextField"
                    value={formData.titelResearch}
                    onChange={(e) => setFormData({ ...formData, titelResearch: e.target.value })}
                />

                <h3 className="TypeResearch">Type Onderzoek:*</h3>
                <input
                    type="text"
                    className="TypeR-TextField"
                    value={formData.typeResearch}
                    onChange={(e) => setFormData({ ...formData, typeResearch: e.target.value })}
                />

                <h3 className="LinkResearch">Link Onderzoek:*</h3>
                <input
                    type="text"
                    className="LinkR-TextField"
                    value={formData.linkResearch}
                    onChange={(e) => setFormData({ ...formData, linkResearch: e.target.value })}
                />

                <h3 className="Compensation">Compensatie:*</h3>
                <input
                    type="text"
                    className="C-TextField"
                    value={formData.compensation}
                    onChange={(e) => setFormData({ ...formData, compensation: e.target.value })}
                />

                <h3 className="PostcodeRange">Postcode Range:*</h3>
                <select
                    className="PostcodeRange-Select"
                    value={formData.postcodeRange}
                    onChange={(e) => setFormData({ ...formData, postcodeRange: e.target.value })}
                >
                    <option value="">Selecteer Postcode Range</option>
                    <option value="range1">2189 t/m 2298 AV</option>
                    <option value="range2">Range 2</option>
                </select>

                <h3 className="AgeCategory">Leeftijdcategorieën:*</h3>
                <select
                    className="AgeCategory-Select"
                    value={formData.ageCategory}
                    onChange={(e) => setFormData({ ...formData, ageCategory: e.target.value })}
                >
                    <option value="">Selecteer Leeftijdscategorie</option>
                    <option value="range1">4 t/m 17 jaar</option>
                    <option value="range2">18 t/m 30 jaar</option>
                </select>

                <h3 className="TypeDisability">Type Beperking:</h3>
                <select
                    className="TypeDisability-Select"
                    value={formData.typeDisability}
                    onChange={(e) => setFormData({ ...formData, typeDisability: e.target.value })}
                >
                    <option value="">Selecteer Type Beperking</option>
                    <option value="range1">Visueel</option>
                    <option value="range2">Fysiek</option>
                </select>

                <h3 className="Description">Beschrijving:</h3>
                <input
                    type="text"
                    className="D-TextField"
                    value={formData.description}
                    onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                />
            </div>
            <div className="button-div">
                <button
                    className="BlueButton"
                    aria-label="MakeResearch"
                    onClick={handleSubmit}  // Call the handleSubmit function on button click
                >
                    Maak Onderzoek
                </button>
                <button
                    className="WhiteButton"
                    aria-label="Cancel"
                    onClick={() => navigate('/')}>Annuleren
                </button>
            </div>
        </div>
    );
}
