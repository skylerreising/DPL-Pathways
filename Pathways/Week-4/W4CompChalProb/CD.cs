// 4. CD child class
using System;

namespace Banking
{
    //child class
    class CD: Accounts, IInterest
    {
        //     a. Properties
        public decimal InterestRate { get; set; }
        public decimal Penalty = 0.10m;

        //Default constructor
        public CD()
        {
            InterestRate = 0.12m;
            AccountType = "CD";
        }

        //Constructor with values passed in
        public CD(int accountID, string accountType, decimal accountBalance, decimal interestRate): base(accountID,accountType,accountBalance)
        {
            InterestRate = interestRate;
        }

        //         i. Annual interest rate (IInterest interface)
        public decimal CalculateAnnualInterest()
        {
            return InterestRate * AccountBalance;
        }

        //         ii. Penalty for early withdrawal 
        //     b. Abstract Withdrawal Method
        public override decimal Withdrawal(decimal userEnteredWithdrawal)
        {
        //         i. as long as balance > withdrawal + penalty
            if(AccountBalance > userEnteredWithdrawal + Penalty * AccountBalance)
            {
                return AccountBalance -= userEnteredWithdrawal + Penalty*AccountBalance;
            }else
            {
                Console.WriteLine($"The maximum amount you may withdraw due to a penalty is {AccountBalance - AccountBalance * Penalty}. Please try again.");
                return AccountBalance;
            }
        }

        //     c. Overriding ToString()
        //             A. Don't add the interest rate but do report it on the ToString()
        public override string ToString()
        {
            return base.ToString() + $"Interest Rate: {InterestRate}\nInterest added at the end of year: ${Math.Round(CalculateAnnualInterest(),2)}\nEarly Withdrawal Penalty: {Penalty*100}%";
        }
    }
}
