import "./ChatBox.css";
export function ChatBox (Props)
{
    return (
        <div className="ChatBox">
            <div className="ChatHeader">
                <h3>Selecteer Chat</h3>
                <button className="BackButton" aria-label="Chats WegClicken" onClick={Props.onClick}>X</button>
            </div>
            <div className="UserChats">

            </div>
            <div className="CenterDiv">
                <button className="AddNewChatButton">Maak Nieuwe Chat</button>
            </div>
        </div>
    );
}