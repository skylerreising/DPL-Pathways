using System;

namespace payroll
{
    abstract class Employee//Parent class to use as a template
    {
        //Properties
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string WorkerType { get; set; }

        //default constructor because children classes will use it
        public Employee()
        {
            LastName = null;
            FirstName = null;
            WorkerType = null;
        }

        //constructor when all Employee values are passed
        public Employee(string lastName, string firstName, string workerType)
        {
            LastName = lastName;
            FirstName = firstName;
            WorkerType = workerType;
        }

        //Methods
        public abstract double CalculateBonus();

        public override string ToString()
        {
            //Convert CalculateBonus to a string for the return
            string bonus = CalculateBonus().ToString();

            Console.WriteLine(" ");
            return $"Employee Category: {WorkerType}\n{FirstName} {LastName} will receive a bonus of ${bonus}";
        }
    }
}