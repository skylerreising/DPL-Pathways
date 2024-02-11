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
        let data: number[] = [];

        for(let i: number =0; i<count; i++){
            let grabStringWithNum: string = (numTable.rows[i]).innerHTML;
            grabStringWithNum = grabStringWithNum.replace("<td>", "")
            grabStringWithNum = grabStringWithNum.replace("</td>", "")
            let numb: number = Number(grabStringWithNum);
            data.push(numb);//for the median and mode
            sum += numb;
        }

        let mean: number = sum/count;
        let displayMean: HTMLElement = document.getElementById("theMean");
        displayMean.innerHTML = mean.toFixed(5);

        //calculate and display the median
        //sort the data smallest to largest
        data.sort((a,b) => a-b);

        //if total is odd, median is the middle data point
        let median: number = 0;
        if(count % 2 === 1){
            median = data[Math.floor(data.length/2)];
            // console.log(median);
        }else{//if total is even, median is the average of the two middle data points
            median = ((data[(data.length/2)-1])+(data[(data.length/2)]))/2;
            // console.log(median);
        }

        let displayMedian: HTMLElement = document.getElementById("theMedian");
        displayMedian.innerHTML = median.toFixed(5);
        
        //calculate and dipslay the mode
        //loop through data to find the mode
        //declare mode count and mode
        let mode: number[] = [data[0]];
        let maxCount: number = 0;//count of each number
        let modeCount: number = 0//highest count so far
        let numBeingChecked: number = undefined;//current number being checked

        for(let i: number=0; i<data.length; i++){
            if(data[i] === mode[0]){
                modeCount++
                maxCount++
            }else if(numBeingChecked === undefined){
                numBeingChecked = data[i]
                maxCount = 1;
            }else if(data[i] === numBeingChecked){
                maxCount++
                if(maxCount > modeCount){
                    mode = [data[i]];
                    modeCount = maxCount;
                }else if(maxCount === modeCount){
                    mode.push(data[i]);
                    modeCount = maxCount;
                }
            }else{
                numBeingChecked = data[i]
                maxCount = 1;
            }
        }

        //console.log(mode,numBeingChecked)
        //display the mode
        let displayMode: HTMLElement = document.getElementById("theMode");
        displayMode.innerHTML = "";
        mode.forEach(x => displayMode.innerHTML += x.toString()+" ");
    }
}