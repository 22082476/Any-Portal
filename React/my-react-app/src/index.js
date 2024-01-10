import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import Header from './Header/Header';
import HeaderNav from './Header/Header-nav';
// import App from './App.js';
import reportWebVitals from './reportWebVitals';
import Footer from './Footer/Footer';
import FooterNav from './Footer/FooterNav';
import App from './App';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
