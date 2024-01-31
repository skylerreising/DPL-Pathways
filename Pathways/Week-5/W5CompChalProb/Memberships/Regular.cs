using System;
using System.Linq;

namespace Members
{
    class Regular : Memberships, ISpecialOffer
    {
        public decimal PercentCashBack { get; set; }

        public Regular()
        {
            PercentCashBack = 0.1m;
            MembershipType = "Regular";
            AnnualCost = 19.99m;
        }

        public Regular(string primaryEmail, string membershipType, decimal annualCost, decimal amountOfPurchases, decimal percentCashBack) : base(primaryEmail,membershipType,annualCost,amountOfPurchases)
        {
            PercentCashBack = percentCashBack;
        }

        public override decimal CashBackRewards()
        {
            return PercentCashBack * AmountOfPurchases;
        }

        //ADD ANNUAL MEMBERSHIP DISCOUNT FROM INTERFACE
        public decimal SpecialOffer()
        {
            return AnnualCost * 0.25m;
        }
        public override string ToString()
        {
            return base.ToString() + $"Your cash back rewards: ${Math.Round(CashBackRewards(),2, MidpointRounding.ToZero)}\nSpecial offer on Annual Membership: {Math.Round(SpecialOffer(), 2, MidpointRounding.ToZero)}\n";
        }
    }
}