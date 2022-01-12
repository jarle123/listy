import React, { Component } from "react";
import ListyItem from "./ListyItem";
import iconAdd from "../img/baseline_add_black_24dp.png";
import iconEdit from "../img/baseline_edit_black_36dp.png";
import iconDelete from "../img/baseline_delete_black_36dp.png";
import iconSettings from "../img/baseline_settings_black_36dp.png";

const axios = require("axios").default;

class ListyList extends Component {
  constructor(props) {
    super(props);

    this.state = {
      // Initial data seed from parent, let component handle state
      listyListId: props.listyListId,
      listItems: props.listItems,
      apiUrl: props.apiUrl,
    };
  }

  componentDidMount() {}

  addListItem = (event) => {
    // Prevent empty listitems from being added
    if (event.target.value) {
      axios
        .post(this.props.apiUrl + "ListItems/", {
          listyListId: this.props.listyListId,
          content: event.target.value,
        })
        .then((response) => {
          this.setState((prevState) => ({
            listItems: [
              ...prevState.listItems,
              {
                listItemId: response.data.listItemId,
                listyListId: this.props.listyListId,
                content: event.target.value,
              },
            ],
          }));

          event.target.value = "";
        })
        .catch(function (error) {
          alert("Something went wrong, see console");
          console.log("Error addListItem: ", error);
        });
    }
  };

  deleteListItem = (event) => {
    console.log(event.target.parentNode);
    var inputListItemId = Number(event.target.parentNode.value);

    axios
      .delete(this.props.apiUrl + "ListItems/" + inputListItemId)
      .then(() => {
        var newArray = this.state.listItems.filter(
          (item) => item.listItemId !== inputListItemId
        );

        this.setState({
          listItems: newArray,
        });
      })
      .catch((error) => {
        alert("Error removeListItem, see console for info");
        console.log(error);
      });
  };

  editListItem = (event) => {
    console.log("editing item", event);
  };

  // Enter pressed on "new item" input
  handleEnter = (event) => {
    if (event.key === "Enter") {
      this.addListItem(event);
    }
  };


  /* TODO:: implement drag and drop */
  onDragListItem = (event) => {
    console.log(
      "dragging, X: " +
        event.clientX +
        ", Y: " +
        event.clientY +
        ", event.target: " +
        event.target
    );
  };

  listItemOnDragOver = (event) => {
    console.log("Dragging over: ", event);
  };

  render() {
    return (
      <div id="div-list">
        <div className="listy-header">
          <p>{this.props.title}</p>

          <button className="btn">
            <img
              alt="List settings"
              className="img-settings-listy"
              src={iconSettings}
            ></img>
          </button>

          <button
            onClick={(event) => this.props.editListyTitle(event)}
            className="btn"
            value={this.props.listyListId}
          >
            <img
              alt="Edit list title"
              className="icon-listy"
              src={iconEdit}
            ></img>
          </button>

          <button
            onClick={(event) => this.props.deleteListy(event)}
            className="btn"
            value={this.props.listyListId}
          >
            <img
              alt="Delete list"
              className="img-delete-listy"
              src={iconDelete}
            ></img>
          </button>
        </div>
        <ul id="ul-thingy">
          {this.state.listItems.map((value, index) => {
            return (
              <ListyItem
                listItemId={value.listItemId}
                listyListId={value.listyListId}
                key={value.listItemId}
                id="list-item-{listItemId}"
                content={value.content}
                editListItem={this.editListItem}
                deleteListItem={this.deleteListItem}
                onDragListItem={this.onDragListItem}
                listItemOnDragOver={this.listItemOnDragOver}
              ></ListyItem>
            );
          })}
        </ul>
        <input
          className="input-add-list-item"
          type="text"
          placeholder="New item.."
          onKeyDown={this.handleEnter}
        ></input>
        <button className="button-add-list-item" onClick={this.addListItem}>
          <img alt="Add item" className="img-add-list-item" src={iconAdd}></img>
        </button>
      </div>
    );
  }
}

export default ListyList;
