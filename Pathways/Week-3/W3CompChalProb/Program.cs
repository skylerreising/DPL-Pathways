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

*/

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read Employees.json
            string json = File.ReadAllText("Employees.json");
            //Console.WriteLine(json);

            //Deserialize JSON to Array of Objects
            dynamic employeeJSON = JsonConvert.DeserializeObject<List<dynamic>>(json);
            // foreach(var employee in employeeJSON)//Had to use var instead of Employee type to see each employee in the list
            // {
            //     Console.WriteLine(employee);
            // }

            Employee[] employees = new Employee[9];
            
            for(int i=0; i<employees.Length; i++)
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
                
                //Console.WriteLine(employees[i]);
            }
            

            


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
        
        }
    }
}