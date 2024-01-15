import React from 'react';
import { HashRouter, Routes, Route } from "react-router-dom";

import { Header } from './Header/Header';
import { Home } from './Home/Home';
import { Account } from './Account/Account';
import { Footer } from './Footer/Footer';
import { PrivacyPolicy } from './PrivacyPolicy/PrivacyPolicy';
import {AllResearches} from './All_Researches_Administrator/All_Researches_Administrator';


// Hoofdcomponent met router
export function App() {
  return (<>
    <Header />
    <HashRouter>
      <Routes>
          <Route path="/"element={<Home Name="Testnaam" Role="Admin"/>} />
          <Route path="/Onderzoek" element={<AllResearches />} />
          <Route path="/Account" element={<Account userId="string192371237132" Role="Company" />} />
          <Route path="/Uitloggen"/> 
          <Route path='/PrivacyPolicy' element={<PrivacyPolicy />}/>   
      </Routes>
    </HashRouter>
    <Footer />
    </>
  );
}
