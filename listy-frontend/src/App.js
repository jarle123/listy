import "./css/App.css";
import "./css/components.scss";
import React, { Component } from "react";
import Settings from "./components/Settings.js";
import Footer from "./components/Footer.js";
import MainView from "./components/MainView.js";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import axios from "axios";


class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listys: [],
    };
  }

  componentDidMount() {
    axios.get(apiUrl + "ListyLists").then((response) => {
      this.setState({
        listys: response.data,
      });
    });
  }

  render() {
    return (
      <div className="app">
        <Router>
          <header className="app-header">
            <div>
              <h1>Listy</h1>
            </div>
            <nav id="main-navigation">
              <ul>
                <li>
                  <Link to="/">Home</Link>
                </li>

                <li>
                  <Link to="/settings">Settings</Link>
                </li>
                <li>
                  <Link to="/boards">Boards</Link>
                </li>
              </ul>
            </nav>
          </header>
          <div className="app-content">
            <Switch>
              <Route exact path="/" component={MainView} />
              <Route path="/settings" component={Settings} />
            </Switch>
          </div>
        </Router>
        <Footer></Footer>
      </div>
    );
  }
}

const apiUrl = "https://localhost:44302/api/";

export default App;
