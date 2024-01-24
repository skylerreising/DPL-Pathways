using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace payroll
{
    class Program
    {
        //Instanciate lists to test
        // static List<Employee> employees = new List<Employee>();
        // static List<Hourly> hourlies = new List<Hourly>();
        // static List<Salary> salaried = new List<Salary>();
        static void Main(string[] args)
        {
            //Instanciate lists to test
            List<Employee> employees = new List<Employee>();//Hourlies or Salaried
            List<Hourly> hourlies = new List<Hourly>();
            List<Salary> salaried = new List<Salary>();

            //Add an hourly employee
            employees.Add(new Hourly("Reising", "Skyler", "Hourly", 15.01));

            //Add a salary employee
            employees.Add(new Salary("Humpke", "Darcy", "Salary", 320999.99));

            //print employee list and employee count
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine(employees.Count);

            //CREATE
            //Add 2 hourlies to hourlies and 2 salaried to salaried
            hourlies.Add(new Hourly("Daake", "Olivia", "Hourly", 405));
            hourlies.Add(new Hourly("Engebretson", "Alec", "Hourly", 404));

            salaried.Add(new Salary("Yadgarova", "Malika", "Salary", 450000));
            salaried.Add(new Salary("Kodad", "Jeff", "Salary", 75000));

            //Print hourlie and salaried list
            foreach (Hourly employee in hourlies)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine(" ");
            foreach (Salary employee in salaried)
            {
                Console.WriteLine(employee);
            }

            //UPDATE - Change Olivia's hourly amount
            //Find the Olivia object using First
            Hourly olivia = hourlies.First(x => x.LastName.ToLower() == "daake" && x.FirstName.ToLower() == "olivia");//Reference because I didn't use the new keyword

            //Selection for if Olivia is found
            //update the property
            olivia.HourlyRate = 305;


            //Print hourlies to see if it worked
            foreach (Hourly employee in hourlies)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine("Enter first name to be deleted");

            string firstNameToDelete = Console.ReadLine();
            //DELETE - Delete Skyler from hourly
            // Employee employeeToDelete = employees.FirstOrDefault(x => x.FirstName == firstNameToDelete);

            // employees.Remove(employeeToDelete);

            employees.Remove(employees.First(x => x.FirstName.ToLower() == firstNameToDelete.ToLower()));

            //Print employees list
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine(employees.Count);

            Console.WriteLine(" ");
            //READ
            ReadLists(employees,hourlies,salaried);
        }

        public static void ReadLists(List<Employee> employees, List<Hourly> hourlies, List<Salary> salaried)
        {
            //READ
            //Read each employee in employees
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine(" ");

            //Read each Hourly in hourlies
            foreach (Hourly employee in hourlies)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine(" ");

            //Read each Salaried in salaried
            foreach (Salary employee in salaried)
            {
                Console.WriteLine(employee);
            }

        }
    }
}