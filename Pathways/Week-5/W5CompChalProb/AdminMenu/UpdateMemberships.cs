using System;
using System.Linq;

namespace Members
{
    public class UpdateMembership
    {
        public static void Update(List<Memberships> allMembers)
        {
            //Ask user which member they would like to update by AccountID and save it in a variable
            //Or go back to Admin Menu
            Console.WriteLine("\nPlease enter \"A\" to enter an AccountID to find a user to update or \"E\" to exit to the Admin menu.\n");

            string? updateChoice = Console.ReadLine();
            
            if(updateChoice?.ToLower() == "a")
            {
                //If that user exists, continue. If not, ask them to try again.
                Console.WriteLine("\nPlease enter the ID number of the account you would like to update.\n");

                string? userEnteredID = Console.ReadLine();
                string? userOption;
                string? userAccountType;

                //loop through the list to see if that account exists
                for(int i=0; i<allMembers.Count; i++)
                {
                    if(allMembers[i].AccountID == Convert.ToInt32(userEnteredID))
                    {
                        //Give user list of options for what they would like to update about that member based on the member type
                        Console.WriteLine($"\nWhat would you like to update for the user with the account ID of {userEnteredID}?\nPlease choose from the following options:\n\"P\" - Primary Email Address\n\"T\" - MembershipType\n\"C\" - Annual Cost\n\"A\" - Amount of their puchases\n\"E\" - Exit");

                        userOption = Console.ReadLine();

                        if(userOption?.ToLower() == "p")
                        {
                            Console.WriteLine("\nWhat would you like to update the user's email address to?\n");
                            allMembers[i].PrimaryEmail = Console.ReadLine();
                            Console.WriteLine($"Member {userEnteredID}'s email address has been updated to {allMembers[i].PrimaryEmail}");
                            Update(allMembers);
                        }else if(userOption?.ToLower() == "t")
                        {
                            Console.WriteLine("\nWhat would you like to update the user's account type to? Please enter a number.\n1 - Regular\n2 - Executive\n3 - Non-Profit\n4 - Corporate");
                            userAccountType = Console.ReadLine();
                            if(userAccountType == "1")
                            {
                                Regular updateRegular = new(allMembers[i].PrimaryEmail!, "Regular", 19.99m, allMembers[i].AmountOfPurchases, .1m);

                                //give new account the same ID for the member
                                updateRegular.AccountID = allMembers[i].AccountID;

                                allMembers[i] = updateRegular;
                                Console.WriteLine("\nThis account has been updated to regular\n");

                                Console.WriteLine(allMembers[i]);
                                Update(allMembers);
                            }else if(userAccountType == "2")
                            {
                                Executive updateExecutive = new(allMembers[i].PrimaryEmail!, "Executive", 99.99m, allMembers[i].AmountOfPurchases, .15m);

                                //give new account the same ID for the member
                                updateExecutive.AccountID = allMembers[i].AccountID;

                                allMembers[i] = updateExecutive;
                                Console.WriteLine("\nThis account has been updated to executive\n");

                                Console.WriteLine(allMembers[i]);
                                Update(allMembers);
                            }else if(userAccountType == "3")
                            {
                                NonProfit updateNonProfit = new(allMembers[i].PrimaryEmail!, "Non-Profit", 9.99m, allMembers[i].AmountOfPurchases, .15m);

                                //give new account the same ID for the member
                                updateNonProfit.AccountID = allMembers[i].AccountID;

                                allMembers[i] = updateNonProfit;
                                Console.WriteLine("\nThis account has been updated to non-profit\n");

                                Console.WriteLine(allMembers[i]);
                                Update(allMembers);
                            }else if(userAccountType == "4")
                            {
                                Corporate updateCorporate = new(allMembers[i].PrimaryEmail!, "Corporate", 19.99m, allMembers[i].AmountOfPurchases, .25m);

                                //give new account the same ID for the member
                                updateCorporate.AccountID = allMembers[i].AccountID;

                                allMembers[i] = updateCorporate;
                                Console.WriteLine("\nThis account has been updated to corporate\n");

                                Console.WriteLine(allMembers[i]);
                                Update(allMembers);
                            }
                            else
                            {
                                Console.WriteLine("Invalid entry. Please try again.");
                                Update(allMembers);
                            }
                        }else if(userOption?.ToLower() == "c")
                        {
                            Console.WriteLine("\nWhat would you like to update the user's annual cost to?\n");
                            allMembers[i].AnnualCost = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine($"Member {userEnteredID}'s annual cost has been updated to {allMembers[i].AnnualCost}");
                            Update(allMembers);
                        }else if(userOption?.ToLower() == "a")
                        {
                            Console.WriteLine("\nWhat would you like to update the user's total purchase amount to?\n");
                            allMembers[i].AmountOfPurchases = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine($"Member {userEnteredID}'s total purchase amount has been updated to {allMembers[i].AmountOfPurchases}");
                            Update(allMembers);
                        }else if(userOption?.ToLower() == "e")
                        {
                            Update(allMembers);
                        }else
                        {
                            Console.WriteLine("Invalid entry. Please try again.");
                            Update(allMembers);
                        }
                    }else
                    {
                        Console.WriteLine("\nNo account has that ID.\n");
                        Update(allMembers);
                    }
                }
            }else if(updateChoice?.ToLower() == "e")
            {
                AdminMenu.Admin(allMembers);
            }else
            {
                Console.WriteLine("\nInvalid entry. Please enter one letter option from the list below.\n");
                Update(allMembers);
            }

        }
    }
}