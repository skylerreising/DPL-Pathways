using System;

namespace payroll
{
    class Salary : Employee
    {
        //Properties
        public double AnnualSalary { get; set; }

        //default constructor
        public Salary() : base()
        {
            AnnualSalary = 100000.00;
            WorkerType = "Salary";
        }

        //constructor when all Employee values are passed
        public Salary(string lastName, string firstName, string workerType, double annualSalary) : base(lastName, firstName, workerType)
        {
            AnnualSalary = annualSalary;
        }

        //Methods
        public override double CalculateBonus()
        {
            double rate = AnnualSalary * 0.1;//8 hours in a day, 10 days in a pay period
            return Math.Round(rate, 2);
        }

        public override string ToString()
        {
            //Convert CalculateBonus to a string for the return
            string bonus = CalculateBonus().ToString();

            Console.WriteLine(" ");
            return base.ToString() + $"\nSalary: ${AnnualSalary}/Year";
        }
    }
}