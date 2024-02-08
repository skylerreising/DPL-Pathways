// type Employee = {
//     readonly id: number,
//     name: string,
//     retire: (date: Date) => void

// }

// let employee: Employee = { 
//         id: 1, 
//         name: "Skyler",
//         retire: (date: Date) => {
//             console.log(date)
//         }
//     }

// function kgToLBS(weight: number | string): number {//This is a union type, its a number or string
//     //Narrowing
//     if(typeof weight === "number"){
//         return weight * 2.2;
//     }else{
//         return parseInt(weight) * 2.2;
//     }
// }
// kgToLBS(10);
// kgToLBS("10kg");

// type Draggable = {
//     drag: () => void
// }

// type Resizable = {
//     resize: () => void
// }

// type UIWidget = Draggable & Resizable;// intersection type

// let textBox: UIWidget = {
//     drag: () => {},
//     resize: () => {}
// }

// type Quantity = 50 | 100;
// let quantity: Quantity = 100;//literal (exact, specific)

// type Metric = "cm" | "inch";

// function greet(name: string | null | undefined){
//     if(name)
//     console.log(name.toUpperCase());
//     else
//     console.log("Hola")
// }

// greet(undefined);

