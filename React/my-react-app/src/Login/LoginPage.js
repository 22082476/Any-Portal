import './LoginStyle.css';
import { ChatBubble } from '../Chat/ChatBubble';
import { App } from '../App';
import { useState, useEffect } from "react";
import { Register } from './RegisterAccount';
import { LoginForm } from './LoginForm';
import { SelectRegisterType } from './SelectRegisterType';
    

    

export function LoginPage() {
    const [isRegister, setIsRegister] = useState(false);

    const changeIsRegister = (e) => setIsRegister(e);

    console.log(sessionStorage.getItem("UserId"), sessionStorage.getItem("Role"));
  
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
              <SelectRegisterType state={changeIsRegister} />   
            ) : (
              <LoginForm state={changeIsRegister}/>
            )}
          </>
        )}
      </>
    );
  }