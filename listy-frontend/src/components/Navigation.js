import React, { Component } from "react";
import { Link } from "react-router-dom";

class Navigation extends Component {

  render() {
    return (
      <nav id="main-navigation">
        <ul>
          <li>
            <Link to="/settings">Settings</Link>
          </li>
          <li>
            <Link to="/boards">Boards</Link>
          </li>
        </ul>
      </nav>
    );
  }
}

export default Navigation;
