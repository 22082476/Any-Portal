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
        Disability_Type: [],
        research: '',
        From_Postalcode: '',
        Till_PostlaCode: '',
        Allowed_AgeRangeId: '',
        description: '',

    });

    const handleSubmit = async () => {
        try {
            const response1 = await fetch('http://localhost:5064/Research/Research', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),
            });

            console.log('Request Payload:', JSON.stringify(formData));

            if (!response1.ok) {
                const errorMessage = await response1.text();
                console.error('Error:', errorMessage);
                throw new Error('Netwerkreactie was niet in orde');
            }

            const response2 = await fetch('http://localhost:5064/Research', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),
            });

            console.log('Request Payload:', JSON.stringify(formData));

            if (!response2.ok) {
                const errorMessage = await response2.text();
                console.error('Error:', errorMessage);
                throw new Error('Netwerkreactie was niet in orde');
            }

            const response3 = await fetch('http://localhost:5064/Research/CreateAllowed_AgeRange', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),
            });

            console.log('Request Payload:', JSON.stringify(formData));

            if (!response3.ok) {
                const errorMessage = await response3.text();
                console.error('Error:', errorMessage);
                throw new Error('Netwerkreactie was niet in orde');
            }

            const data1 = await response1.json();
            const data2 = await response2.json();
            const data3 = await response3.json();

            console.log('Response Data 1:', data1);
            console.log('Response Data 2:', data2);
            console.log('Response Data 3:', data3);

            //navigate('/');

        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <div className="MakeResearch-div">
                <button className="BackButton"
                    aria-label="Pagina sluiten"
                    onClick={() => navigate('/')}>X
                </button>

                <div className="PageTitle-div">
                    <h2>Titel Onderzoek</h2>
                </div>

                <div className="Text1-div">
                    <h4>Invoervelden met een * moeten verplicht ingevuld worden</h4>
                </div>

                <div className="Title-R-div">
                    <h3 className="TitleResearch">Titel Onderzoek:*</h3>
                    <input
                        type="text"
                        className="Title-R-TextField"
                        value={formData.Title}
                        onChange={(e) => setFormData({ ...formData, Title: e.target.value })}
                    />
                </div>

                <div className="C-div">
                    <h3 className="Compensation">Compensatie:*</h3>
                    <input
                        type="number"
                        className="C-TextField"
                        value={formData.Compensation}
                        onChange={(e) => setFormData({ ...formData, Compensation: parseFloat(e.target.value) })}
                    />
                </div>

                <div className="Type-R-div">
                    <h3 className="TypeResearch">Type Onderzoek:*</h3>
                    <input
                        type="text"
                        className="Type-R-TextField"
                        value={formData.Type_Research}
                        onChange={(e) => setFormData({ ...formData, Type_Research: e.target.value })}
                    />
                </div>

                <div className="Link-R-div">
                    <h3 className="LinkResearch">Link Onderzoek:*</h3>
                    <input
                        type="text"
                        className="Link-R-TextField"
                        value={formData.Link_Research}
                        onChange={(e) => setFormData({ ...formData, Link_Research: e.target.value })}
                    />
                </div>

                <div className="Type-D-div">
                    <h3 className="TypeDisability">Type Beperking:</h3>
                    <select
                        className="Type-D-Select"
                        value={formData.Disability_Type}
                        onChange={(e) => setFormData({ ...formData, Disability_Type: Array.from(e.target.selectedOptions, option => option.value) })}
                    >
                        <option value="">Selecteer Type Beperking</option>
                        <option value="Visueel">Visueel</option>
                        <option value="Fysiek">Fysiek</option>
                    </select>
                </div>

                <div className="FPC-div">
                    <h3 className="FromPostalCode">Van Postcode:*</h3>
                    <input
                        type="text"
                        className="FPC-TextField"
                        value={formData.From_Postalcode}
                        onChange={(e) => setFormData({ ...formData, From_Postalcode: e.target.value })}
                    />
                </div>

                <div className="TPC-div">
                    <h3 className="TillPostalCode">Tot Postcode:*</h3>
                    <input
                        type="text"
                        className="TPC-TextField"
                        value={formData.Till_PostalCode}
                        onChange={(e) => setFormData({ ...formData, Till_PostalCode: e.target.value })}
                    />
                </div>

                <div className="AC-div">
                    <h3 className="AgeCategory">Leeftijdcategorieën:*</h3>
                    <select
                        className="AC-Select"
                        value={formData.Allowed_AgeRangeId}
                        onChange={(e) => setFormData({ ...formData, Allowed_AgeRangeId: parseInt(e.target.value) })}
                    >
                        <option value={0}>Selecteer Leeftijdscategorie</option>
                        <option value={1}>4 t/m 17 jaar</option>
                        <option value={2}>18 t/m 30 jaar</option>
                    </select>
                </div>

                <div className="Description-div">
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
                    onClick={handleSubmit}
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
