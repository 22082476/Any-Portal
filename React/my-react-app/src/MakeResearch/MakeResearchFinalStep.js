import { useNavigate, useLocation } from 'react-router-dom';
import './MakeResearchFinalStep.css';
import React, { useState } from 'react';

export function MakeResearchFinalStep(props) {

    const navigate = useNavigate();
    const location = useLocation();

    const [formData, setFormData] = useState({
        From_Postalcode: '',
        Till_PostalCode: '',
        Allowed_AgeRangeId: 0,
        postalCodeRangeList: [],
        postalCodeRange: 0,
        researchId: location.state ? location.state.researchId : 0,
    });

    const [error, setError] = useState('');

    const handleAddPostalCodeRange = async () => {
        const { From_Postalcode, Till_PostalCode } = formData;

        if (From_Postalcode && Till_PostalCode) {
            const newRange = `${From_Postalcode} - ${Till_PostalCode}`;
            setFormData({
                ...formData,
                postalCodeRangeList: [...formData.postalCodeRangeList, newRange],
                From_Postalcode: '',
                Till_PostalCode: '',
            });

            addPostalCodeRange(newRange);

            await makeResearchRequest();
        }
    };

    const addPostalCodeRange = (newRange) => {
        console.log('Postal Code Range Added:', newRange);
    };

    const makeResearchRequest = async () => {
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
                rcode: location.state?.rcode || 0,
            });

            console.log('Request Payload:', JSON.stringify(updatedFormData));

            if (!response2.ok) {
                const errorMessage = await response2.text();
                console.error('Error in /Research:', errorMessage);
                throw new Error('Failed to create postal code');
            }

            const data = await response2.json();
            console.log('Response Data:', data);

        } catch (error) {
            console.error('Error:', error);
        }
    };

    const handleSubmit = async () => {
        try {
            if (formData.postalCodeRangeList.length === 0) {
                setError('Postcode range(s) is vereist.');
                return;
            }

            if (formData.Allowed_AgeRangeId === 0) {
                setError('Leeftijdscategorie is vereist.');
                return;
            }
            
            const updatedFormData = {
                ...formData,
                researchId: location.state?.researchId || 0,
                postalCodeRange: formData.postalCodeRangeList.join(','),
            };

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

            const data3 = await response3.json();

            console.log('Response Data 3:', data3);

            navigate('/');

        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <div className="MakeResearchFinalStep-div">
                <h2>Onderzoek Maken</h2>

                <div className="Text1-div">
                    <h4>Invoervelden met een * moeten verplicht ingevuld worden</h4>
                </div>

                <div className="FPC-div">
                    <h3 className="FromPostalCode">Van Postcode:*</h3>
                    <input
                        type="text"
                        className="FPC-TextField"
                        value={formData.From_Postalcode}
                        placeholder="Voer hier de 'van' postcode in."
                        onChange={(e) => setFormData({ ...formData, From_Postalcode: e.target.value })}
                    />
                </div>

                <div className="TPC-div">
                    <h3 className="TillPostalCode">Tot Postcode:*</h3>
                    <input
                        type="text"
                        className="TPC-TextField"
                        value={formData.Till_PostalCode}
                        placeholder="Voer hier de 'tot' postcode in."
                        onChange={(e) => setFormData({ ...formData, Till_PostalCode: e.target.value })}
                    />
                    <button 
                        className="AddPostalCodeButton"
                        onClick={handleAddPostalCodeRange}>Voeg postcodes toe
                    </button>
                </div>

                <div className="AddedPostcodeRange-div">
                    <h3 className="APC-Range"> Toegevoegde Postcode 'Van - Tot' :</h3>
                    <select
                        className="PostalCodeDropdown"
                        value={formData.selectedPostalCodeRange || ''}
                        onChange={(e) => setFormData({ ...formData, selectedPostalCodeRange: e.target.value })}
                    >
                        <option value="">Toon gemaakte Postcode Ranges</option>
                        {formData.postalCodeRangeList.map((range, index) => (
                            <option key={index} value={range}>
                                {range}
                            </option>
                        ))}
                    </select>
                        {error && <p className="PostcodeListError">{error}</p>}
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
                    {error && formData.Allowed_AgeRangeId === 0 && <p className="AgeCategoryError">Leeftijdscategorie is vereist.</p>}
                </div>

                <div className="button-div">
                    <button
                        className="BlueButton"
                        aria-label="MakeResearchFinalStep"
                        onClick={handleSubmit}
                    >
                        Maak Onderzoek
                    </button>
                </div>
        </div>
    );
}