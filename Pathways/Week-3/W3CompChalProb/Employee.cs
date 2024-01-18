using System;

namespace payroll
{
    class Employee
    {
        //Properties
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string WorkerType { get; set; } //Is this neccessary to return 0 bonus for a non-salary or non-hourly employee?

        //default constructor
        public Employee()
        {
            LastName = "LAST NAME MISSING";
            FirstName = "FIRST NAME MISSING";
            WorkerType = "EMPLOYEE TYPE NOT SPECIFIED";
        }

        //constructor when all Employee values are passed
        public Employee(string lastName, string firstName, string workerType)
        {
            LastName = lastName;
            FirstName = firstName;
            WorkerType = workerType;
        }

        //Methods
        public virtual double CalculateBonus()
        {
            return 0.00;
        }

        public override string ToString()
        {
            //Convert CalculateBonus to a string for the return
            string bonus = CalculateBonus().ToString();

            Console.WriteLine(" ");
            return $"Employee Category: {WorkerType}\n{FirstName} {LastName} will receive a bonus of ${bonus}\n";
        }
    }
}