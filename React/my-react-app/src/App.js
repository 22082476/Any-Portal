import React from 'react';
import { HashRouter, Routes, Route } from "react-router-dom";

import { Header } from './Header';
import { Home } from './Home';
import { Account } from './Account';
import { Footer } from './Footer';
import { PrivacyPolicy } from './PrivacyPolicy'
import { Logout } from './Login/LogoutPage'


// Hoofdcomponent met router
function App() {
  return (<>
    <Header />
    <HashRouter>
      <Routes>
          <Route path="/"element={<Home Name="Testnaam" Role="PanelMember"/>} />
          <Route path="/Onderzoek" element={<></>} />
          <Route path="/Account" element={<Account Role="PanelMember" />} />
          <Route path="/Uitloggen"/> 
          <Route path='/PrivacyPolicy' element={<PrivacyPolicy />}/> 
          <Route path='/AlterAccount' element={<></>}/>
          <Route path='/Logout' element={<Logout />}/>    
      </Routes>
    </HashRouter>
    <Footer />
    </>
  );
}


export default App;
