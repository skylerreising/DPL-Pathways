using System;

namespace Banking
{
    // 1. Abstract Accounts parent class
    abstract class Accounts
    {
        // a. Properties
        //     i. Account id
        public int AccountID { get; set; }

        //     ii. Account type
        public string AccountType { get; set; }

        //     iii. Current balance
        public decimal AccountBalance { get; set; }

        // b. Constructors
        //Default
        public Accounts()
        {
            AccountID = 0;
            AccountType = null;
            AccountBalance = 0;
        }

        //Constructor when all Account values are passed. This is so they can be inherited in the child classes.
        public Accounts(int accountID, string accountType, decimal accountBalance)
        {
            AccountID = accountID;
            AccountType = accountType;
            AccountBalance = accountBalance;
        }

        // c. Deposit method
        public void Deposit(decimal userEnteredDeposit)
        {
        //     i. account id //TODO
        //     ii. deposit amount > 0
            if(userEnteredDeposit>0)
            {
        //     iii. Increases balance by the deposit amount
                AccountBalance += userEnteredDeposit;
            }
        }
        
        // d. Abstract Withdrawal method (different for all 3 classes) including...
        //     i. account id
        //     ii. amount of the withdrawal > 0
        //         A. Savings - as long as balance > withdrawal
        //         B. Checking - as long as withdrawal <= balance/2
        //         C. CD - as long as balance > withdrawal + penalty
        public abstract decimal Withdrawal(decimal userEnteredWithdrawal);

        // c. ToString()
        public override string ToString()
        {
            Console.WriteLine(" ");
            return $"Account ID: {AccountID}\nAccount Type: {AccountType}\nCurrent Balance: {AccountBalance}\n";
        }
    }
}