using System;
using System.Linq;

namespace Members
{
    abstract class Memberships
    {
        private static List<Memberships> myMembers = new List<Memberships>();
        public int AccountID { get; set; }
        public string? PrimaryEmail { get; set; }
        public string? MembershipType { get; set; }
        public decimal AnnualCost { get; set; }
        public decimal AmountOfPurchases { get; set; }

        public static List<Memberships> GetMembers()
        {
            return myMembers;
        }
        public Memberships()
        {
            //If the list is empty, AccountID == 1 otherwise...
            if (myMembers.Count == 0)
            {
                AccountID = 1;
            }else
            {
                //Find the highest AccountID in the list and assign the AccountID of highest AccountID++
                AccountID = myMembers.Max(x => x.AccountID)+1;
            }

            PrimaryEmail = "";
            MembershipType = "";
            AnnualCost = 0.0m;
            AmountOfPurchases = 0.0m;
        }

        public Memberships(string primaryEmail, string membershipType, decimal annualCost, decimal amountOfPurchases)
        {
            if (myMembers.Count == 0)
            {
                AccountID = 1;
            }else
            {
                AccountID = myMembers.Max(x => x.AccountID)+1;
            }

            PrimaryEmail = primaryEmail;
            MembershipType = membershipType;
            AmountOfPurchases = amountOfPurchases;
            AnnualCost = annualCost;
        }

        public void Purchase(int accountID, decimal amountOfPurchase)
        {
            // loop to see if the account exists and if it does, do the math
            for(int i=0; i<myMembers.Count; i++)
            {
                if(myMembers[i].AccountID == accountID)
                {
                    if(amountOfPurchase > 0)
                    {
                    myMembers[i].AmountOfPurchases += amountOfPurchase;
                    }
                }
            }
        }

        public void ReturnTransaction(int accountID, decimal amountOfReturn)
        {
            //loop to see if the account exists and if it does, do the math
            for(int i=0; i<myMembers.Count; i++)
            {
                if(myMembers[i].AccountID == accountID)
                {
                    if(amountOfReturn > 0)
                    {
                        myMembers[i].AmountOfPurchases -= amountOfReturn;
                    }
                }
            }
        }

        public abstract decimal CashBackRewards();

        public override string ToString()
        {
            return $"Account ID: {AccountID}\nPrimary Email: {PrimaryEmail}\nMembership Type: {MembershipType}\nAnnual Cost: {AnnualCost}\nPurchase Total: {AmountOfPurchases}\n";
        }
    }
}