import React, { Component } from "react";

/* TODO:: Implement login*/
class Login extends Component {
  constructor(props) {
    super(props);

    // Bind event listeners for use of this
  }

  render() {
    return (
      <div>
        <form>
          <div>
            <label for="input-login-username">Username</label>
            <input
              name="input-login-username"
              id="input-login-username"
              placeholder="Username"
              type="text"
            ></input>
          </div>
          <div>
            <label for="input-login-password">Password</label>
            <input
              name="input-login-password"
              id="input-login-password"
              type="password"
            ></input>
          </div>

          <input type="submit" value="Login"></input>
        </form>
      </div>
    );
  }
}

export default Login;
