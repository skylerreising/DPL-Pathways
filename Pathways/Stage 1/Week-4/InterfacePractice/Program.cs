using System;

namespace InterfacePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of employees
            List<Employee> listOfEmployees = new List<Employee>();

            // Add a couple of employees to the list to test
            listOfEmployees.Add(new Employee("Schmoe", "Joe", "other"));
            listOfEmployees.Add(new Employee("Stein", "Robert", "other"));

            // Add a couple of hourly employees to the list to test
            listOfEmployees.Add(new Hourly("Reising", "Dude1", "Hourly", 30));
            listOfEmployees.Add(new Hourly("Reising", "Dude2", "Hourly", 32));

            // Add a couple of salary employees to the list to test
            listOfEmployees.Add(new Salary("Reising", "Dude3", "Salary", 50000));
            listOfEmployees.Add(new Salary("Reising", "Dude4", "Salary", 55000));

            // Print the list
            // foreach(Employee person in listOfEmployees)
            // {
            //     Console.WriteLine(person);
            // }

            // Experiment with Reading (finding) an employee(s) in the list
            //======================================================================
            Console.Write("Please enter an employee LAST NAME to find: ");
            string userEmployeeFind = Console.ReadLine();
            bool found = false;
            for(int i=0; i<listOfEmployees.Count; i++)
            {
                if(userEmployeeFind == listOfEmployees[i].LastName)
                {
                    Console.WriteLine($"Found {listOfEmployees[i]}!");
                    found = true;
                    break;
                }
            }

            if(!found)
            {
                Console.WriteLine($"Could not find an employee with the last name {userEmployeeFind}");
            }

            // Experiment with Creating (adding) an employee to the list
            //======================================================================
            Console.Write("Please enter an employee last name to add: ");
            string newLastName = Console.ReadLine();
            Console.Write("Please enter an employee first name to add: ");
            string newFirstName = Console.ReadLine();
            Console.Write("Please enter an employee type to add (Salary or Hourly): ");
            string newEmployeeType = Console.ReadLine();

            if(newEmployeeType == "Salary")
            {
                Console.Write("Please enter an annual salary for your new employee: ");
                double newSalary = Convert.ToDouble(Console.ReadLine());
                listOfEmployees.Add(new Salary(newLastName,newFirstName,newEmployeeType,newSalary));
            }else if(newEmployeeType == "Hourly")
            {
                Console.Write("Please enter an hourly rate for your new employee: ");
                double newHourly = Convert.ToDouble(Console.ReadLine());
                listOfEmployees.Add(new Salary(newLastName,newFirstName,newEmployeeType,newHourly));
            }else
            {
                listOfEmployees.Add(new Employee(newLastName,newFirstName,"other"));
            }

            // print the list again
            foreach(Employee person in listOfEmployees)
            {
                Console.WriteLine(person);
            }

            // Experiment with deleting an employee in the list
            //======================================================================

            // print the list again

            // Experiment with updating an employee's hourly rate or salary in the list
            //======================================================================
        }
    }
}