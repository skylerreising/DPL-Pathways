using System;

namespace Banking
{
    // 1. Abstract Accounts parent class
    abstract class Accounts
    {
        // a. Properties
        //     i. Account id
        public int AccountId { get; set; }

        //     ii. Account type
        public string AccountType { get; set; }

        //     iii. Current balance
        public decimal AccountBalance { get; set; }

        // b. Constructors
        //Default
        public Accounts()
        {
            AccountId = 0;
            AccountType = null;
            AccountBalance = 0;
        }

        //Constructor when all Account values are passed. This is so they can be inherited in the child classes.
        public Accounts(int accountId, string accountType, decimal accountBalance)
        {
            AccountId = accountId;
            AccountType = accountType;
            AccountBalance = accountBalance;
        }

        // c. Deposit method including...
        //     i. account id
        //     ii. deposit amount > 0
        //     iii. Increases balance by the deposit amount
        // d. Abstract Withdrawal method (different for all 3 classes) including...
        //     i. account id
        //     ii. amount of the withdrawal > 0
        //         A. Savings - as long as balance > withdrawal
        //         B. Checking - as long as withdrawal <= balance/2
        //         C. CD - as long as balance > withdrawal + penalty
        // c. ToString()
    }
}