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
                {props.Role === "Company" ? <table className="HomeInfo-table"><tr><th>Onderzoek</th><th>Details</th></tr>{data.map(obj => <tr key={obj.rcode}><td className="table-data"><b>{obj.title}</b></td><td><button className="detail-button" onClick={<></>}><b>Details</b></button></td></tr>)}</table> : ""}
                {props.Role === "Administrator" || props.Role ===  "Admin" ? (
                <table className="HomeInfo-table">
                    <tr>
                        <th className="table-heading">Bedrijfsnaam</th>
                        <th className="table-heading">Website</th>
                    </tr>
                        {data.map(company => 
                            <tr key={company.userId}>
                                <td>{company.companyName}</td>
                                <td><a href={company.website}>{company.companyName}</a></td>
                            </tr>)}
                </table>) 
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