document.querySelector("#submitButton").addEventListener("click", getRepos)

async function getRepos(){
    var apiString = "https://api.github.com/users"
    var userID = document.getElementById("gitHubRepo").value;
    var userRepos = `${apiString}/${userID}/repos`;

    var response = await fetch(userRepos);

    var jsonData = await response.json();

    for(var repo in jsonData){
        console.log(jsonData[repo].html_url)
    }

    // try{
    //     let response = await fetch(userRepos);
    //     if(!response){
    //         throw new Error(`HTTP error. status: ${response.status}`)
    //     }

    //     let jsonData = await response.json().parse();
    //     console.log(jsonData);

    // }catch (error){
    //     console.error("Error fetching data: ", error);
    // }
}