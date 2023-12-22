import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import Header from './Header';
import HeaderNav from './Header-nav';
// import App from './App.js';
import reportWebVitals from './reportWebVitals';
import Footer from './Footer';
import FooterNav from './FooterNav';
import Test from './ComponentSwichter';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
     <Header />
     <Test />
    <Footer />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
