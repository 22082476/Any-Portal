import React from 'react';
import { BrowserRouter as Router, Route, Switch, Link } from 'react-router-dom';


import Home from './Home';
import Account from './Account';


const App = () => {
  return (
    <Router>
      <div>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/account">Account</Link>
            </li>
          </ul>
        </nav>

        <Switch>
          <Route exact path="/" component={Home} />
          <Route path="/account" component={Account} /> 
        </Switch>
      </div>
    </Router>
  );
};

export default App;
