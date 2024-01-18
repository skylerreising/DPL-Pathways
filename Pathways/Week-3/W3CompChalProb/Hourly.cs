using System;

namespace payroll
{
    class Hourly : Employee
    {
        //Properties
        public double HourlyRate { get; set; }

        //default constructor
        public Hourly() : base()
        {
            HourlyRate = 20.00;
            WorkerType = "Hourly";
        }

        //constructor when all Employee values are passed
        public Hourly(string lastName, string firstName, string workerType, double hourlyRate) : base(lastName,firstName,workerType)
        {
            LastName = lastName;
            FirstName = firstName;
            WorkerType = workerType;
            HourlyRate = hourlyRate;
        }

        //Methods
        public override double CalculateBonus()
        {
            double rate = HourlyRate * 8 * 10;//8 hours in a day, 10 days in a pay period
            return Math.Round(rate,2);
        }

        public override string ToString()
        {
            //Convert CalculateBonus to a string for the return
            string bonus = CalculateBonus().ToString();

            Console.WriteLine(" ");
            return $"Employee Category: {WorkerType}\nHourly Rate: {HourlyRate}/Hour\n{FirstName} {LastName} will receive a bonus of ${bonus}\n";
        }
    }
}