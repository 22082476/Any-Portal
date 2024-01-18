import './LoginStyle.css';

import { ChatBubble } from '../Chat/ChatBubble';
import App from '../App';
import { useState, useEffect } from "react";
import { Register } from './RegisterAccount';
import { LoginForm } from './LoginForm';
    

    

export function LoginPage() {
    const [isRegister, setIsRegister] = useState(false);

    const changeIsRegister = (e) => setIsRegister(e);
  
    return (
      <>
        {sessionStorage.getItem("UserId") !== null && sessionStorage.getItem("Role") !== null ? (
          // Render a different component or page when logged in
          <>
            <App />
            <ChatBubble />
          </>
        ) : (
          <>
            {isRegister ? (
              <Register state={changeIsRegister}/>
            ) : (
              <LoginForm state={changeIsRegister} />
            )}
          </>
        )}
      </>
    );
  }