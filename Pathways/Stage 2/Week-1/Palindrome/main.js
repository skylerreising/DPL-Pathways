document.querySelector("#addToList").addEventListener("click", validateANDadd)
document.querySelector("#clearList1").addEventListener("click", clearList1)
document.querySelector("#clearList2").addEventListener("click", clearList2)
document.querySelector("#clearList3").addEventListener("click", clearList3)


function validateANDadd(){
    let theNewWord = document.forms["myForm"]["newWord"].value;
    let theNewNum = document.forms["myForm"]["newNumber"].value;
    theNewWord === "" ? alert("You must enter a word!") : checkNumber(theNewWord, theNewNum);
}

function checkNumber(theNewWord, theNewNum){
    (theNewNum === "1" || theNewNum === "2" || theNewNum === "3") ? addWordToList(theNewWord, theNewNum) : alert("You must enter a 1, 2, or 3!");
}

//can I add the word and palindrome bool as different columns in a table?
function addWordToList(word,num){
    if(num === "1"){
        document.querySelector("#myList1").appendChild(document.createElement("tr")).innerHTML = `${word}: ${palindrome1(word)}`;
    }else if(num === "2"){
        document.querySelector("#myList2").appendChild(document.createElement("tr")).innerHTML = `${word}: ${palindrome2(word)}`;
    }else{
        document.querySelector("#myList3").appendChild(document.createElement("tr")).innerHTML = `${word}: ${palindrome3(word)}`;

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