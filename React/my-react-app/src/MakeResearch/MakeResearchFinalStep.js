import { useNavigate, useLocation } from 'react-router-dom';
import './MakeResearchFinalStep.css';
import React, { useState } from 'react';

export function MakeResearchFinalStep() {

    const navigate = useNavigate();
    const location = useLocation();

    const [formData, setFormData] = useState({
        From_Postalcode: '',
        Till_PostalCode: '',
        Allowed_AgeRangeId: 0,
        postalCodeRange: 0,
        researchId: location.state ? location.state.researchId : 0,
    });

    const handleSubmit = async () => {
        try {
            const updatedFormData = {
                ...formData,
                researchId: location.state?.researchId || 0,
            };
            
            const response2 = await fetch('http://localhost:5064/Research', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(updatedFormData),
                ...updatedFormData,
                rcode: location.state?.rcode || 0,
            });

            console.log('Request Payload:', JSON.stringify(updatedFormData));

            if (!response2.ok) {
                const errorMessage = await response2.text();
                console.error('Error in /Research:', errorMessage);
                throw new Error('Failed to create postalcode');
            }

            const response3 = await fetch('http://localhost:5064/Research/CreateAllowed_AgeRange', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(updatedFormData),
            });

            console.log('Request Payload:', JSON.stringify(updatedFormData));

            if (!response3.ok) {
                const errorMessage = await response3.text();
                console.error('Error in /Research/CreateAllowed_AgeRange:', errorMessage);
                throw new Error('Failed to create age range');
            }

            const data2 = await response2.json();
            const data3 = await response3.json();

            console.log('Response Data 2:', data2);
            console.log('Response Data 3:', data3);

            navigate('/');

        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <div className="MakeResearchFinalStep-div">
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
                        <option value={0}>Selecteer Leeftijdscategorieën</option>
                        <option value={1}>4 t/m 17 jaar</option>
                        <option value={2}>18 t/m 30 jaar</option>
                        <option value={3}>31 t/m 50 jaar</option>
                        <option value={4}>50+ jaar</option>

                    </select>
                </div>

                <div className="button-div">
                    <button
                        className="BlueButton"
                        aria-label="MakeResearchFinalStep"
                        onClick={handleSubmit}
                    >
                        Maak Onderzoek
                    </button>
                    <button
                        className="WhiteButton"
                        aria-label="Cancel"
                        onClick={() => navigate('/MakeResearch')}>Terug
                    </button>
                </div>
        </div>
    );
}