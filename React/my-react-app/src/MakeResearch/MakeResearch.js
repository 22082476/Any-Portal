import { useNavigate } from 'react-router-dom';
import './MakeResearch.css';
import React, { useState } from 'react';

export function MakeResearch(props) {

    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        CompanyId: 'HardCodedCompanyId',
        Company: 'HardCodedCompany',
        Title: '',
        Compensation: '0',
        Type_Research: '',
        Link_Research: '',
        Description: '',
        Disability_Type: [],
        research: '',
    });

    const handleSubmit = async () => {
        try {
            if (formData.Disability_Type.length > 0) {
                formData.Disability_Type = formData.Disability_Type;
            }

            const response1 = await fetch('http://localhost:5064/Research/Research', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),
                ...formData,
                rcode: formData.researchId,
            });

            console.log('Request Payload:', JSON.stringify(formData));

            if (!response1.ok) {
                const errorMessage = await response1.text();
                console.error('Error in /Research/Research::', errorMessage);
                throw new Error('Failed to create research.');
            }

            const data1 = await response1.json();

            console.log('Response Data 1:', data1);

            navigate('/MakeResearchFinalStep', {
                state: {
                    researchId: data1.researchId,
                    rcode: data1.researchId,
                },
            });
                        
        } catch (error) {
            console.error('Error:', error);
        }
    };

    const handleCheckboxChange = (type) => {
        const updatedDisabilityTypes = formData.Disability_Type.includes(type)
            ? formData.Disability_Type.filter((selectedType) => selectedType !== type)
            : [...formData.Disability_Type, type];

        setFormData({ ...formData, Disability_Type: updatedDisabilityTypes });
    };

    const [expanded, setExpanded] = useState(false);
    const handleExpand = () => {
        setExpanded(!expanded);
    };

    return (
        <div className="MakeResearch-div">
                <button className="BackButton"
                    aria-label="Pagina sluiten"
                    onClick={() => navigate('/')}>X
                </button>

                <h2>Onderzoek Maken</h2>

                <div className="Text1-div">
                    <h4>Invoervelden met een * moeten verplicht ingevuld worden</h4>
                </div>

                <div className="Title-R-div">
                    <h3 className="TitleResearch">Titel:*</h3>
                    <input
                        type="text"
                        className="Title-R-TextField"
                        value={formData.Title}
                        placeholder="Voer hier de titel in."
                        onChange={(e) => setFormData({ ...formData, Title: e.target.value })}
                    />
                </div>

                <div className="C-div">
                    <h3 className="Compensation">Compensatie €:*</h3>
                    <input
                        type="number"
                        className="C-TextField"
                        value={formData.Compensation}
                        onChange={(e) => setFormData({ ...formData, Compensation: parseFloat(e.target.value) })}
                    />
                </div>

                <div className="Type-D-div">
                    <h3 className="TypeDisability">Type Beperking:</h3>
                    {['Visueel', 'Fysiek', 'Cognitief', 'Auditief', 'Spraak', 'Ouderen'].map((type) => (
                        <div key={type}>
                            <label>
                                <input
                                    type="checkbox"
                                    value={type}
                                    checked={formData.Disability_Type.includes(type)}
                                    onChange={() => handleCheckboxChange(type)}
                                />
                                {type}
                            </label>
                        </div>
                    ))}
                </div>

                <div className="Type-R-div">
                    <h3 className="TypeResearch">Type:*</h3>
                    <input
                        type="text"
                        className="Type-R-TextField"
                        value={formData.Type_Research}
                        placeholder="Voer hier de type in."
                        onChange={(e) => setFormData({ ...formData, Type_Research: e.target.value })}
                    />
                </div>

                <div className="Link-R-div">
                    <h3 className="LinkResearch">Link:*</h3>
                    <input
                        type="text"
                        className="Link-R-TextField"
                        value={formData.Link_Research}
                        placeholder="Voer hier de link in."
                        onChange={(e) => setFormData({ ...formData, Link_Research: e.target.value })}
                    />
                </div>

                <div className={`D-div ${expanded ? 'Expanded' : ''}`}>
                    <h3 className="Description">Beschrijving:</h3>
                    <textarea
                        className="D-TextField"
                        value={formData.Description}
                        placeholder="Voer hier een beschrijving in."
                        onChange={(e) => setFormData({ ...formData, Description: e.target.value })}
                        style={{ maxWidth: '300px', }}
                    />
                    <button className="ExpandButton" onClick={handleExpand}>
                        {expanded ? 'Read less' : 'Read more'}
                    </button>
                </div>

                <div className="button-div">
                    <button
                        className="BlueButton"
                        aria-label="MakeResearch"
                        onClick={handleSubmit}
                    >
                        Volgende stap
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
