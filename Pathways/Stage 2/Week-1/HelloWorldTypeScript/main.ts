function myFunction() {
    let newName: string = " ";
    let age: number = 0;
    newName = (<HTMLInputElement>document.getElementById("fname")).value;
    age = Number((<HTMLInputElement>document.getElementById("age")).value);
    console.log(newName, age);
    document.getElementById("greeting")!.innerHTML = "More and more splendid greetings " + newName + " age: "+ age +" !!";
}