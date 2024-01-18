import React, { useState } from "react";
import "../Account.css";

export function AvailabilityDropDown(props) {
  const [availability1, setAvailability1] = useState(props.availability.split(" ")[0]);
  const [availability2, setAvailability2] = useState(props.availability.split(" ")[2] === undefined ? "Ma": props.availability.split(" ")[2]);
  const [isNot, setIsNot] = useState(props.availability.split(" ")[0] === "Niet");

  const options1 = ["Niet", "Ma", "Di", "Wo", "Do", "Vr", "Za", "Zo"];
  const options2 = ["Ma", "Di", "Wo", "Do", "Vr", "Za", "Zo"];

  const handleAvailability1Change = (e) => {
    const selectedValue = e.target.value;
    setAvailability1(selectedValue);

    const updatedString = `${selectedValue === "Niet" ? "Niet" : `${selectedValue} t/m ${availability2}`}`;
    props.update(updatedString);

    // Als "Niet" is geselecteerd, verberg de tweede select
    setIsNot(selectedValue === "Niet");
  };

  const handleAvailability2Change = (e) => {
    const selectedValue = e.target.value;
    setAvailability2(selectedValue);

    const updatedString = `${availability1} t/m ${selectedValue}`;
    props.update(updatedString);
  };

  return (
    <div style={{ display: "inline", color: "#000", fontSize: "1rem" }}>
      <select
        id="availability1"
        aria-label="Beschikbaarheid vanaf"
        value={availability1}
        onChange={handleAvailability1Change}
        className="inputfield dropdown-Availability"
        size={1}
      >
        {options1.map((item, index) => (
          <option key={index} value={item}>
            {item}
          </option>
        ))}
      </select>
      {!isNot && (
        <>
          t/m
          <select
            id="availability2"
            aria-label="Beschikbaarheid tot en met"
            value={availability2}
            onChange={handleAvailability2Change}
            className="inputfield dropdown-Availability"
            size={1}
          >
            {options2.map((item, index) => (
              <option key={index} value={item}>
                {item}
              </option>
            ))}
          </select>
        </>
      )}
    </div>
  );
}
