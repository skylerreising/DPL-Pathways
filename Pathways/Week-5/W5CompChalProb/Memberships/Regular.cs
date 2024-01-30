using System;
using System.Linq;

namespace Members
{
    class Regular : Memberships
    {
        public decimal PercentCashBack { get; set; }

        public Regular()
        {
            PercentCashBack = 0.1m;
        }

        public Regular(string primaryEmail, string membershipType, decimal annualCost, decimal amountOfPurchases, decimal percentCashBack) : base(primaryEmail,membershipType,annualCost,amountOfPurchases)
        {
            PercentCashBack = percentCashBack;
        }

        public override decimal CashBackRewards()
        {
            //Return 25% of annual membership cost
            return AnnualCost * PercentCashBack;
        }

        //ADD ANNUAL MEMBERSHIP DISCOUNT FROM INTERFACE
        public override string ToString()
        {
            return base.ToString() + $"Your cash back rewards: {CashBackRewards()}";
        }
    }
}