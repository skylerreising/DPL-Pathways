// i. C - Create membership and add to the list
//     a. No duplicated ids, id has to be unique
using System;
using System.Diagnostics;
using System.Linq;

namespace Members
{
    public class CreateMembership
    {
        public static void Create(List<Memberships> allMembers)
        {
            //Ask user which member type they would like to create and save it in a variable
            //Or go back to Admin Menu
            Console.WriteLine("\nWhat type of account would you like to create? Please enter a number.\n1 - Regular\n2 - Executive\n3 - Non-Profit\n4 - Corporate\nEnter \"E\" to exit to the Admin menu.\n");

            string? userAccountType = Console.ReadLine();

            //variables for a new account
            int createAccountID;
            string? createPrimaryEmail;
            string? createMembershipType;
            decimal createAnnualCost;
            decimal createAmountOfPurchases;
            decimal createPercentCashBack;
            
            if(userAccountType == "1")
            {
                createMembershipType = "Regular";

                Console.WriteLine("\nPlease enter the new member's primary email address:\n");
                createPrimaryEmail = Console.ReadLine();

                Console.WriteLine("\nPlease enter the new member's annual cost:\n");
                createAnnualCost = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("\nPlease enter the new member's amount of purchases they have made:\n");
                createAmountOfPurchases = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("\nPlease enter the new member's percent cash back:\n");
                createPercentCashBack = Convert.ToDecimal(Console.ReadLine());

                Regular createRegular = new(createPrimaryEmail!, createMembershipType, createAnnualCost, createAmountOfPurchases, createPercentCashBack);

                createAccountID = allMembers.Max(x => x.AccountID)+1;
                createRegular.AccountID = createAccountID;
                Debug.Assert(!allMembers.Any(m => m.AccountID == createRegular.AccountID), "The membership ID must be unique.");

                allMembers.Add(createRegular);

                Console.WriteLine("\nThis account has been created\n");

                Console.WriteLine(allMembers[allMembers.Count-1]);
                Create(allMembers);
            }else if(userAccountType == "2")
            {
                createMembershipType = "Executive";

                Console.WriteLine("\nPlease enter the new member's primary email address:\n");
                createPrimaryEmail = Console.ReadLine();

                Console.WriteLine("\nPlease enter the new member's annual cost:\n");
                createAnnualCost = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("\nPlease enter the new member's amount of purchases they have made:\n");
                createAmountOfPurchases = Convert.ToDecimal(Console.ReadLine());

                Executive createExecutive = new(createPrimaryEmail!, createMembershipType, createAnnualCost, createAmountOfPurchases, Program.ExecutivePercentCashBack(createAmountOfPurchases));

                createAccountID = allMembers.Max(x => x.AccountID)+1;
                createExecutive.AccountID = createAccountID;
                Debug.Assert(!allMembers.Any(m => m.AccountID == createExecutive.AccountID), "The membership ID must be unique.");


                allMembers.Add(createExecutive);

                Console.WriteLine("\nThis account has been created\n");

                Console.WriteLine(allMembers[allMembers.Count-1]);
                Create(allMembers);
            }
            else if(userAccountType == "3")
            {
                bool milOrEd = false;
                Console.WriteLine("\nIf you are a military organization enter 1 and if you're an educational organization enter 2. If you're neither, press enter.\n");
                string? memberTypeTitle = Console.ReadLine();
                if(memberTypeTitle == "1")
                {   
                    memberTypeTitle = "Military";
                    milOrEd = true;
                }else if(memberTypeTitle == "2")
                {
                    memberTypeTitle = "Educational";
                    milOrEd = true;
                }else
                {
                    memberTypeTitle = "Non-Profit";
                }

                Console.WriteLine("\nPlease enter the new member's primary email address:\n");
                createPrimaryEmail = Console.ReadLine();

                Console.WriteLine("\nPlease enter the new member's annual cost:\n");
                createAnnualCost = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("\nPlease enter the new member's amount of purchases they have made:\n");
                createAmountOfPurchases = Convert.ToDecimal(Console.ReadLine());

                NonProfit createNonProfit = new(createPrimaryEmail!, memberTypeTitle, createAnnualCost, createAmountOfPurchases, Program.NonProfitPercentCashBack(milOrEd));

                createAccountID = allMembers.Max(x => x.AccountID)+1;
                createNonProfit.AccountID = createAccountID;
                Debug.Assert(!allMembers.Any(m => m.AccountID == createNonProfit.AccountID), "The membership ID must be unique.");

                allMembers.Add(createNonProfit);

                Console.WriteLine("\nThis account has been created\n");

                Console.WriteLine(allMembers[allMembers.Count-1]);
                Create(allMembers);
            }else if(userAccountType == "4")
            {
                createMembershipType = "Corporate";

                Console.WriteLine("\nPlease enter the new member's primary email address:\n");
                createPrimaryEmail = Console.ReadLine();

                Console.WriteLine("\nPlease enter the new member's annual cost:\n");
                createAnnualCost = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("\nPlease enter the new member's amount of purchases they have made:\n");
                createAmountOfPurchases = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("\nPlease enter the new member's percent cash back:\n");
                createPercentCashBack = Convert.ToDecimal(Console.ReadLine());

                Corporate createCorporate = new(createPrimaryEmail!, createMembershipType, createAnnualCost, createAmountOfPurchases, createPercentCashBack);

                createAccountID = allMembers.Max(x => x.AccountID)+1;
                createCorporate.AccountID = createAccountID;
                Debug.Assert(!allMembers.Any(m => m.AccountID == createCorporate.AccountID), "The membership ID must be unique.");


                allMembers.Add(createCorporate);

                Console.WriteLine("\nThis account has been created\n");

                Console.WriteLine(allMembers[allMembers.Count-1]);
                Create(allMembers);
            }
            else if(userAccountType?.ToLower() == "e")
            {
                AdminMenu.Admin(allMembers);
            }
            else
            {
                Console.WriteLine("Invalid entry. Please try again.");
                Create(allMembers);
            }
        }
    }
}