import "./ChatBox.css";
import { useState, useEffect } from "react";
export function ChatBox (Props)
{
    const [chatData, setChatData] = useState(null);

    useEffect(()=>{
        const getData = async () =>{
        try {
            const response = await fetch("http://localhost:5086/Chat/GetChat/1");
            const data = await response.json();

            setChatData(data);
        } catch (error) {
            console.error(error);
        }
    }
    getData();
    },[]);
    return (
        <div className="ChatBox">
            <div className="ChatHeader">
                <h1>Selecteer Chat</h1>
                <button className="BackButton" aria-label="Chats WegClicken" onClick={Props.onClick}>X</button>
            </div>
            <div className="UserChats">
                {chatData ? (
                    <p>{chatData.userOne}</p>
                ): (
                 <p>loading...</p> 
                )}
            </div>
            <div className="CenterDiv">
                <button className="AddNewChatButton">Maak Nieuwe Chat</button>
            </div>
        </div>
    );
}