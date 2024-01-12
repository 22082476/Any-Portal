import "./UserButton.css";
export function UserButton (Props)
{
    return (
        <div className="UserButton">
            <button className="SelectChatButton" aria-label="Selecteer chat" onClick={Props.onClick(Props.userId)}>
                <h3>{Props.name}</h3>
            </button>
        </div>
    );
}