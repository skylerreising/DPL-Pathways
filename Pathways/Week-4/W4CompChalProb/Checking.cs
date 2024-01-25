// 3. Checking child class
using System;

namespace Banking
{
    //child class
    class Checking: Accounts
    {
        //     a. Properties
        //         i. Annual fee

        public decimal AnnualFee { get; set; }

        //Default constructor
        public Checking()
        {
            AnnualFee = 9.99m;
            AccountType = "Checking";
        }

        //Constructor when all values are passed in
        public Checking(int accountID, string accountType, decimal accountBalance, decimal annualFee): base(accountID,accountType,accountBalance)
        {
            AnnualFee = annualFee;
        }

        //     b. Abstract Withdrawal Method
        public override decimal Withdrawal(decimal userEnteredWithdrawal)
        {
        //         i. as long as withdrawal <= balance/2 TODO IN PROGRAM
            return AccountBalance -= userEnteredWithdrawal;
        }

        //     c. Overriding ToString()
        // public override string ToString()
        // {
        //     return base.ToString();
        // }
    }
}
