import React from 'react';
import { HashRouter, Routes, Route } from "react-router-dom";

import { Header } from './Header/Header';
import { Home } from './Home';
import { Account } from './Account';
import { Footer } from './Footer';
import { PrivacyPolicy } from './PrivacyPolicy';
import { Logout } from './Login/LogoutPage';
import {AllResearches} from './All_Researches_Administrator/All_Researches_Administrator';

export default
    function App() {
    return (<>
      <Header />
      <HashRouter>
        <Routes>
            <Route path="/"element={<Home Name="Testnaam" Role="Admin"/>} />
            <Route path="/Onderzoek" element={<AllResearches />} />
            <Route path="/Account" element={<Account userId="string192371237132" Role="Company" />} />
            <Route path="/Uitloggen" element={<Logout />}/>
            <Route path='/PrivacyPolicy' element={<PrivacyPolicy />}/>   

        </Routes>
      </HashRouter>
      <Footer />
      </>
    );
}