import { useNavigate } from 'react-router-dom';
import React, { useEffect, useState } from 'react';

export function MakeResearch (props) {

    useEffect(() => {if(sessionStorage.getItem("Role") !== "Company")navigate("/")},[]);


    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        CompanyId: props.userId,
        Company: props.userId,
        Title: '',
        Compensation: '',
        Type_Research: '',
        Link_Research: '',
        Description: '',
        Disability_Type: [],
        research: '',
    });

    const [formErrors, setFormErrors] = useState({
        Title: '',
        Compensation: '',
        Type_Research: '',
        Link_Research: '',
    });

    const handleSubmit = async () => {
        try {
            setFormErrors({
                Title: '',
                Compensation: '',
                Type_Research: '',
                Link_Research: '',
            });
        
            if (!formData.Title || !formData.Compensation || !formData.Type_Research) {
                setFormErrors({
                    Title: !formData.Title ? 'Titel is vereist' : '',
                    Compensation: !formData.Compensation ? 'Compensatie is vereist' : '',
                    Type_Research: !formData.Type_Research ? 'Type onderzoek is vereist' : '',
            });
                return;
            }

            if (formData.Disability_Type.length > 0) {
                formData.Disability_Type = formData.Disability_Type;
            }

            const response1 = await fetch('https://315d6kkf-5064.euw.devtunnels.ms/Research/Research', {
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

    return (
        <div className="AccountInfo-div">
            <div>
                <button className="BackButton"
                    aria-label="Pagina sluiten"
                    onClick={() => navigate('/')}>X
                </button>

                <h1>Onderzoek maken</h1>
                <p className="blue-title">De invoervelden met een * zijn verplicht</p>
                <table className="alterCompany-table">
                <tr>
                    <td>
                    <label className="input-label" htmlFor='title'>Titel</label>
                    </td>
                    <td>
                    {formErrors.Title && <p className="TitleError">{formErrors.Title}</p>}
                    <input
                        type="text"
                        className="inputfield"
                        id='title'
                        value={formData.Title}
                        placeholder="Voer hier de titel in."
                        onChange={(e) => setFormData({ ...formData, Title: e.target.value })}
                    />
                    *
                    </td>
                </tr>
                <tr>
                    <td>
                    <label className="input-label" htmlFor='money'>Compensatie in € </label>
                    </td>
                    <td>
                    {formErrors.Compensation && <p className="CompensationError">{formErrors.Compensation}</p>}
                    <input
                        type="number"
                        className="inputfield"
                        value={formData.Compensation}
                        id='money'
                        placeholder="Voer hier de compensatie in."
                        onChange={(e) => setFormData({ ...formData, Compensation: parseFloat(e.target.value) })}
                    />
                    *
                    </td>
                </tr>
                <tr>
                    <td>
                        <label className="input-label" htmlFor='type'>Type Beperking</label>
                    </td>
                    <td>
                        <div className='inputfield' style={{display: "flex", flexFlow: "row wrap", alignItems: "flex-start"}}>
                        {['Visueel', 'Fysiek', 'Cognitief', 'Auditief', 'Spraak', 'Ouderen'].map((type) => (
                                <label key={type}>
                                    <input
                                        type="checkbox"
                                        value={type}
                                        id='type'
                                        checked={formData.Disability_Type.includes(type)}
                                        onChange={() => handleCheckboxChange(type)}
                                    />
                                    {type}
                                </label>
                    ))}
                    </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label className="input-label" htmlFor='typer'>Type onderzoek</label>
                    </td>
                    <td>
                        {formErrors.Type_Research && <p className="TitleError">{formErrors.Type_Research}</p>}
                        <input
                            type="text"
                            className="inputfield"
                            value={formData.Type_Research}
                            id='typer'
                            placeholder="Voer hier het type onderzoek in."
                            onChange={(e) => setFormData({ ...formData, Type_Research: e.target.value })}
                        />
                        *
                    </td>
                </tr>
                <tr>
                    <td>
                        <label className="input-label" htmlFor='rlink'>Onderzoekslink:</label>
                    </td>
                    <td>
                        <input
                            type="text"
                            className="inputfield"
                            id='rlink'
                            value={formData.Link_Research}
                            placeholder="Voer hier de link in."
                            onChange={(e) => setFormData({ ...formData, Link_Research: e.target.value })}
                        />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label className="input-label " htmlFor='descript'>Beschrijving</label>
                    </td>
                    <td>
                        <textarea
                            className="inputfield"
                            value={formData.Description}
                            id='descript'
                            placeholder="Voer hier een beschrijving in."
                            onChange={(e) => setFormData({ ...formData, Description: e.target.value })}
                            style={{ maxWidth: '300px', }}
                        />
                    </td>
                </tr>
                </table> 
              
                <div className="button-div">
                    <button
                        className="WhiteButton"
                        aria-label="Cancel"
                        onClick={() => navigate('/')}>Annuleren
                    </button>
                    <button
                        className="BlueButton"
                        aria-label="MakeResearch"
                        onClick={handleSubmit}
                    >
                        Volgende stap
                    </button>
                </div>
            </div>
        </div>
    );
}
