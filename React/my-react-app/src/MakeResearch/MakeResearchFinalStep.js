import { useNavigate, useLocation } from 'react-router-dom';
import React, { useState } from 'react';
import { AgeDropDown } from '../Account/AlterAccount/AgeDropDown';

export function MakeResearchFinalStep(props) {

    const navigate = useNavigate();
    const location = useLocation();

    const update = (age) => setFormData({ ...formData, Allowed_AgeRangeId: age });

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
        <div className="AccountInfo-div">
            <div>
                <h1>Onderzoek Maken</h1>
                <p className="blue-title">De invoervelden met een * zijn verplicht</p>
                <table className="alterCompany-table">
                    <tr>
                        <td>
                        <label className="input-label">Van Postcode:*</label>

                        </td>
                        <td>
                            <input
                                type="text"
                                className="inputfield"
                                value={formData.From_Postalcode}
                                placeholder="Voer hier de 'van' postcode in."
                            onChange={(e) => setFormData({ ...formData, From_Postalcode: e.target.value })}
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label className="input-label" htmlFor='poststart'>Tot Postcode:*</label>
                        </td>
                        <td>
                            <input
                                id='poststart'
                                type="text"
                                className="inputfield"
                                value={formData.Till_PostalCode}
                                placeholder="Voer hier de 'tot' postcode in."
                                onChange={(e) => setFormData({ ...formData, Till_PostalCode: e.target.value })}
                            />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                        <button 
                        className="WhiteButton"
                        style={{width: "11vw", padding: "0 2.5rem 0 2.5rem", marginTop: "0.5rem"}}
                        onClick={handleAddPostalCodeRange}>Postcode toevoegen
                    </button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label className="input-label" id='postend'> Toegevoegde Postcode 'Van - Tot' :</label>
                        </td>
                        <td>
                            <select
                                className="inputfield"
                                value={formData.selectedPostalCodeRange || ''}
                                onChange={(e) => setFormData({ ...formData, selectedPostalCodeRange: e.target.value })}
                                id='postend'
                            >
                                {formData.postalCodeRangeList.map((range, index) => (
                                <option key={index} value={range}>
                                {range}
                                </option>
                                ))}
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label className="input-label" htmlFor='age'>Leeftijdcategorieën:*</label>
                        </td>
                        <td>
                            <AgeDropDown update={update} ageId={formData.Allowed_AgeRangeId}/>
                        </td>
                    </tr>
                </table>
                                        
                        {error && <p className="PostcodeListError">{error}</p>}
               
                    {error && formData.Allowed_AgeRangeId === 0 && <p className="AgeCategoryError">Leeftijdscategorie is vereist.</p>}

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
        </div>
    );
}