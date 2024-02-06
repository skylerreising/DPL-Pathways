function validateANDadd(){
    //find new word and if its empty, alert
    let theNewWord = document.forms["myForm"]["newWord"].value;

    theNewWord === "" ? alert("You must enter a word!") : getNewNumber(theNewWord);
}

function getNewNumber(theNewWord){
    let theNewNum = document.forms["myForm"]["newNumber"].value;

    (theNewNum === "1" || theNewNum === "2") ? addWordToList(theNewWord, theNewNum) : alert("You must enter a 1 or 2!");
}

function addWordToList(word,num){
    if(num === "1"){
        document.querySelector("#myList1").appendChild(document.createElement("tr")).innerHTML = word;
    }else{
        document.querySelector("#myList2").appendChild(document.createElement("tr")).innerHTML = word;
    }
}

function clearList1(){
    //get the list
    //set the inner html to nothing
    document.querySelector("#myList1").innerHTML = "";
}

function clearList2(){
    //get the list
    //set the inner html to nothing
    document.querySelector("#myList2").innerHTML = "";
}

//from Alec
//var theNewWord = document.forms["myForm"]["newWord"].value;
//Alec's hit is how do you "insertRow"