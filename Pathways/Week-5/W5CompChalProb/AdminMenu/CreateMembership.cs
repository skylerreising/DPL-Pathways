// i. C - Create membership and add to the list
//     a. No duplicated ids, id has to be unique
using System;
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

                allMembers.Add(createRegular);

                Console.WriteLine("\nThis account has been created\n");

                Console.WriteLine(allMembers[allMembers.Count-1]);
                Create(allMembers);
            }
            // else if(userAccountType == "2")
            // {
            //     Executive updateExecutive = new(allMembers[i].PrimaryEmail!, "Executive", 99.99m, allMembers[i].AmountOfPurchases, Program.ExecutivePercentCashBack(allMembers[i].AmountOfPurchases));

            //     //give new account the same ID for the member
            //     updateExecutive.AccountID = allMembers[i].AccountID;

            //     allMembers[i] = updateExecutive;
            //     Console.WriteLine("\nThis account has been updated to executive\n");

            //     Console.WriteLine(allMembers[i]);
            //     Update(allMembers);
            // }else if(userAccountType == "3")
            // {
            //     bool milOrEd = false;
            //     Console.WriteLine("\nIf you are a military organization enter 1 and if you're an educational organization enter 2. If you're neither, press enter.\n");
            //     string? memberTypeTitle = Console.ReadLine();
            //     if(memberTypeTitle == "1")
            //     {   
            //         memberTypeTitle = "Military";
            //         milOrEd = true;
            //     }else if(memberTypeTitle == "2")
            //     {
            //         memberTypeTitle = "Educational";
            //         milOrEd = true;
            //     }else
            //     {
            //         memberTypeTitle = "Non-Profit";
            //     }

            //     NonProfit updateNonProfit = new(allMembers[i].PrimaryEmail!, memberTypeTitle, 9.99m, allMembers[i].AmountOfPurchases, Program.NonProfitPercentCashBack(milOrEd));

            //     //give new account the same ID for the member
            //     updateNonProfit.AccountID = allMembers[i].AccountID;

            //     allMembers[i] = updateNonProfit;
            //     Console.WriteLine("\nThis account has been updated to non-profit\n");

            //     Console.WriteLine(allMembers[i]);
            //     Update(allMembers);
            // }else if(userAccountType == "4")
            // {
            //     Corporate updateCorporate = new(allMembers[i].PrimaryEmail!, "Corporate", 19.99m, allMembers[i].AmountOfPurchases, .25m);

            //     //give new account the same ID for the member
            //     updateCorporate.AccountID = allMembers[i].AccountID;

            //     allMembers[i] = updateCorporate;
            //     Console.WriteLine("\nThis account has been updated to corporate\n");

            //     Console.WriteLine(allMembers[i]);
            //     Update(allMembers);
            // }
            else if(userAccountType.ToLower() == "e")
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