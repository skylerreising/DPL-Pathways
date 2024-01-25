// 2. Savings child class
using System;

namespace Banking
{
    //child class
    class Savings : Accounts, IInterest
    {
        //     a. Properties
        public decimal InterestRate { get; set; }

        //Default constructor
        public Savings(): base()
        {
            InterestRate = 0.00m;
            AccountType = "Savings";
        }

        //Constructor with all values passed in
        public Savings(int accountID, string accountType, decimal accountBalance, decimal interestRate): base(accountID,accountType,accountBalance)
        {
            InterestRate = interestRate;
        }

        //         i. Annual interest rate (IInterest interface)
        public decimal CalculateAnnualInterest()
        {
            return AccountBalance += InterestRate * AccountBalance;
        }

        //     b. Abstract Withdrawal Method
        public override decimal Withdrawal(decimal userEnteredWithdrawal)
        {
        //         i. as long as balance > withdrawal TODO in Program
            return AccountBalance -= userEnteredWithdrawal;
        }

        //     c. Overriding ToString()
        //A. Don't add the interest rate but do report it on the ToString()
        public override string ToString()
        {
            return base.ToString() + $"Interest Rate: {InterestRate}";
        }
    }
}