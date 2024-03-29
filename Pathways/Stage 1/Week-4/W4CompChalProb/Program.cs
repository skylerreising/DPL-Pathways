/*

Create an application with an OOP design to help manage bank accounts. 

Three types of accounts need to be handled - a savings account, a checking account, and a CD account. 
All three types of accounts have common information including an account id, the type of account, and current balance. 
In addition, the savings account has an annual interest rate, the checking account has an annual fee, and the CD has an annual interest rate and a penalty for early withdrawal.
Two types of transactions need to be handled:
Deposit - A deposit will include the account id and the amount of the deposit (which must be > 0).   All three accounts handle a deposit the same way.  If the account exists, the balance is increased by the deposit amount.
Withdrawal - A withdrawal will include the account id and the amount of the withdrawal (which must be > 0).  Withdrawals are handled differently depending on the account type.
A savings account withdrawal is allowed as long as the account balance is greater than the withdrawal amount.
A checking account withdrawal is allowed but only up to 50% of the account balance.
A CD withdrawal is allowed but the early withdrawal penalty is applied so the balance needs to be greater than the withdrawal amount and the penalty combined.
Technical specifications for your application include:
Create an abstract class for an account.  Account id, balance and type are to be properties.  In addition to the constructors, include a deposit method, an abstract withdrawal method, and a useful toString.
Create three classes that inherit from the account class - one each for savings, checkings and CDs.  Create properties for the respective data attributes, implement the withdrawal method for each as appropriate, and override the toString as appropriate.
In addition, the savings and CD will implement a calculate annual interest method from an interface that will simply return the annual amount earned based on the current balance and interest rate.  Don't add this amount to the balance, but do report it on the toString for a saving or CD account.
Create and test your classes and methods with hard-coded test data so that there is a list of accounts of different types with different balances.
Then, provide the user the following options:
L - List all of the accounts in the list including the account id, balance, and account type and also as appropriate the interest rate, annual fee, and early penalty, and finally for interest-bearing accounts, the amount of annual interest given the current balance and interest rate
D - Perform a deposit transaction by getting an account number from the user and a deposit amount and if the account exists add the deposit amount to the balance
W - Perform a withdrawal transaction by getting an account number from the user and a withdrawal amount and if the account exists with enough of a balance, perform the withdrawal including any penalties
Q - Quit the transaction processing

Requirements
1. Abstract Accounts parent class
    a. Properties
        i. Account id
        ii. Account type
        iii. Current balance
    b. Constructors
    c. Deposit method including...
        i. account id - get from user
        ii. deposit amount > 0 - get from user
        iii. Increases balance by the deposit amount
    d. Abstract Withdrawal method (different for all 3 classes) including...
        i. account id
        ii. amount of the withdrawal > 0
            A. Savings - as long as balance > withdrawal
            B. Checking - as long as withdrawal <= balance/2
            C. CD - as long as balance > withdrawal + penalty
    c. ToString()
2. Savings child class
    a. Properties
        i. Annual interest rate (IInterest interface)
            A. Don't add the interest rate but do report it on the ToString()
    b. Abstract Withdrawal Method
        i. as long as balance > withdrawal
    c. Overriding ToString()
3. Checking child class
    a. Properties
        i. Annual fee
    b. Abstract Withdrawal Method
        i. as long as withdrawal <= balance/2
    c. Overriding ToString()
4. CD child class
    a. Properties
        i. Annual interest rate (IInterest interface)
            A. Don't add the interest rate but do report it on the ToString()
        ii. Penalty for early withdrawal
    b. Abstract Withdrawal Method
        i. as long as balance > withdrawal + penalty
    c. Overriding ToString()
5. IInterest interface
    a. Annual interest rate method
6. User Interface (Program.cs)
    a. L - List all of the accounts including
        i. Account id
        ii. Account type
        iii. Balance
        iv. If appropriate
            A. Interest rate
                I. Amount of annual interest given the current balance and interest rate
            B. Annual fee
            C. Early penalty
    b. D - Deposit by account id from user and deposit amount
        i. If account exists, add the deposit amount to the balance
    c. W - Withdrawl by account id from user and withdrawal amount
        i. If account exists with enough of a balance, perfomr the withdrawal **including any penalties**
    d. Q - Quit the transaction processing
7. No data file, so use a List of mock data (account objects)

Steps
1. Read the problem and my notes again to see if I missed any requirements (Done)
2. Design iteratively and test incrementally
    i. Create and test your classes and methods with hard-coded test data so that there is a list of accounts of different types with different balances.
3. Write algo for User Interface
4. Refactor

*/
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Banking
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Create a list of Savings accounts
            List<Accounts> allTypesOfAccounts = new List<Accounts>();

            Savings skylerSavings = new Savings(1,"Savings", 1.85m, 0.06m);
            Savings cohenSavings = new(4,"Savings", 109.95m, 0.08m);

            allTypesOfAccounts.Add(skylerSavings);
            allTypesOfAccounts.Add(cohenSavings);

            //add CDs to the list
            CD skylerCD = new CD(2, "CD", 143487.89m, .10m);
            CD cohenCD = new CD(5, "CD", 4787.21m, .13m);

            allTypesOfAccounts.Add(skylerCD);
            allTypesOfAccounts.Add(cohenCD);

            //add Checking accounts to the list
            Checking skylerChecking = new(3, "Checking", 4675.38m, 49.99m);
            Checking cohenChecking = new(6, "Checking", 65.43m, 4.99m);

            allTypesOfAccounts.Add(skylerChecking);
            allTypesOfAccounts.Add(cohenChecking);

            //sort the account list by account id number
            allTypesOfAccounts = allTypesOfAccounts.OrderBy(x => x.AccountID).ToList();

            Console.WriteLine("");
            Console.WriteLine("Welcome to your bank!");
            UserMenu(allTypesOfAccounts);
        }

        public static void UserMenu(List<Accounts> allTypesOfAccounts)
        {
            string userMenuChoice;
            List<string> menuChoices = new List<string>{"l","d","w","q"};

            Console.WriteLine("");
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("Choose \"L\" to load a list of all accounts.");
            Console.WriteLine("Choose \"D\" to make a deposit.");
            Console.WriteLine("Choose \"W\" to make a withdrawal.");
            Console.WriteLine("Choose \"Q\" to quit.");
            Console.WriteLine("");

            userMenuChoice = Console.ReadLine()!.ToLower();
            
            if(menuChoices.Contains(userMenuChoice))
            {
                if(userMenuChoice == "l")
                {
                    Load(allTypesOfAccounts);
                }
                else if(userMenuChoice == "d")
                {
                    makeDeposit(allTypesOfAccounts);
                }
                else if(userMenuChoice == "w")
                {
                    makeWithdrawal(allTypesOfAccounts);
                }
                else
                {
                    Quit();
                }
            }else
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter one letter corresponding to the menu of items.");
                UserMenu(allTypesOfAccounts);
            }
        }

            // L - List all of the accounts 
        static void Load(List<Accounts> accounts)
        {
            foreach(Accounts account in accounts)
            {
                Console.WriteLine(account);
            }
            UserMenu(accounts);
        }

            // D - Deposit by account id from user and deposit amount
        static void makeDeposit(List<Accounts> accounts)
        {
            //Get account id from user and save it
            Console.WriteLine("");
            Console.WriteLine("Please enter the account id of the account you would like to make a deposit in.");
            Console.WriteLine("");

            string userAccountID = Console.ReadLine()!;
            decimal userDeposit;
            bool match = false;

            // i. If account exists, add the deposit amount to the balance
            for(int i=0; i<accounts.Count; i++)
            {
                if(accounts[i].AccountID.ToString() == userAccountID)
                {
                    //Get deposit amount from the user and call Deposit method from Accounts class
                    Console.WriteLine("");
                    Console.WriteLine("Please enter the amount you would like to deposit.");
                    Console.WriteLine("");

                    userDeposit = Convert.ToDecimal(Console.ReadLine());

                    accounts[i].Deposit(userDeposit);//From Accounts class

                    Console.WriteLine("");
                    Console.WriteLine($"You have deposited ${userDeposit} into your {accounts[i].AccountType} account.\nYour new balance is ${accounts[i].AccountBalance}");
                    Console.WriteLine("");
                    match = true;
                    UserMenu(accounts);
                    break;
                }
            }
            if(match == false)
            {
                Console.WriteLine("");
                Console.WriteLine($"No match for account id {userAccountID} was found. Please try again.");
                Console.WriteLine("");
                makeDeposit(accounts);
            } 
        }

        // W - Withdrawl by account id from user and withdrawal amount
        static void makeWithdrawal(List<Accounts> accounts)
        {
            //Get account id from user and save it
            Console.WriteLine("");
            Console.WriteLine("Please enter the account id of the account you would like to make a withdrawal from.");
            Console.WriteLine("");

            string userAccountID = Console.ReadLine()!;
            decimal userWithdrawal;
            bool match = false;

            //     i. If account exists with enough of a balance, perform the withdrawal **including any penalties**
            for(int i=0; i<accounts.Count; i++)
            {
                if(accounts[i].AccountID.ToString() == userAccountID)
                {
                    //Get withdrawal amount from the user and call Withdrawal method from the classes
                    Console.WriteLine("");
                    Console.WriteLine("Please enter the amount you would like to withdraw.");
                    Console.WriteLine("");

                    userWithdrawal = Convert.ToDecimal(Console.ReadLine());

                    decimal showBalance = accounts[i].Withdrawal(userWithdrawal);//From the classes

                    Console.WriteLine("");
                    Console.WriteLine($"Your account balance is {Math.Round(showBalance,2,MidpointRounding.ToZero)}");
                    Console.WriteLine("");

                    //conditional to determine if Withdrawal happened
                    // if(accounts[i].AccountBalance != showBalance)
                    // {
                    //     match = true;
                    // }
                    match = true;
                    UserMenu(accounts);
                    break;
                }
            }
            if(match == false)
            {
                Console.WriteLine("");
                Console.WriteLine($"No match for account id {userAccountID} was found. Please try again.");
                Console.WriteLine("");
                makeWithdrawal(accounts);
            } 
        }

        static void Quit()
        {
            Console.WriteLine("");
            Console.WriteLine("Thank you for banking with your bank.");
            Console.WriteLine("");
        }
    }
}
//TESTING
            // //Create a list of Savings accounts and print
            // List<Accounts> allTypesOfAccounts = new List<Accounts>();

            // Savings myDefaultSavings = new Savings();
            // Savings skylerSavings = new Savings(1,"Savings", 1.85m, 0.06m);
            // Savings cohenSavings = new(4,"Savings", 109.95m, 0.08m);

            // allTypesOfAccounts.Add(myDefaultSavings);
            // allTypesOfAccounts.Add(skylerSavings);
            // allTypesOfAccounts.Add(cohenSavings);

            // // foreach(Accounts account in allTypesOfAccounts)
            // // {
            // //     Console.WriteLine(account);
            // // }

            // //add CDs to the list and print those
            // CD myDefaultCD = new CD();
            // CD skylerCD = new CD(2, "CD", 143487.89m, .10m);
            // CD cohenCD = new CD(5, "CD", 4787.21m, .13m);

            // allTypesOfAccounts.Add(myDefaultCD);
            // allTypesOfAccounts.Add(skylerCD);
            // allTypesOfAccounts.Add(cohenCD);

            // // foreach(Accounts account in allTypesOfAccounts)
            // // {
            // //     Console.WriteLine(account);
            // // }

            // //add Checking accounts to the list and print them
            // Checking myDefaultChecking = new();
            // Checking skylerChecking = new(3, "Checking", 4675.38m, 49.99m);
            // Checking cohenChecking = new(6, "Checking", 65.43m, 4.99m);

            // allTypesOfAccounts.Add(myDefaultChecking);
            // allTypesOfAccounts.Add(skylerChecking);
            // allTypesOfAccounts.Add(cohenChecking);

            // foreach(Accounts account in allTypesOfAccounts)
            // {
            //     Console.WriteLine(account);
            // }