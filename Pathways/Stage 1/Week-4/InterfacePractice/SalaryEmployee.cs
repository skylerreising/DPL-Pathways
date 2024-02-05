using System;

namespace InterfacePractice
{
    class Salary : Employee, IGetBonus
    {
        //child class property
        public double AnnualSalary { get; set; }

        //child class default constructor
        public Salary(): base()
        {
            AnnualSalary = 60000;
        }

        //Child class constructor with all properties passed in
        public Salary(string lastName, string firstName, string wayToPay, double annualSalary) : base(lastName,firstName,wayToPay)
        {
            //Control to make sure hourly rate is above legal minimum wage
            AnnualSalary = annualSalary;
        }

        //Interface method
        public double GetBonus()
        {
            return AnnualSalary * 0.1;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nSalary: {AnnualSalary}\nBonus: {GetBonus()}";
        }
    }
}