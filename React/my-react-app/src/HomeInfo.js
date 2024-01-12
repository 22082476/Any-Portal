import { useState, useEffect } from "react";
import "./HomeInfo.css";

export function HomeInfo (props)
{
    const [data, setData] = useState(null);
    const endPoint = (Role) => {
        switch (Role) {
            case "PanelMember":
                return "http://localhost:5177/PanelMember/";
            case "Company":
                return "http://localhost:5177/Research/";
            case "Admin":
            case "Administrator":
                return "http://localhost:5177/Company/";
            default:
                return "";
        }
    }
    useEffect(() =>
    {
        const fetchData = async () => 
        {
            const response = await fetch(endPoint(props.Role));
            const data = await response.json();

            setData (data);
        }
        
        fetchData();
    }, []);

    return(<>{data ? 
        (
            <div className="Table-div">
                {props.Role === "PanelMember" ? "" : ""}
                {props.Role === "Company" ? <table>{data.map(obj => <tr key={obj.rcode}><td>obj.title</td><td></td></tr>)}</table> : ""}
                {props.Role === "Administrator" || "Admin" ? 
                <table>
                    <tr>
                        <th className="table-heading">Bedrijfsnaam</th>
                        <th className="table-heading">Website</th>
                    </tr>
                        {data.map(company => 
                        <tr key={company.userId}>
                            <td>{company.companyName}</td>
                            <td><a href={company.website}>{company.companyName}</a></td>
                        </tr>)}
                </table> 
                : 
                ""}
            </div>
        ) 
        :  
        (
            <>Loading..</>
        )
    }</>);
}