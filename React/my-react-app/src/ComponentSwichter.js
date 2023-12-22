import React, { useState } from 'react';
import './CompentSwichter.css';

// Eerste component
const FirstComponent = () => (
  <div>
    <h1>First Component</h1>
    <p>This is the first component.</p>
  </div>
);

// Tweede component
const SecondComponent = () => (
  <div>
    <h1>Second Component</h1>
    <p>This is the second component.</p>
  </div>
);

const ComponentSwitcher = () => {
  const [showSecondComponent, setShowSecondComponent] = useState(false);

  const handleSwitchComponent = () => {
    setShowSecondComponent(!showSecondComponent);
  };

  return (
    <div className='body'>
      
      {showSecondComponent ? <SecondComponent /> : <FirstComponent />}

      
      <button onClick={handleSwitchComponent}>
        Switch Component
      </button>
    </div>
  );
};

export default ComponentSwitcher;