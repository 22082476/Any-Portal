import React from 'react';
import { HashRouter, Routes, Route } from 'react-router-dom';

<<<<<<< HEAD
import { Header } from './Header';
import { Home } from './Home';
import { Account } from './Account';
import { Footer } from './Footer';
import { PrivacyPolicy } from './PrivacyPolicy';
import { AllResearches } from './All_Researches_Administrator/All_Researches_Administrator';
import { Companyresearches } from './All_Researches_Company/All_Researches_Company';
import { UpdateResearch } from './All_Researches_Updatescherm/All_Research_Updatescherm';

// Hoofdcomponent met router
function App() {
  return (
    <>
      <Header />
      <HashRouter>
        <Routes>
          <Route path="/" element={<Home Name="Testnaam" Role="Admin" />} />
          <Route path="/Onderzoek" element={<Companyresearches/>} />
          <Route path="/UpdateOnderzoekBedrijf" element={<UpdateResearch />} />
          <Route path="/Account" element={<Account userId="string192371237132" Role="Company" />} />
          <Route path="/Uitloggen" />
          <Route path="/PrivacyPolicy" element={<PrivacyPolicy />} />
        </Routes>
      </HashRouter>
      <Footer />
    </>
  );
}

export default App;
=======
import { Header } from './Header/Header';
import { Home } from './Home/Home';
import { Account } from './Account/Account';
import { Footer } from './Footer/Footer';

import { PrivacyPolicy } from './PrivacyPolicy/PrivacyPolicy';
import { Logout } from './Login/LogoutPage';
import { Register } from './Login/RegisterAccount';
import {AllResearches} from './All_Researches_Administrator/All_Researches_Administrator';
import { AdminRoute } from './Admin/AdminRoute';
import { Admin } from './Admin/Admin';
import { AddAdministrator } from './Admin/AddAdministrator'

export function App() {
    return (
      <>
      <Header />
      <HashRouter>
        <Routes>
            <Route path="/"element={<Home Name="Testnaam" Role="Admin"/>} />
            <Route path="/Onderzoek" element={<AllResearches />} />
            <Route path="/Account" element={<Account userId={sessionStorage.getItem("UserId")} Role={sessionStorage.getItem("Role")} />} />
            <Route path="/Uitloggen" element={<Logout />}/>
            <Route path='/PrivacyPolicy' element={<PrivacyPolicy />}/>
            <Route path='/Administrator' element={<AdminRoute />} />
            <Route path='/Admin' element={<Admin />} />  
            <Route path='/Admin/Toevoegen' element={<AddAdministrator />} />
        </Routes>
      </HashRouter>
      <Footer />
      </>
    );
}

>>>>>>> 623e12c169f2fe8fa15c1a49f384d9ebe6486e4a
