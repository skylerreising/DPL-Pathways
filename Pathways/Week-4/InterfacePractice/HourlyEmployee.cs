using System;

namespace InterfacePractice
{
    class Hourly : Employee, IGetBonus, IMinimumWage
    {
        // //Field for current federal minimum wage
        // public double fedMinWage = 7.25;
        public double FedMinWage { get; set; }
        public double StateMinWage { get; set; }
        // //Field for current Nebraska minimum wage
        // public double nebMinWage = 12.00;

        //child class property
        public double HourlyRate { get; set; }

        //child class default constructor
        public Hourly(): base()
        {
            HourlyRate = GetMinWage();
        }

        //Child class constructor with all properties passed in
        public Hourly(string lastName, string firstName, string wayToPay, double hourlyRate) : base(lastName,firstName,wayToPay)
        {
            //Control to make sure hourly rate is above legal minimum wage
            HourlyRate = GetMinWage();
            HourlyRate = (hourlyRate >= HourlyRate) ? hourlyRate : HourlyRate;
        }

        //Method to get minimum wage
        public double GetMinWage()
        {
            FedMinWage = 7.25;
            StateMinWage = 12.00;
            return (FedMinWage > StateMinWage) ? FedMinWage : StateMinWage;
        }

        //Interface method
        public double GetBonus()
        {
            return HourlyRate * 80;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nHourly Rate: {HourlyRate}\nBonus: {GetBonus()}";
        }
    }
}