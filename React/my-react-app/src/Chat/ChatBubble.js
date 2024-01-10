import "./ChatBubble.css";
import img from "./ChatIcon.png";
export function ChatBubble ()
{
    return (
        <button className="ChatBubble">
            <img src={img}/>
        </button>
    );
}