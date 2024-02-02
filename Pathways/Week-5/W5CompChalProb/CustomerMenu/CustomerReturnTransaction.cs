// T - Return Transaction
//   i. Membership id
//   ii. amout of purchase return > 0
//   iii. All accounts handle return in same way 
//   iv. If id exists and purchase return > 0 current amount of purchases, decrease by the purchase amount
using System;
using System.Diagnostics;
using System.Linq;

namespace Members
{
    class CustomerReturnTransaction
    {
        public static void Return(List<Memberships> allMembers)
        {
            //Ask user which member they would like to return for by AccountID and save it in a variable
            //Or go back to Admin Menu
            Console.WriteLine("\nPlease enter \"A\" to enter your account ID to make a return for or \"E\" to exit to the Customer menu.\n");

            string? updateChoice = Console.ReadLine();

            if(updateChoice?.ToLower() == "a")
            {
                //If that user exists, continue. If not, ask them to try again.
                Console.WriteLine("\nPlease enter the ID number of the account you would like to make a return for\n");

                int? userEnteredID = Convert.ToInt32(Console.ReadLine());

                Debug.Assert(allMembers.Any(m => m.AccountID == userEnteredID), "Member ID has to exist to make a return transaction.");

                bool found = false;

                for(int i=0; i<allMembers.Count; i++)
                {
                    if(allMembers[i].AccountID == userEnteredID)
                    {
                        found = true;
                        //Get the purchase amount
                        Console.WriteLine("\nPlease enter the return amount:\n");

                        decimal userReturn = Convert.ToDecimal(Console.ReadLine());

                        Debug.Assert(userReturn > 0, "The user return amount should be greater than 0");

                        //if userReturn > 0, subtract it to their AmountOfPurchases
                        if(userReturn > 0)
                        {
                            allMembers[i].AmountOfPurchases -= userReturn;
                            Console.WriteLine($"\nYour amount of purchases has decreased by ${userReturn} to {allMembers[i].AmountOfPurchases}\n");
                            Return(allMembers);
                        }
                        else
                        {
                            Console.WriteLine("Return amount must be greater than 0");
                            Return(allMembers);
                        }
                    }
                }
                if(!found)
                {
                    Console.WriteLine("\nNo account has that ID.\n");
                    Return(allMembers);
                }
            }else if(updateChoice?.ToLower() == "e")
            {
                CustomerMenu.Customer(allMembers);
            }else
            {
                Console.WriteLine("\nInvalid entry. Please enter one letter option from the list below.\n");
                Return(allMembers);
            }
        }
    }
}