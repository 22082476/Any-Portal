import React, { useState } from "react";


export function PanelmemberResearches() {
    const [researchList, setResearches] = useState(null);
    const [userData, setUserdata] = useState(null);
    const [medicalData, setmedicalResponseData] = useState(null)
    const [ParticipantData, setResearchParticipantData] = useState(null)
    const userId = sessionStorage.getItem("UserId");
  
    useEffect(() => {
      const fetchData = async () => {
        try {
          const researchResponse = await fetch("https://315d6kkf-5064.euw.devtunnels.ms/Research");
          const responseData = await researchResponse.json();
          setResearches(responseData);
        } catch (error) {
          console.error("Error fetching data from Research:", error);
        }

        try {
            const researchParticipantResponse = await fetch('https://315d6kkf-5064.euw.devtunnels.ms/setResearchParticipantData/${userId}');
            const researchParticipantData = await researchParticipantResponse.json();
            setResearchParticipantData(researchParticipantData);
          } catch (error) {
            console.error("Error fetching data from ResearchParticipant:", error);
          }

        try {
            const userResponse = await fetch('https://315d6kkf-5177.euw.devtunnels.ms/${userId}');
            const Userdata = await userResponse.json();
            setUserdata(Userdata);
          } catch (error) {
            console.error("Error fetching data from UserApi:", error);
          }

      };
  
      fetchData();
    }, []);

    const filteredResearchList = researchList
    ? researchList.filter(): []; 

    function ParticipantDataLoop(){
        for (let i = 0; i < ParticipantData.length; i++){
            for(let j = 0; j < researchList.length; j++){
                if(ParticipantData[i].ResearchId == researchList[j].rcode){
                    filteredResearchList.Add(researchList[j])
                }
            }
        }
    }
    ParticipantDataLoop();
   



    return (
        <div className="Researchbox-div">
          <h1 className='Researchlist'>Alle Onderzoeken</h1>
          <label htmlFor="companySearch">Zoek op bedrijfsnaam:</label>
          <input
            type="text"
            id="companySearch"
            value={searchText}
            onChange={checkSearch}
          />
          {filteredResearchList.length > 0 ? (
            <table className='Researchlist'>   {/* Makes the table*/}
            <thead className='Researchlist'> {/*Head elements table*/}
              <tr className='Researchlist'> {/* Makes a row in the head for multiple head names*/}
                  <th className='Researchlist'>Titel</th>
                  <th className='Researchlist'>Bedrijf</th>
                  <th className='Researchlist'>Beschrijving</th>
                </tr>
              </thead>
              <tbody> {/*Table body*/}
                {filteredResearchList.map(research => (
                  <tr key={research.rcode} className='Researchlist'>
                    <td className='Researchlist'>{research.title}</td>
                    <td className='Researchlist'>{research.company}</td>
                    <td className='Researchlist'>{research.description}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          ) : (
            <p>Geen overeenkomstige onderzoeken gevonden.</p>
          )}
        </div>
      );
    }


