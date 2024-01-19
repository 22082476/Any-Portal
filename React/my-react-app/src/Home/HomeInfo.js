import { useState, useEffect } from "react";
import "./HomeInfo.css";

export function HomeInfo (props)
{
    const [data, setData] = useState(null);
    const endPoint = (Role) => {
        switch (Role) {
            case "PanelMember":
                // return "https://315d6kkf-5177.euw.devtunnels.ms/PanelMember/";
                return "https://315d6kkf-5177.euw.devtunnels.ms/PanelMember/";
            case "Company":
                // return "https://315d6kkf-5177.euw.devtunnels.ms/Research/";
                return "https://315d6kkf-5064.euw.devtunnels.ms/Research/";
            case "Admin":
            case "Administrator":
                // return "https://315d6kkf-5177.euw.devtunnels.ms/Company/";
                return "";
            default:
                return "https://315d6kkf-5177.euw.devtunnels.ms/Company/";
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
                <table className="HomeInfo-table">
                    <tr>
                        <th className="table-heading"><h3>Bedrijfsnaam</h3></th>
                        <th className="table-heading"><h3>Website</h3></th>
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