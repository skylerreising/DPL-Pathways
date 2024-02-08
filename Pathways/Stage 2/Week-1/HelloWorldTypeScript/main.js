"use strict";
function myFunction() {
    let newName = " ";
    let age = 0;
    newName = document.getElementById("fname").value;
    age = Number(document.getElementById("age").value);
    console.log(newName, age);
    document.getElementById("greeting").innerHTML = "More and more splendid greetings " + newName + " age: " + age + " !!";
}
