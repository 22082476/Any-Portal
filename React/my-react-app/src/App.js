import React from 'react';
import { HashRouter, Routes, Route } from "react-router-dom";

import { Header } from './Header';
import { Home } from './Home';
import { Account } from './Account';
import { Footer } from './Footer';
import { PrivacyPolicy } from './PrivacyPolicy'
import { MakeResearch } from './MakeResearch/MakeResearch'


// Hoofdcomponent met router
function App() {
  return (<>
    <Header />
    <HashRouter>
      <Routes>
          <Route path="/Onderzoek" element={<MakeResearch/>} />
          <Route path="/Account" element={<Account Role="PanelMember" />} />
          <Route path="/Uitloggen"/> 
          <Route path='/PrivacyPolicy' element={<PrivacyPolicy />}/> 
          <Route path='/AlterAccount' element={<></>}/>    
      </Routes>
    </HashRouter>
    <Footer />
    </>
  );
}


export default App;
