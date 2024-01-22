import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Administrator } from "./Administrator";


export function AdminRoute ()
{   
    const redirect = () => { navigate("/");}

    const [role, setRole] = useState("");

    useEffect(()=>
    {
        setRole(sessionStorage.getItem("Role"));

        if(role === "PanelMember" || role === "Company")
        {
        redirect();
        }
    }, []);

    

    

    const navigate = useNavigate();

    
    return (<>
            {role === "Administrator" && <Administrator />}
            {role === "Admin" && <Administrator />}
            </>
    );
}