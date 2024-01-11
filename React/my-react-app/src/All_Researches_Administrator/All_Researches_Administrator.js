import React, { useState, useEffect } from 'react';

export function AllResearches() {
  const [researchList, setResearches] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5064/Research");
        const responseData = await response.json();
        setResearches(responseData);
      } catch (error) {
        console.error("Error fetching data from Researchapi:", error);
      }
    };

    fetchData();
  }, []);
 
  return (
    <div>
      <h1>Research List</h1>
      {researchList && (
        <ul>
          {researchList.map(research => (
            <li key={research.rcode}>
              <strong>Title:</strong> {research.title}<br />
              <strong>Company:</strong> {research.company}<br />
              <strong>Active:</strong> {research.active ? 'Yes' : 'No'}<br />
              <hr />
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}
