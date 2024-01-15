import "./ChatBubble.css";
import img from "./ChatIcon.png";
import { ChatBox } from "./ChatBox";
import { useState } from "react";
export function ChatBubble (Props)
{
    const [ShowChats, SetShowChat, ShowMessages, SetShowMessages] = useState(false, false);

    const toggleShowChat = () =>{
        SetShowChat(!ShowChats);
    }
    const toggleShowMessages = () =>{
        SetShowMessages(!ShowMessages);
    }
    return (
        <div>
            <button className="ChatBubble" onClick={toggleShowChat}>
                <img src={img}/>
            </button>
            {ShowChats && <ChatBox onClick={toggleShowChat}/>}
        </div>
    );
}