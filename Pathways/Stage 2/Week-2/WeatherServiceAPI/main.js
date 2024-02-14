document.querySelector("#forecastButton").addEventListener("click", getForecast);

async function getForecast(){
    console.log("this button works");

    const forecastURL = "https://api.weather.gov/gridpoints/OAX/57,40/forecast";
    let forecastData = await fetch(forecastURL)

    forecastData = await forecastData.json();

    let forecastPeriods = forecastData.properties.periods;

    console.log(forecastPeriods)

    let timePeriod = forecastPeriods[0].name;
    let forecast = forecastPeriods[0].detailedForecast;

    console.log(timePeriod , forecast)

    //Add icon, timePeriod, and forecast into the dom
    //count for replication
    let count = forecastPeriods.length;

    for(let i=0; i<count; i++){
        //create the outer div with feature and col classes
        let featureColDiv = document.createElement("div");
        featureColDiv.classList.add("feature", "col");

        //create icon div
        let iconDiv = document.createElement("div");
        iconDiv.classList.add("feature-icon", "d-inline-flex", "align-items-center", "justify-content-center", "text-bg-primary", "bg-gradient", "fs-2", "mb-3");

        //grab icon for this time period
        let icon = forecastPeriods[i].icon;

        //create img
        let imgElement = document.createElement("img");
        imgElement.setAttribute("src", icon);

        //add img to iconDiv
        iconDiv.appendChild(imgElement);

        //grab the time
        let timeOfForecast = forecastPeriods[i].name;

        //create h3
        let h3El = document.createElement("h3");
        h3El.classList.add("fs-2", "text-body-emphasis");
        h3El.textContent  = timeOfForecast

        //grab forecast
        let theForecast = forecastPeriods[i].detailedForecast;

        //create paragraph
        let pEl = document.createElement("p");
        pEl.textContent = theForecast;

        //Add each element to the outer div
        featureColDiv.appendChild(iconDiv);
        featureColDiv.appendChild(h3El);
        featureColDiv.appendChild(pEl);

        //target the last div
        let allFeatureColDivs = document.querySelectorAll(".feature.col");
        let lastDiv = allFeatureColDivs[allFeatureColDivs.length - 1];

        //Insert new div after last div
        lastDiv.insertAdjacentElement("afterend", featureColDiv);
    }
}