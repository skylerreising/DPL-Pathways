document.querySelector("#btnAdd").addEventListener("click", validateAndadd)

function validateAndadd(): boolean {
    //place the values in the form into variables
    let min = +(<HTMLInputElement>document.getElementById("minValue")).value;
    let max = +(<HTMLInputElement>document.getElementById("maxValue")).value;
    let newNum = +(<HTMLInputElement>document.getElementById("newNumber")).value;

    // console.log(typeof(min), max, newNum)

    //validate that something was entered for minimum
    if(min === undefined || isNaN(min)){
        alert("Please enter a minimum value");
        return false;
    }

    //validate max was entered
    else if(max === undefined){
        alert("Please enter a maximum value")
        return false;
    }

    //validate max > min
    else if(max <= min){
        alert("The max value has to be larger than the min value")
        return false;
    }

    //validate something was entered for new number
    else if(newNum === undefined){
        alert("Please enter a number to be added to the scores")
        return false;
    }

    //validate new number is within the range
    else if(newNum < min || newNum > max){
        alert("Please enter a value within the given range");
        (document.querySelector("#newNumber") as HTMLInputElement).value = "";
        return false;
    }
    else{
        //alert("This all works so far!")

        //add the number to the list
        let numTable = document.getElementById("numberList") as HTMLTableElement;
        (numTable.insertRow(numTable.rows.length)).innerHTML = `<td>${newNum}</td>`;

        //calculate and display the mean
        let sum: number = 0;
        let count: number = numTable.rows.length;

        for(let i: number =0; i<count; i++){
            let grabStringWithNum: string = (numTable.rows[i]).innerHTML;
            grabStringWithNum = grabStringWithNum.replace("<td>", "")
            grabStringWithNum = grabStringWithNum.replace("</td>", "")
            let numb: number = Number(grabStringWithNum);
            sum += numb;
        }

        let mean: number = sum/count;
        let displayMean: HTMLElement = document.getElementById("theMean");
        displayMean.innerHTML = mean.toFixed(5);
    }
}