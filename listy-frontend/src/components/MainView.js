import React, { Component } from "react";
import ListyList from "./ListyList";
const axios = require("axios").default;

class MainView extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoggedIn: true,
      listys: [],
    };
  }

  componentDidMount() {
    // Get all initial seed data
    axios.get(apiUrl + "ListyLists").then((response) => {
      this.setState({
        listys: response.data,
      });
      console.log("Response: ", response.data);
    });
  }

  addListy = (event) => {

    axios
      .post(apiUrl + "ListyLists", {
        title: "Untitled...",
        listItems: [],
      })
      .then((response) => {
        let newListyListId = response.data.listyListId;

        this.setState((prevState) => ({
          listys: [
            ...prevState.listys,
            {
              listyListId: newListyListId,
              title: "Untitled...",
              listItems: [],
            },
          ],
        }));
      })
      .catch((error) => {
        alert("Error adding list, see console for deails");
        console.log(error);
      });
  };

  editListyTitle = (event) => {
    let listyId = Number(event.target.parentNode.value);

    let newTitle = prompt("Enter new title");

    if (newTitle) {
      let newArray = this.state.listys;
      let objIndex = newArray.findIndex((obj) => obj.listyListId === listyId);
      newArray[objIndex].title = newTitle;

      axios
        .put(apiUrl + "ListyLists/" + listyId, {
          listyListId: newArray[objIndex].listyListId,
          title: newArray[objIndex].title,
          listyItems: newArray[objIndex].listyItems
        })
        .then(() => {
          this.setState({
            listys: newArray,
          });
        })
        .catch((error) => {
          alert("Error editing title!");
          console.log(error);
        });
    }
  };

  deleteListy = (event) => {
    let listyId = Number(event.target.parentNode.value);

    let deleteConfirmed = window.confirm(
      "Do you want to delete list and all items?"
    );

    if (deleteConfirmed) {
      axios
        .delete(apiUrl + "ListyLists/" + listyId)
        .then(() => {
          let newArray = this.state.listys.filter(
            (listy) => listy.listyListId !== listyId
          );

          this.setState({
            listys: newArray,
          });
        })
        .catch((error) => {
          alert("Error deleting list");
          console.log("Error in deleteListy: " + error);
        });
    }
  };

  settingsOnMouseEnter = (event) => {
    console.log("hovering over : ", event.target);
  };

  settingsOnMouseLeave = (event) => {
    console.log("not hovering");
  };

  render() {
    return (
      <div id="mainView">

        { this.state.isLoggedIn &&
          <p>Is logged in</p>
        }
        <h1>Title</h1>

        {this.state.listys.map((list, i) => {
          return (
            <ListyList
              key={list.listyListId}
              listyListId={list.listyListId}
              title={list.title}
              listItems={list.listItems}
              apiUrl={apiUrl}
              deleteListy={this.deleteListy}
              editListyTitle={this.editListyTitle}
            ></ListyList>
          );
        })}

        <button onClick={this.addListy}>Add new list</button>
      </div>
    );
  }
}

const apiUrl = "https://localhost:44302/api/";
export default MainView;
