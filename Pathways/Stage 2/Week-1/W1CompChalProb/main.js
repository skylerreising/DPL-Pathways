document.querySelector("#addToList").addEventListener("click", postTodo);
document.querySelector("#clearList").addEventListener("click", clearList);

function postTodo(){
    //variable to hold my list
    let myList = document.querySelector("#myList");

    //checkmark
    const checkmark = "<i class='fa-regular fa-square-check'></i>"

    //todo item
    let todo = document.querySelector("#todoEntry").value;

    //trashcan
    const trashcan = '<i class="fa-solid fa-trash-can"></i>'
    
    //Add all 3 to the list
    //trashcan
    myList.appendChild(document.createElement("tr")).appendChild(document.createElement("td")).innerHTML = checkmark;

    //todo item
    //find the last tr and add another td with the todo item
    let allRows = Array.from(myList.rows);
    let lastRow = allRows[allRows.length-1];

    lastRow.appendChild(document.createElement("td")).innerHTML = todo;

    //trashcan
    lastRow.appendChild(document.createElement("td")).innerHTML = trashcan;
}

function clearList(){
    document.querySelector("#myList").innerHTML = "";
}