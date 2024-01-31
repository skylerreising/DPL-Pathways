using System;
using System.Linq;

namespace Members
{
    class Executive : Memberships, ISpecialOffer
    {
        public decimal PercentCashBack { get; set; }

        public Executive()
        {
            PercentCashBack = 0.15m;
            MembershipType = "Executive";
            AnnualCost = 99.99m;
        }

        public Executive(string primaryEmail, string membershipType, decimal annualCost, decimal amountOfPurchases, decimal percentCashBack) : base(primaryEmail,membershipType,annualCost,amountOfPurchases)
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
            return AnnualCost * 0.5m;
        }
        public override string ToString()
        {
            return base.ToString() + $"Your cash back rewards:\nBased on purchases: ${Math.Round(CashBackRewards(),2, MidpointRounding.ToZero)}\nSpecial offer on Annual Membership: {Math.Round(SpecialOffer(), 2, MidpointRounding.ToZero)}\n";
        }
    }
}