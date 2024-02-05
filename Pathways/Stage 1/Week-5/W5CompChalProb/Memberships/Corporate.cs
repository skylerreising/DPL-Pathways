using System;
using System.Linq;

namespace Members
{
    class Corporate : Memberships
    {
        public decimal PercentCashBack { get; set; }

        public Corporate()
        {
            PercentCashBack = 0.25m;
            MembershipType = "Corporate";
            AnnualCost = 19.99m;
        }

        public Corporate(string primaryEmail, string membershipType, decimal annualCost, decimal amountOfPurchases, decimal percentCashBack) : base(primaryEmail,membershipType,annualCost,amountOfPurchases)
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