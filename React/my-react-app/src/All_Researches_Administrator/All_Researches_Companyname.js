import React, { useState, useEffect } from 'react';


export function Company(props){

    const [company, setCompany] = useState(null);
    

useEffect(() => {
    const fetchData = async () => {
      try {
        const companyResponse = await fetch("http://localhost:5177/Company/" + props.userId);
        const companyResponseData = await companyResponse.json();
        setCompany(companyResponseData);
      } catch (error) {
        console.error("Error fetching data from Userapi:", error);
      }
    };

    fetchData();
  }, []);


  return company ? (<>{company.companyName}</>) : (<>Loading...</>);


}
