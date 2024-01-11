import React from 'react';
import { HashRouter, Routes, Route } from "react-router-dom";

import { Header } from './Header';
import { Home } from './Home';
import { Account } from './Account';
import { Footer } from './Footer';
import { PrivacyPolicy } from './PrivacyPolicy'

import './Medical/MedicalInfo.css';
import Medical from './Medical/MedicalInfo';
import { useState } from 'react';
import {v4 as uuidv4} from 'uuid';


// Hoofdcomponent met router
function App() {
  const [input, setInput] = useState('Fill in');
  const [medicalInformation, setMedicalInformation] = useState(
    [
      {
        name: 'UserId', 
        input: 'Foreign Key', 
        img: 'https://images.pexels.com/photos/1568804/pexels-photo-1568804.jpeg'
      },
      {
        name: 'Type', 
        input: 'Foreign Key', 
        img: 'https://images.pexels.com/photos/4058316/pexels-photo-4058316.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
      },
      {
        name: 'Name', 
        input: 'Foreign Key', 
        img: 'https://images.pexels.com/photos/3732881/pexels-photo-3732881.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
      },
      {
        name: 'Tool', 
        input: 'Foreign Key', 
        img: 'https://images.pexels.com/photos/8327846/pexels-photo-8327846.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1'
      }
    ]
  );
  const showMedicalInfo = true;
  return (<>
    <Header />
    <HashRouter>
      <Routes>
          <Route path="/"element={<Home Name="Testnaam" Role="PanelMember"/>} />
          <Route path="/Onderzoek" element={<></>} />
          <Route path="/Account" element={<Account />} />
          <Route path="/Uitloggen"/> 
          <Route path='/PrivacyPolicy' element={<PrivacyPolicy />}/>     
          {/* <Route path="*" element={<NoPage />} /> */}
      </Routes>
    </HashRouter>
    <div className='App'>
        {showMedicalInfo ? (
        <>
        <input type='text' 
          onChange={(e) => {
              console.log(e.target.value);
              setInput(e.target.value);
        }} />
            <div className="flex flex-wrap justify-center" >
              {medicalInformation.map( (medicalInfo) => {
                console.log(uuidv4());
                return (
                  <Medical
                    key={uuidv4()}
                    name={medicalInfo.name} 
                    input={medicalInfo.input} 
                    img={medicalInfo.img} 
                  />
                );
                })}
            </div>
        </>
        ) : (
          <p>U kan de medische gegevens niet zien</p>
        )}
      </div>
    <Footer />
    </>
  );
}


export default App;
