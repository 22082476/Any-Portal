
import React from 'react';
import { HashRouter, Routes, Route } from 'react-router-dom';
import { Header } from './Header/Header';
import { Home } from './Home/Home';
import { Account } from './Account/Account';
import { Footer } from './Footer/Footer';

import { PrivacyPolicy } from './PrivacyPolicy/PrivacyPolicy';
import { Logout } from './Login/LogoutPage';
import { AdminRoute } from './Admin/AdminRoute';
import { Admin } from './Admin/Admin';
import { AddAdministrator } from './Admin/AddAdministrator'
import { Research } from './Research';
import { MakeResearch } from './MakeResearch/MakeResearch';
import {MakeResearchFinalStep } from './MakeResearch/MakeResearchFinalStep';

import { DeleteResearch } from './DeleteResearch/DeleteResearch';
import { Companyresearches } from './All_Researches_Company/All_Researches_Company';

export function App() {
    return (
      <>
      <Header />
      <HashRouter>
        <Routes>
            <Route path="/"element={<Home Name={sessionStorage.getItem("Role")} Role={sessionStorage.getItem("Role")} />} />
            <Route path="/Onderzoek" element={<Research userId={sessionStorage.getItem("UserId")} Role={sessionStorage.getItem("Role")} />} />
            <Route path="/Account" element={<Account userId={sessionStorage.getItem("UserId")} Role={sessionStorage.getItem("Role")} />} />
            <Route path='/MaakOnderzoek' element={<MakeResearch userId={sessionStorage.getItem("UserId")}/>} />
            <Route path='/MakeResearchFinalStep' element={<MakeResearchFinalStep />} />
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