import React from "react";
import deleteIcon from "../img/baseline_delete_black_36dp.png";
import editIcon from "../img/baseline_edit_black_36dp.png";

function ListyItem(props) {
  return (
    <li
      draggable
      className="listy-item droptarget"
      onDrag={(event) => props.onDragListItem(event)}
      onDragOver={(event) => props.listItemOnDragOver(event)}
    >
      {props.content}
      <button
        className="btn-remove-li"
        onClick={(event) => props.deleteListItem(event)}
        value={props.listItemId}
      >
        <img className="img-remove-li" alt="Remove item" src={deleteIcon}></img>
      </button>
      <button
        className="btn btn-edit-li"
        value={props.listItemId}
      >
        <img className={"img-edit-li"} alt="Edit item" src={editIcon}></img>
      </button>
    </li>
  );
}

export default ListyItem;
