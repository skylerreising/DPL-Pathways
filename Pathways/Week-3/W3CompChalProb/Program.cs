/*
Problem description: Your client needs a way to calculate bonuses for their employees.

Requirements/User stories:

Each employee will have a last name, first name and employee type (hourly or salary).
An hourly employee will have an hourly rate. 
A salary employee will have an annual salary.
Bonuses are calculated as followed:
If not hourly or salary, the bonus is 0.
Hourly, the bonus is two weeks pay (40 hours per week)
Salary, the bonus is 10%
You want a menu that will provide you the options of doing the following:
L - Load the single text file into the program.  The text file stores four lines for each employee including last name, first name, employee type and hourly rate or salary (depending on employee type - H or S)
S - Store the current employee information in the text file
C - Add an employee
R - Print a list of all the employees including their calculated bonus,
U - Update information for an employee,
D - Delete an employee
Q - Quit the program
We will discuss your class design before you start, but it will include encapsulation, inheritance, and polymorphism.  Classes will include:
Employee (last name, first name, employee type; constructors, calculate bonus, toString)
HourlyEmployee (hourly rate; constructors, calculate bonus, toString)
SalaryEmployee (annual salary; constructors, calculate bonus, toString
Be sure to follow best programming practices (no code smell!)

Steps:
(1) Create classes (DONE)
(2) Test classes (DONE)
(3) Create LSQ & CRUD
(4) Create menu
    //do
    //Display menu for the user
        //Save user's choice in a variable
        //if and else if statements for the user's choice
    //While the user hasn't chosen quit
(5) Create load
    //Read Employees.json
    //Deserialize JSON to dynamic list then to an array of objects
    //instantiate Employee array
    //loop to assign objects to the array
    //Print names of the employees that were loaded
(6) Create read
    //Control for if array isn't loaded
    //loop through employees array and display them in the console
(7) Create update
    //Control for if array isn't loaded (HEY, THIS COULD BE A METHOD!)
    //Print names of the employees that were loaded
    //Ask the user which employee they would like to update and save that to a variable
        //Ask user for first name and last name
        //Parse first and last name
        //Use first and last name to find the employee
        //if not found, ask for the employee name again
    //Ask what they would like to update for that employee?
        //First Name?
        //Last Name? 
        //Hourly, Salary, or Other?
            //if Hourly, what per hour?
            //if Salary, what salary
            //if Other, delete HourlyRate or SalaryRate
(8) Create delete
    //Control for if array isn't loaded
    //Ask the user which employee they would like to delete and save that to a variable
        //Ask user for first name and last name
        //Parse first and last name
        //Use first and last name to find the employee
        //if not found, ask for the employee name again
    //Make sure to add default constructor/object after deletion
(9) Create create
    //Control for if array isn't loaded
    //Control for if there isn't room in the array to store a new employee
    //Loop through employees array and find a default employee object to write over
    //Ask what kind of worker type employee they want to create?
        //Hourly, Salary, or Other?
            //Instantiate class at that index for that worker type
        //First Name?
        //Last Name? 
        //Hourly, Salary, or Other?
            //if Hourly, what per hour?
            //if Salary, what salary

(10) Create save
    Control for if array isn't loaded
    //Read employees array
    //convert the array to a JSON string
    //Write the string to the Employees.json file

*/

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Quic;

