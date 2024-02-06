document.querySelector("#addToList").addEventListener("click", validateANDadd)
document.querySelector("#clearList1").addEventListener("click", clearList1)
document.querySelector("#clearList2").addEventListener("click", clearList2)

function validateANDadd(){
    let theNewWord = document.forms["myForm"]["newWord"].value;
    let theNewNum = document.forms["myForm"]["newNumber"].value;
    theNewWord === "" ? alert("You must enter a word!") : checkNumber(theNewWord, theNewNum);
}

function checkNumber(theNewWord, theNewNum){
    (theNewNum === "1" || theNewNum === "2") ? addWordToList(theNewWord, theNewNum) : alert("You must enter a 1 or 2!");
}

function addWordToList(word,num){
    if(num === "1"){
        document.querySelector("#myList1").appendChild(document.createElement("tr")).innerHTML = `${word}: ${palindrome1(word)}`;
    }else{
        document.querySelector("#myList2").appendChild(document.createElement("tr")).innerHTML = `${word}: ${palindrome2(word)}`;
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

function clearList1(){
    document.querySelector("#myList1").innerHTML = "";
}

function clearList2(){
    document.querySelector("#myList2").innerHTML = "";
}