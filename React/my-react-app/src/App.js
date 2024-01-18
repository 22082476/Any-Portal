import React from 'react';
import { HashRouter, Routes, Route } from "react-router-dom";

import { Header } from './Header/Header';
import { Home } from './Home/Home';
import { Account } from './Account/Account';
import { Footer } from './Footer/Footer';
import { PrivacyPolicy } from './PrivacyPolicy/PrivacyPolicy';
import { Logout } from './Login/LogoutPage';
import { Register } from './Login/RegisterAccount';
import {AllResearches} from './All_Researches_Administrator/All_Researches_Administrator';

export default
    function App() {
    return (<>
      <Header />
      <HashRouter>
        <Routes>
            <Route path="/"element={<Home Name="Testnaam" Role="Admin"/>} />
            <Route path="/Onderzoek" element={<AllResearches />} />
            <Route path="/Account" element={<Account userId={sessionStorage.getItem("UserId")} Role={sessionStorage.getItem("Role")} />} />
            <Route path="/Uitloggen" element={<Logout />}/>
            <Route path='/PrivacyPolicy' element={<PrivacyPolicy />}/>
        </Routes>
      </HashRouter>
      <Footer />
      </>
    );
}