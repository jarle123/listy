import React, { Component } from "react";

class Settings extends Component {
  render() {
    return (
      <div>
        <h2>Settings</h2>

        <div>
          <label>
            Username
            <input type="text" value="yolo" readOnly></input>
          </label>
        </div>
      </div>
    );
  }
}

export default Settings;
