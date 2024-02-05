using System;

namespace InterfacePractice
{
    class Employee
    {
        //Properties
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string WayToPay { get; set; }

        //Default constructor
        public Employee()
        {
            LastName = "";
            FirstName = "";
            WayToPay = "";
        }

        //Constructor when all properties are passed
        public Employee(string lastName, string firstName, string wayToPay)
        {
            LastName = lastName;
            FirstName = firstName;
            WayToPay = wayToPay;
        }

        public override string ToString()
        {
            return $"Employee: {FirstName} {LastName}\nCompensation: {WayToPay}";
        }
    }//end class
}//end namespace