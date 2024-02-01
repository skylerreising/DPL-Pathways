// 3. Customer menu with transactions
//     A. L - List all memberships and all info for each account type (same as the Read method)
//     B. P - Purchase
//         i. Membership id
//         ii. amount of purchase > 0
//         iii. Amount of purchase increased by amount if amount > 0 and id exists
//     C. T - Return Transaction
//         i. Membership id
//         ii. amout of purchase return > 0
//         iii. All accounts handle return in same way 
//         iv. If id exists and purchase return > 0 current amount of purchases, decrease by the purchase amount
//     D. A - Apply cash-back reward
//         i. Membership id
//         ii. Different for each membership type (see child classes above)
//         iii. Print to console "Cash-back reward request for membership xxxxxx in the amount of $yyyy has been made."
//         iv. Zero out the balance
//     E. Q - Quit the transaction processing
using System;
using System.Linq;

namespace Members
{
    public class CustomerMenu
    {
        public static void Customer(List<Memberships> allMembers)
        {
            //Get user's admin menu choice
            Console.WriteLine("\nPlease choose an option:\n\"L\" - List all memberships\n\"P\" - Make a purchase\n\"T\" - Make a return\n\"A\" - Apply your cash-back reward\n\"Q\" - Quit to main menu");
            string? adminMenuChoice = Console.ReadLine();

            if(adminMenuChoice?.ToLower() == "l")
            {
                ReadMemberships.Read(allMembers);
            }else if(adminMenuChoice?.ToLower() == "p")
            {
                CustomerPurchase.Purchase(allMembers);
            }else if(adminMenuChoice?.ToLower() == "t")
            {
                
            }else if(adminMenuChoice?.ToLower() == "d")
            {
                
            }else if(adminMenuChoice?.ToLower() == "q")
            {
                MainMenu.TheMenu(allMembers);
            }else
            {
                Console.WriteLine("\nInvalid entry. Please enter one letter option from the list below.\n");
                Customer(allMembers);
            }
        }
    }
}