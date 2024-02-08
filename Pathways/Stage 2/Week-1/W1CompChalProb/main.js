document.querySelector("#addToList").addEventListener("click", postTodo);
document.querySelector("#clearList").addEventListener("click", clearList);
document.querySelector("#myList").addEventListener("click", deleteOrComplete)

//variable to hold my list
const myList = document.querySelector("#myList");

function postTodo(){
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

    //wrap todo item in span with a class for its text
    let todoText = `<span class="todo-text">${todo}</span>`

    lastRow.appendChild(document.createElement("td")).innerHTML = todoText;

    //trashcan
    lastRow.appendChild(document.createElement("td")).innerHTML = trashcan;
}

function clearList(){
    document.querySelector("#myList").innerHTML = "";
}

function deleteOrComplete(){
    myList.addEventListener("click", function (e){
        if(e.target.classList.contains("fa-trash-can")){
            let todoRow = e.target.closest('tr')
            todoRow.remove();
        }else if(e.target.classList.contains("fa-square-check")){
            let todoData = e.target.closest('tr').querySelector(".todo-text");
            todoData.classList.toggle("completed");
        }
    })
}