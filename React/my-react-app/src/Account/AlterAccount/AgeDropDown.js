import React, { useState, useEffect } from "react";

export function AgeDropDown(props) {
  const [ages, setAges] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("https://315d6kkf-5177.euw.devtunnels.ms/UserData/Ages");
        const responseData = await response.json();
        setAges(responseData);
      } catch (error) {
        console.error("Error fetching data from userapi:", error);
      }
    };

    fetchData();
  }, []);

  return (
      <select style={{width: "66%", border: "solid 0.1rem"}} value={props.ageId} onChange={(e) => props.update(e.target.value)} className="inputfield" id="age" size={1}>
        {ages &&
          ages.map((item, index) => (
            <option key={index} value={item.ageId}>
              {item.ageStart} t/m {item.ageEnd} jaar
            </option>
          ))}
      </select>
  );
}
