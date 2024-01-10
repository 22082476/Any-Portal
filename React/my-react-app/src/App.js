import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";

import { Header } from './Header/Header';
import { Home } from './Home';
import { Account } from './Account/Account';
import { Footer } from './Footer/Footer';
import { PrivacyPolicy } from './PrivacyPolicy/PrivacyPolicy'


// Hoofdcomponent met router
function App() {
  return (<>
    <Header />
    <BrowserRouter>
      <Routes>
          <Route path="/"element={<Home Name="Testnaam" Role="PanelMember"/>} />
          <Route path="Onderzoek" element={<></>} />
          <Route path="Account" element={<Account />} />
          <Route path="Uitloggen"/> 
          <Route path='PrivacyPolicy' element={<PrivacyPolicy />}/>     
          {/* <Route path="*" element={<NoPage />} /> */}
      </Routes>
    </BrowserRouter>
    <Footer />
    </>
  );
}


export default App;
