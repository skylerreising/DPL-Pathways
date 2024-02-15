let apiString = "https://www.dnd5eapi.co/api/monsters"
let monsterString = "https://www.dnd5eapi.co"

let clickedMonsterDiv = document.getElementById("seeMonster");
let clickedMonsterName = document.getElementById("monsterName");
let clickedMonsterSize = document.getElementById("monsterSize");

//this adds a monster to the end of the list
async function loadMonsters(){
    //load monster data
    let rawData = await fetch(apiString)
    let jsonData = await rawData.json()
    console.log(jsonData)

    //loop through data to populate list of monsters if the monster has an image property
    for(let i=0; i<jsonData.count; i++){
        //build url of monster
        let monURL = `${monsterString}${jsonData.results[i].url}`
        let currentMonsterData = await fetch(monURL);
        let currentMonster = await currentMonsterData.json();

        // console.log(monURL)
        if("image" in currentMonster){
        //build anchor tag that contains div and strong
        let anchor = document.createElement("a");
        anchor.data= jsonData.results[i].url;
        anchor.className = "list-group-item list-group-item-action py-3 lh-sm";

        //build div that contains strong
        let divvy = document.createElement("div");
        divvy.className = "d-flex w-100 align-items-center justify-content-between";

        //build strong
        let strong = document.createElement("strong");
        strong.className = "mb-1";
        strong.textContent = jsonData.results[i].name;

        //Package elements together
        divvy.appendChild(strong);
        anchor.appendChild(divvy);

        //add listener to anchor
        anchor.addEventListener("click", getMonster);

        //Add monster to the list
        let monsterList = document.querySelector("#monsterList");
        monsterList.appendChild(anchor);
        }
    }
}

loadMonsters();

async function getMonster(event){

    //get the url of the clicked monster
    let monsterURL = event.currentTarget.data;

    let monsterData = await fetch(monsterString + monsterURL)
    let jsonMonster = await monsterData.json()
    console.log(jsonMonster)

    //get the div's background image to the the monster's image url
    //build the image url string
    let monsterImageURL = `${monsterString}${jsonMonster.image}`;
    console.log(monsterImageURL)
    clickedMonsterDiv.style.backgroundImage = `url('${monsterImageURL}')`;

    //Enter the monster's name
    console.log(jsonMonster.name)
    clickedMonsterName.innerHTML = jsonMonster.name;
    clickedMonsterSize.innerHTML = jsonMonster.size;

    let abilities = jsonMonster.special_abilities;

    //Delete Abilities
    let existingAttributes = document.querySelectorAll(".nameDiv")
    if(existingAttributes.length >= 3){
        for(let i=2; i<existingAttributes.length; i++){
            existingAttributes[i].remove();
        }
    }

    //loop through special abilities and add them as paragraphs
    for(let i=0; i<abilities.length; i++){
        console.log(abilities[i].name, abilities[i].desc)
        
        let allThoseDivs = document.querySelectorAll(".nameDiv");
        let lastNameDiv = allThoseDivs[allThoseDivs.length - 1];

        let nameDivvy = document.createElement("div")
        nameDivvy.classList.add("nameDiv")
        
        let abilityh3 = document.createElement("h3")
        abilityh3.classList.add("pt-5", "mt-5", "mb-4", "display-6", "lh-1", "fw-bold")
        abilityh3.innerHTML = `Ability: ${abilities[i].name}`

        let abilityHolder = document.createElement("h3")
        abilityHolder.classList.add("pt-5", "mt-5", "mb-4", "display-6", "lh-1", "fw-bold")
        abilityHolder.id = abilities[i].name;
        abilityHolder.textContent = abilities[i].desc;

        nameDivvy.appendChild(abilityh3);
        nameDivvy.appendChild(abilityHolder);

        //find the last div with class nameDiv and insertAdjacentElement
        lastNameDiv.insertAdjacentElement("afterend", nameDivvy);

    }
}