import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Administrator } from "./Administrator";


export function AdminRoute ()
{
    const [role, setRole] = useState("");

    useEffect(()=>
    {
        setRole(sessionStorage.getItem("Role"));
    }, []);

    const navigate = useNavigate();

    const redirect = () => { navigate("/");}
    
    return (<>
            {role === "Administrator" && <Administrator />}
            {role === "Admin" && <Administrator />}
            {role !== "Admin" && role !== "Adminstrator" && redirect()}
            </>
    );
}