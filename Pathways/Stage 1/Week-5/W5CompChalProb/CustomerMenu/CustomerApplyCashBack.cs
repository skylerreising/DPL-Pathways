//     D. A - Apply cash-back reward
//         i. Membership id
//         ii. Different for each membership type (see child classes above)
//         iii. Print to console "Cash-back reward request for membership xxxxxx in the amount of $yyyy has been made."
//         iv. Zero out the balance
using System;
using System.Linq;
using System.Diagnostics;


namespace Members
{
    class CustomerApplyCashBack
    {
        public static void ApplyCashBack(List<Memberships> allMembers)
        {
            //Ask user which member they would like to apply the cash back reward for by AccountID and save it in a variable
            //Or go back to Admin Menu
            Console.WriteLine("\nPlease enter \"A\" to enter your account ID to for cash back reward or \"E\" to exit to the Customer menu.\n");

            string? updateChoice = Console.ReadLine();

            if(updateChoice?.ToLower() == "a")
            {
                //If that user exists, continue. If not, ask them to try again.
                Console.WriteLine("\nPlease enter the ID number of the account you would like to apply the cash back award for\n");

                int? userEnteredID = Convert.ToInt32(Console.ReadLine());

                Debug.Assert(allMembers.Any(m => m.AccountID == userEnteredID), "Member ID has to exist to make a return transaction.");

                bool found = false;

                for(int i=0; i<allMembers.Count; i++)
                {
                    if(allMembers[i].AccountID == userEnteredID)
                    {
                        found = true;
                        // iii. Print to console "Cash-back reward request for membership xxxxxx in the amount of $yyyy has been made."
                        Console.WriteLine($"Cash-back reward request for membership {userEnteredID} in the amount of ${Math.Round(allMembers[i].CashBackRewards(),2, MidpointRounding.ToZero)} has been made.");
                        // iv. Zero out the balance
                        allMembers[i].AmountOfPurchases = 0.0m;
                        ApplyCashBack(allMembers);
                    }
                }
                if(!found)
                {
                    Console.WriteLine("\nNo account has that ID.\n");
                    ApplyCashBack(allMembers);
                }
            }else if(updateChoice?.ToLower() == "e")
            {
                CustomerMenu.Customer(allMembers);
            }else
            {
                Console.WriteLine("\nInvalid entry. Please enter one letter option from the list below.\n");
                ApplyCashBack(allMembers);
            }
        }
    }
}