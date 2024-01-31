using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Members
{
    abstract class Memberships
    {
        public int AccountID { get; set; }
        public string? PrimaryEmail { get; set; }
        public string? MembershipType { get; set; }
        public decimal AnnualCost { get; set; }
        public decimal AmountOfPurchases { get; set; }

        public Memberships()
        {
            PrimaryEmail = "";
            MembershipType = "";
            AnnualCost = 0.0m;
            AmountOfPurchases = 0.0m;
        }

        public Memberships(string primaryEmail, string membershipType, decimal annualCost, decimal amountOfPurchases): this()
        {
            PrimaryEmail = primaryEmail;
            MembershipType = membershipType;
            AmountOfPurchases = amountOfPurchases;
            AnnualCost = annualCost;
        }

        public void Purchase(int accountID, decimal amountOfPurchase)
        {
            if(amountOfPurchase > 0)
            {
            AmountOfPurchases += amountOfPurchase;
            }
        }

        public void ReturnTransaction(int accountID, decimal amountOfReturn)
        {
            AmountOfPurchases -= amountOfReturn;
        }

        public abstract decimal CashBackRewards();

        public override string ToString()
        {
            return $"Account ID: {AccountID}\nPrimary Email: {PrimaryEmail}\nMembership Type: {MembershipType}\nAnnual Cost: {AnnualCost}\nPurchase Total: {AmountOfPurchases}\n";
        }
    }
}