namespace payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            string userChoice;
            bool load = false;
            bool create = false;
            bool read = false;
            bool update = false;
            bool delete = false;
            bool save = false;
            bool quit = false;
            bool dataLoaded = false;
            string fileName = "Employees.json";
            string updateEmployee;
            bool roomForEmployee = false;

            //instantiate array
            Employee[] employees = new Employee[9];

            for(int i=0; i<employees.Length; i++)
            {
                employees[i] = new Employee();
            }

            do
            {
                //Display menu for the user
                Console.WriteLine(" ");
                Console.WriteLine("Please choose an option from the menu below:");
                Console.WriteLine("To load your employees, please type L or Load and hit enter.");
                Console.WriteLine("To create an employee, please type C or Create and hit enter.");
                Console.WriteLine("To see a list of your employees, please type R or Read and hit enter.");
                Console.WriteLine("To update an employee's record, please type U or Update and hit enter.");
                Console.WriteLine("To delete an employee, please type D or Delete and hit enter.");
                Console.WriteLine("To save your changes, please type S or Save and hit enter.");
                Console.WriteLine("To quit this application, please type Q or Quit and hit enter.");
                Console.WriteLine(" ");

                //Save user's choice in a variable
                userChoice = Console.ReadLine();

                //changing the flag
                if(userChoice.ToLower() == "l" || userChoice.ToLower() == "load")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("The user choose LOAD");
                    Console.WriteLine(" ");
                    load = true;
                }else if(userChoice.ToLower() == "c" || userChoice.ToLower() == "create")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("The user choose CREATE");
                    Console.WriteLine(" ");
                    create = true;
                }
                else if(userChoice.ToLower() == "r" || userChoice.ToLower() == "read")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("The user choose READ");
                    Console.WriteLine(" ");
                    read = true;
                }
                else if(userChoice.ToLower() == "u" || userChoice.ToLower() == "update")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("The user choose UPDATE");
                    Console.WriteLine(" ");
                    update = true;
                }
                else if(userChoice.ToLower() == "d" || userChoice.ToLower() == "delete")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("The user choose DELETE");
                    Console.WriteLine(" ");
                    delete = true;
                }
                else if(userChoice.ToLower() == "s" || userChoice.ToLower() == "save")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("The user choose SAVE");
                    Console.WriteLine(" ");
                    save = true;
                }
                else if(userChoice.ToLower() == "q" || userChoice.ToLower() == "quit")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("The user choose QUIT");
                    Console.WriteLine(" ");
                    quit = true;
                }
                else
                {
                    //Control for valid menu entry
                    Console.WriteLine(" ");
                    Console.WriteLine("Invalid menu choice. Please choose a valid menu option.");
                    Console.WriteLine(" ");
                }

                //Start of CRUD, Load, and Save if & else if statments
                if(load)
                {
                    //Read Employees.json
                    string json = File.ReadAllText(fileName);

                    //Deserialize JSON to Array of Objects
                    dynamic employeeJSON = JsonConvert.DeserializeObject<List<dynamic>>(json);
                    // foreach(var employee in employeeJSON)//Had to use var instead of Employee type to see each employee in the list
                    // {
                    //     Console.WriteLine(employee);
                    // }
                    
                    //loop to assign objects to the array
                    for(int i=0; i<employeeJSON.Count; i++)
                    {
                        //had to declare types of these variables due to the use of dynamic list
                        string lastName = employeeJSON[i].LastName;
                        string firstName = employeeJSON[i].FirstName;
                        string workerType = employeeJSON[i].WorkerType;

                        if(employeeJSON[i].WorkerType == "Hourly")
                        {
                            double hourlyRate = Convert.ToDouble(employeeJSON[i].HourlyRate);//had to declare types of these variables due to the use of dynamic list
                            employees[i] = new Hourly(lastName,firstName,workerType,hourlyRate);
                        }
                        else if(employeeJSON[i].WorkerType == "Salary")
                        {
                            double annualSalary = Convert.ToDouble(employeeJSON[i].AnnualSalary);//had to declare types of these variables due to the use of dynamic list
                            employees[i] = new Salary(lastName,firstName,workerType,annualSalary);
                        }else
                        {
                            employees[i] = new Employee(lastName,firstName,workerType);
                        }
                    }
                
                    //Print the names of the employees that were loaded.
                    Console.WriteLine(" ");
                    Console.WriteLine("Your employees were loaded.");
                    Console.WriteLine(" ");

                    load = false;
                    dataLoaded = true;
                }
                else if(save)
                {
                    if(CheckLoad(dataLoaded))
                    {
                        //Read employees array
                        //convert the array to a JSON string
                        string newJSON = JsonConvert.SerializeObject(employees, Formatting.Indented);

                        //Write the string to the Employees.json file
                        File.WriteAllText("Employees.json", newJSON);
                        save = false;
                    }else
                    {
                        //Tell user their data isn't loaded
                        Console.WriteLine(" ");
                        Console.WriteLine("Your employees were not saved. Please load your employees first.");
                        Console.WriteLine(" ");
                        save = false;
                    }
                }
                else if(create)
                {
                    //Control for if there isn't room in the array to store a new employee
                    //if there is room, grab index of default Employee object where new one will be created
                    updateEmployee = null;
                    int openIndex = -1;
                    for (int i=0; i<employees.Length; i++)
                    {
                        if(employees[i].LastName == null)
                        {
                            openIndex = i;
                            roomForEmployee = true;
                            break;
                        }
                    }

                    //Control for if array isn't loaded and no room
                    if(CheckLoad(dataLoaded) && roomForEmployee)
                    {
                        string newValue = " ";
                        string updateChoice = " ";
                        do
                        {
                            //Ask what kind of worker type employee they want to create?
                            //Hourly, Salary, or Other?
                            Console.WriteLine(" ");
                            Console.WriteLine($"What kind of worker type would you like to create?");
                            Console.WriteLine("Options:");
                            Console.WriteLine("Hourly");
                            Console.WriteLine("Salary");
                            Console.WriteLine("Other");
                            Console.WriteLine(" ");
                            updateChoice = Console.ReadLine();

                            //Instantiate class at that index for that worker type
                            //ifs for updateChoice
                            if(updateChoice.ToLower() == "hourly")
                            {
                                employees[openIndex] = new Hourly();

                                Console.WriteLine(" ");
                                Console.WriteLine("Please enter a first name.");
                                Console.WriteLine("");

                                newValue = Console.ReadLine();
                                employees[openIndex].FirstName = newValue;

                                Console.WriteLine(" ");
                                Console.WriteLine("Please enter a last name.");
                                Console.WriteLine("");

                                newValue = Console.ReadLine();
                                employees[openIndex].LastName = newValue;

                                Console.WriteLine(" ");
                                Console.WriteLine("Please enter their hourly rate.");
                                Console.WriteLine("");

                                newValue = Console.ReadLine();
                                ((Hourly)employees[openIndex]).HourlyRate = Convert.ToDouble(newValue);  

                                Console.WriteLine(" ");
                                Console.WriteLine("Here is your new employee");
                                Console.WriteLine(employees[openIndex]);
                                Console.WriteLine("");
                                
                                roomForEmployee = false;
                                openIndex = -1;
                                newValue = " ";
                                create = false;
                                break;
                            }else if(updateChoice.ToLower() == "salary")
                            {
                                employees[openIndex] = new Salary();

                                Console.WriteLine(" ");
                                Console.WriteLine("Please enter a first name.");
                                Console.WriteLine("");

                                newValue = Console.ReadLine();
                                employees[openIndex].FirstName = newValue;

                                Console.WriteLine(" ");
                                Console.WriteLine("Please enter a last name.");
                                Console.WriteLine("");

                                newValue = Console.ReadLine();
                                employees[openIndex].LastName = newValue;

                                Console.WriteLine(" ");
                                Console.WriteLine("Please enter their salary.");
                                Console.WriteLine("");

                                newValue = Console.ReadLine();
                                ((Salary)employees[openIndex]).AnnualSalary = Convert.ToDouble(newValue);  

                                Console.WriteLine(" ");
                                Console.WriteLine("Here is your new employee");
                                Console.WriteLine(employees[openIndex]);
                                Console.WriteLine("");
                                
                                roomForEmployee = false;
                                openIndex = -1;
                                newValue = " ";
                                create = false;
                                break;
                            }else if(updateChoice.ToLower() == "other")
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Please enter a first name.");
                                Console.WriteLine("");

                                newValue = Console.ReadLine();
                                employees[openIndex].FirstName = newValue;

                                Console.WriteLine(" ");
                                Console.WriteLine("Please enter a last name.");
                                Console.WriteLine("");

                                newValue = Console.ReadLine();
                                employees[openIndex].LastName = newValue;

                                Console.WriteLine(" ");
                                Console.WriteLine("Here is your new employee");
                                Console.WriteLine(employees[openIndex]);
                                Console.WriteLine("");
                                
                                roomForEmployee = false;
                                openIndex = -1;
                                newValue = " ";
                                create = false;
                                break;
                            }
                            //The user didn't choose an available option. Prompt to try again
                            Console.WriteLine(" ");
                            Console.WriteLine("Choose an available option. Please check your spelling and try again.");
                            Console.WriteLine(" ");
                        }while(updateChoice.ToLower() != "hourly" &&
                                updateChoice.ToLower() != "salary" &&
                                updateChoice.ToLower() != "other");                      
                    }
                    //There is no room or they haven't loaded the array. 
                    if(create)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("You either haven't loaded your employees or there is no room to create a new employee. Please either load your employees or delete an employee, or both, before trying again.");
                        Console.WriteLine(" ");
                        create = false;
                    }
                }
                else if(read)//loop through employees array and display them in the console
                {
                    //Control for if array isn't loaded
                    if(CheckLoad(dataLoaded))
                    {
                        foreach (Employee employee in employees)//print each employee to the console
                        {
                            if(!(employee.LastName == null))
                                Console.WriteLine(employee);
                        }
                    }

                    read = false;
                }
                else if(update)
                {
                    //Control for if array isn't loaded
                    if(CheckLoad(dataLoaded))
                    {
                        foreach (Employee employee in employees)//print each employee to the console
                        {
                            Console.WriteLine($"{employee.FirstName} {employee.LastName}");
                        }
                        //Ask the user which employee they would like to update and save that to a variable
                        Console.WriteLine(" ");
                        //Ask user for first name and last name
                        Console.WriteLine("Which employee would you like to update? Please enter their first and last names only.");
                        Console.WriteLine(" ");
                        updateEmployee = null;
                        updateEmployee = Console.ReadLine();

                        //Parse first and last name
                        string[] names = updateEmployee.Split(" ");

                        //loop through employees array and check that first and last names match the same object in the employees array
                        if(names.Length == 2)
                        {
                            for(int i=0; i<employees.Length; i++)
                            {
                                if(employees[i] != null && names[0] != null && names[1] != null &&
                                    names[0].ToLower() == employees[i].FirstName?.ToLower() && names[1].ToLower() == employees[i].LastName?.ToLower())//Use first and last name to find the employee
                                {
                                    string newValue = " ";
                                    string hourlySalaryOrOther = " ";
                                    string updateChoice = " ";
                                    do
                                    {
                                        //Ask what they would like to update for that employee?
                                        Console.WriteLine(" ");
                                        Console.WriteLine($"What would you like to update about {employees[i].FirstName} {employees[i].LastName}?");
                                        Console.WriteLine("Options:");
                                        Console.WriteLine("First Name");
                                        Console.WriteLine("Last Name");
                                        Console.WriteLine("Worker Type");
                                        Console.WriteLine(" ");
                                        updateChoice = Console.ReadLine();

                                        //ifs for updateChoice
                                        if(updateChoice.ToLower() == "first name")
                                        {
                                            Console.WriteLine(" ");
                                            Console.WriteLine($"What would you like to update {employees[i].FirstName} to?");
                                            Console.WriteLine("");

                                            newValue = Console.ReadLine();
                                            employees[i].FirstName = newValue;

                                            Console.WriteLine(" ");
                                            Console.WriteLine($"Their first name has been updated to {employees[i].FirstName}.");
                                            Console.WriteLine("");
                                            update = false;
                                            break;
                                        }else if(updateChoice.ToLower() == "last name")
                                        {
                                            Console.WriteLine(" ");
                                            Console.WriteLine($"What would you like to update {employees[i].LastName} to?");
                                            Console.WriteLine("");

                                            newValue = Console.ReadLine();
                                            employees[i].LastName = newValue;

                                            Console.WriteLine(" ");
                                            Console.WriteLine($"Their last name has been updated to {employees[i].LastName}.");
                                            Console.WriteLine("");
                                            update = false;
                                            break;
                                        }else if(updateChoice.ToLower() == "worker type")
                                        {
                                            do
                                            {
                                                //Hourly, Salary, or Other?
                                                Console.WriteLine(" ");
                                                Console.WriteLine($"Would you like to update {employees[i].FirstName} {employees[i].LastName} to hourly, salary, or other?");
                                                Console.WriteLine("");

                                                hourlySalaryOrOther = Console.ReadLine();

                                                if(hourlySalaryOrOther.ToLower() == "hourly")
                                                {
                                                    Console.WriteLine(" ");
                                                    Console.WriteLine($"What would you like to update {employees[i].FirstName}'s hourly rate to?");
                                                    Console.WriteLine("");

                                                    double newHourly = Convert.ToDouble(Console.ReadLine());
                                                    //turn this employee into a new hourly employee with newHourly HourlyRate
                                                    Hourly newHourlyEmployee = new Hourly(employees[i].LastName, employees[i].FirstName, "Hourly", newHourly);
                                                    employees[i] = newHourlyEmployee;

                                                    Console.WriteLine(" ");
                                                    Console.WriteLine("Here are your changes for this employee:");
                                                    Console.WriteLine(employees[i]);
                                                    Console.WriteLine("");
                                                    update = false;
                                                }else if(hourlySalaryOrOther.ToLower() == "salary")
                                                {
                                                    Console.WriteLine(" ");
                                                    Console.WriteLine($"What would you like to update {employees[i].FirstName}'s salary to?");
                                                    Console.WriteLine("");

                                                    double newSalary = Convert.ToDouble(Console.ReadLine());
                                                    //turn this employee into a new salary employee with newSalary Salary
                                                    Salary newSalaryEmployee = new Salary(employees[i].LastName, employees[i].FirstName, "Salary", newSalary);
                                                    employees[i] = newSalaryEmployee;

                                                    Console.WriteLine(" ");
                                                    Console.WriteLine("Here are your changes for this employee:");
                                                    Console.WriteLine(employees[i]);
                                                    Console.WriteLine("");
                                                    update = false;
                                                }else if(hourlySalaryOrOther.ToLower() == "other")
                                                {
                                                    //turn this employee into a new Employee employee
                                                    Employee newEmployee = new Employee(employees[i].LastName, employees[i].FirstName, "Other");
                                                    employees[i] = newEmployee;

                                                    Console.WriteLine(" ");
                                                    Console.WriteLine("Here are your changes for this employee:");
                                                    Console.WriteLine(employees[i]);
                                                    Console.WriteLine("");
                                                    update = false;
                                                }
                                            }while(hourlySalaryOrOther.ToLower() != "hourly" &&
                                                    hourlySalaryOrOther.ToLower() != "salary" &&
                                                    hourlySalaryOrOther.ToLower() != "other");
                                        }
                                        //The user didn't choose an available option. Prompt to try again
                                        // Console.WriteLine(" ");
                                        // Console.WriteLine("Choose an available option. Please check your spelling and try again.");
                                        // Console.WriteLine(" ");
                                    }while(updateChoice.ToLower() != "first name" &&
                                            updateChoice.ToLower() != "last name" &&
                                            updateChoice.ToLower() != "worker type");
                                    break;
                                }
                            }                          
                        }
                        //The user spelled the name incorrectly. Ask them to choose update and try again
                            if(update)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("The name was spelled incorrectly. Please check your spelling and try again.");
                                Console.WriteLine(" ");
                                update = false;
                            }
                    }                   
                }
                else if(delete)
                {
                    //Control for if array isn't loaded
                    if(CheckLoad(dataLoaded))
                    {
                        foreach (Employee employee in employees)//print each employee to the console
                        {
                            Console.WriteLine($"{employee.FirstName} {employee.LastName}");
                        }
                        //Ask the user which employee they would like to delete and save that to a variable
                        Console.WriteLine(" ");
                        //Ask user for first name and last name
                        Console.WriteLine("Which employee would you like to delete? Please enter their first and last names only.");
                        Console.WriteLine(" ");
                        updateEmployee = null;
                        updateEmployee = Console.ReadLine();

                        //Parse first and last name
                        string[] names = updateEmployee.Split(" ");

                        //loop through employees array and check that first and last names match the same object in the employees array
                        if(names.Length == 2)
                        {
                            for(int i=0; i<employees.Length; i++)
                            {
                                if(employees[i] != null && names[0] != null && names[1] != null &&
                                    names[0].ToLower() == employees[i].FirstName?.ToLower() && names[1].ToLower() == employees[i].LastName?.ToLower())//Use first and last name to find the employee
                                {
                                    //delete the employee
                                    //Make sure to add default constructor/object after deletion
                                    employees[i] = new Employee();

                                    Console.WriteLine(" ");
                                    Console.WriteLine($"{updateEmployee} was deleted.");
                                    Console.WriteLine("");

                                    delete = false;
                                    break;
                                }
                            }
                        }
                        //if not found, ask for the employee name again
                        if(delete)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("The name was spelled incorrectly. Please check your spelling and try again.");
                            Console.WriteLine(" ");
                            delete = false;
                        }
                    }
                }
            }while(!quit);

            


        // // Declare and instantiate a single parent object using the default constructor
        // Employee testGuy = new();

        // // Output to show the default constructor values
        // Console.WriteLine(testGuy);

        // // Declare and instantiate a single parent object using the other constructor
        // Employee testGuy2 = new Employee("Guy2", "Test", "Other");

        // // Output to show the default constructor values
        // Console.WriteLine(testGuy2);

        // // Declare and instantiate the array of parent objects
        // Employee[] employees = new Employee[3];

        // // Now, loop through each array element and instantiate a parent object for each.
        // // Note that the constructor with no parameters will be used.
        // for(int i=0; i<employees.Length; i++)
        // {   
        //     employees[i] = new Employee("Guy3", "Test", "Other");
        //     Console.WriteLine(employees[i]);
        // }
        // // Load in some test data to test both ways to assign values
        // employees[0].LastName = "Reising";
        // employees[1].FirstName = "Logan";
        // employees[2].WorkerType = "Very Hard Worker";

        // // print each parent object to test the property gets the toString
        // for(int i=0; i<employees.Length; i++)
        // {   
        //     Console.WriteLine(employees[i]);
        // }




        // Declare and instantiate a single child object using the default constructor
        // Hourly testGirl = new();

        // // Output to show the default constructor values
        // Console.WriteLine(testGirl);

        // // Declare and instantiate a single child object using the other constructor
        // Hourly testGirl2 = new Hourly("Girl2", "Test", "Hourly", 50.00);

        // // Output to show the default constructor values
        // Console.WriteLine(testGirl2);

        // // Declare and instantiate the array of child objects
        // Hourly[] testGirlies = new Hourly[3];

        // // Now, loop through each array element and instantiate a child object for each.
        // // Note that the constructor with no parameters will be used.
        // for(int i=0; i<testGirlies.Length; i++)
        // {
        //     testGirlies[i] = new Hourly("Girl3", "Test", "Hourly", 100.00);
        //     Console.WriteLine(testGirlies[i]);
        // }

        // // Load in some test data to test both ways to assign values
        // testGirlies[0].LastName = "Smith";
        // testGirlies[1].FirstName = "Jane";
        // testGirlies[2].WorkerType = "Average Worker";
        // testGirlies[0].HourlyRate = 450.54;


        // // print each child object to test the property gets the toString
        // for(int i=0; i<testGirlies.Length; i++)
        // {
        //     Console.WriteLine(testGirlies[i]);
        // }



        // // Declare and instantiate a single child object using the default constructor
        // Salary testPerson = new();

        // // Output to show the default constructor values
        // Console.WriteLine(testPerson);

        // // Declare and instantiate a single child object using the other constructor
        // Salary testPerson2 = new Salary("Person2", "Test", "Salary", 150000);

        // // Output to show the default constructor values
        // Console.WriteLine(testPerson2);

        // // Declare and instantiate the array of child objects
        // Salary[] testPeople = new Salary[3];

        // // Now, loop through each array element and instantiate a child object for each.
        // // Note that the constructor with no parameters will be used.
        // for(int i=0; i<testPeople.Length; i++)
        // {
        //     testPeople[i] = new Salary("Person3", "Testo", "Salary", 40000);
        //     Console.WriteLine(testPeople[i]);
        // }

        // // Load in some test data to test both ways to assign values
        // testPeople[0].AnnualSalary = 200000;
        // Console.WriteLine(testPeople[0]);

        // // print each child object to test the property gets the toString
        // for(int i=0; i<testPeople.Length; i++)
        // {
        //     Console.WriteLine(testPeople[i]);
        // }
        
        }//End of Main

        public static bool CheckLoad(bool dataLoaded)
        {
            if(!dataLoaded)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please load your data before reading it. Choose \"L\" or \"Load\".\n");
                Console.WriteLine(" ");
                return false;
            }
            else
            {
                return true;
            }
        }
    }//End of Class Program
}//End of namespace payroll