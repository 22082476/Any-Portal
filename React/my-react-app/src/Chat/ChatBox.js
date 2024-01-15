import "./ChatBox.css";
import { useState, useEffect } from "react";
export function ChatBox (Props)
{
    const [chatData, setChatData] = useState(null);

    useEffect(()=>{
        const getData = async () =>{
        try {
            const response = await fetch("https://315d6kkf-5086.euw.devtunnels.ms/Chat/GetChat/1");
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
                <h3>Selecteer Chat</h3>
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