using System;
using System.Linq;

namespace Members
{
    class NonProfit : Memberships
    {
        public decimal PercentCashBack { get; set; }

        public NonProfit()
        {
            PercentCashBack = 0.15m;
            MembershipType = "Non-Profit";
            AnnualCost = 9.99m;
        }

        public NonProfit(string primaryEmail, string membershipType, decimal annualCost, decimal amountOfPurchases, decimal percentCashBack) : base(primaryEmail,membershipType,annualCost,amountOfPurchases)
        {
            PercentCashBack = percentCashBack;
        }

        public override decimal CashBackRewards()
        {
            return PercentCashBack * AmountOfPurchases;
        }

        public override string ToString()
        {
            return base.ToString() + $"Your cash back rewards: ${Math.Round(CashBackRewards(),2, MidpointRounding.ToZero)}\n";
        }
    }
}