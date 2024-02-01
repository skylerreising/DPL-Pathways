// P - Purchase
// i. Membership id
// ii. amount of purchase > 0
// iii. Amount of purchase increased by amount if amount > 0 and id exists
using System;
using System.Linq;

namespace Members
{
    class CustomerPurchase
    {
        public static void Purchase(List<Memberships> allMembers)
        {
            //Ask user which member they would like to update by AccountID and save it in a variable
            //Or go back to Admin Menu
            Console.WriteLine("\nPlease enter \"A\" to enter your account ID to make a purchase or \"E\" to exit to the Customer menu.\n");

            string? updateChoice = Console.ReadLine();

            if(updateChoice?.ToLower() == "a")
            {
                //If that user exists, continue. If not, ask them to try again.
                Console.WriteLine("\nPlease enter the ID number of the account you would like to make a purchase for\n");

                int? userEnteredID = Convert.ToInt32(Console.ReadLine());

                bool found = false;

                for(int i=0; i<allMembers.Count; i++)
                {
                    if(allMembers[i].AccountID == userEnteredID)
                    {
                        found = true;
                        //Get the purchase amount
                        Console.WriteLine("\nPlease enter the purchase amount:\n");

                        decimal userPurchase = Convert.ToDecimal(Console.ReadLine());

                        //if userPurchase > 0, add it to their AmountOfPurchases
                        if(userPurchase > 0)
                        {
                            allMembers[i].AmountOfPurchases += userPurchase;
                            Console.WriteLine($"\nYour amount of purchases has increased by ${userPurchase} to {allMembers[i].AmountOfPurchases}\n");
                            Purchase(allMembers);

                        }
                        else
                        {
                            Console.WriteLine("Purchase amount must be greater than 0");
                            Purchase(allMembers);
                        }
                    }
                }
                if(!found)
                {
                    Console.WriteLine("\nNo account has that ID.\n");
                    Purchase(allMembers);
                }
            }else if(updateChoice?.ToLower() == "e")
            {
                CustomerMenu.Customer(allMembers);
            }else
            {
                Console.WriteLine("\nInvalid entry. Please enter one letter option from the list below.\n");
                Purchase(allMembers);
            }
        }
    }
}