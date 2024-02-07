document.querySelector("#addToList").addEventListener("click", validateANDadd)
document.querySelector("#clearList1").addEventListener("click", clearList1)
document.querySelector("#clearList2").addEventListener("click", clearList2)
document.querySelector("#clearList3").addEventListener("click", clearList3)
document.querySelector("#wackyButton").addEventListener("click", randomColors)

function randomColors(){
    //Change background and font colors to random values
    //need function to produce random number between 0-255
    //need 3 variables to hold different random numbers
    let color1 = randomColorNum();
    let color2 = randomColorNum();
    let color3 = randomColorNum();

    //target the body and change background color to the generated rgb values
    let body = document.querySelector("body");
    body.style.background = `rgb(${color1} ${color2} ${color3})`

    //FONT CHANGE
    let color4 = randomColorNum();
    let color5 = randomColorNum();
    let color6 = randomColorNum();

    body.style.color = `rgb(${color4} ${color5} ${color6})`
}

function randomColorNum(){
    return Math.floor(Math.random() * 255)
}

function validateANDadd(){
    let theNewWord = document.forms["myForm"]["newWord"].value;
    let theNewNum = document.forms["myForm"]["newNumber"].value;
    theNewWord === "" ? alert("You must enter a word!") : checkNumber(theNewWord, theNewNum);
}

function checkNumber(theNewWord, theNewNum){
    (theNewNum === "1" || theNewNum === "2" || theNewNum === "3") ? addWordToList(theNewWord, theNewNum) : alert("You must enter a 1, 2, or 3!");
}

//can I add the word and palindrome bool as different columns in a table?
//for fun, can I add a button to randomly change the background color and font color?
function addWordToList(word,num){
    if(num === "1"){
        //variable to hold myList1
        let myList1 = document.querySelector("#myList1");

        myList1.appendChild(document.createElement("tr")).appendChild(document.createElement("td")).innerHTML = word;

        //find the last tr and add another td with the call to palindrome1 and pass the word
        let allRows = Array.from(myList1.rows);
        let lastRow = allRows[allRows.length-1];

        lastRow.appendChild(document.createElement("td")).innerHTML = palindrome1(word);

    }else if(num === "2"){
        //variable to hold myList1
        let myList1 = document.querySelector("#myList2");

        myList1.appendChild(document.createElement("tr")).appendChild(document.createElement("td")).innerHTML = word;

        //find the last tr and add another td with the call to palindrome1 and pass the word
        let allRows = Array.from(myList2.rows);
        let lastRow = allRows[allRows.length-1];

        lastRow.appendChild(document.createElement("td")).innerHTML = palindrome2(word);
    }else{
        //variable to hold myList1
        let myList1 = document.querySelector("#myList3");

        myList1.appendChild(document.createElement("tr")).appendChild(document.createElement("td")).innerHTML = word;

        //find the last tr and add another td with the call to palindrome1 and pass the word
        let allRows = Array.from(myList3.rows);
        let lastRow = allRows[allRows.length-1];

        lastRow.appendChild(document.createElement("td")).innerHTML = palindrome3(word);

    }
}

function palindrome1(word){
    return word.split("").reverse().join("") === word ? "true":"false";
}

function palindrome2(word){
    for(let i=0; i<Math.ceil(word.length/2); i++){
        if(word[i] === word[word.length - 1 - i]){
            continue;
        }else{
            return "false";
        }
    }
    return "true";
}

function palindrome3(word){
    return word.split("").reverse().join("").toLowerCase() === word.toLowerCase() ? "true":"false";
}

function clearList1(){
    document.querySelector("#myList1").innerHTML = "";
}

function clearList2(){
    document.querySelector("#myList2").innerHTML = "";
}

function clearList3(){
    document.querySelector("#myList3").innerHTML = "";
}