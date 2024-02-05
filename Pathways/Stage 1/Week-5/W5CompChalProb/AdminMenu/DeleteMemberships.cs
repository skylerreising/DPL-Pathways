using System;
using System.Diagnostics;
using System.Linq;

namespace Members
{
    public class DeleteMembership
    {
        public static void Delete(List<Memberships> allMembers)
        {
            //Ask user which member they would like to delete by AccountID and save it in a variable
            //Or go back to Admin Menu
            Console.WriteLine("\nPlease enter \"A\" to enter an AccountID to find a user to delete or \"E\" to exit to the Admin menu.\n");

            string? updateChoice = Console.ReadLine();

            if(updateChoice?.ToLower() == "a")
            {
                //If that user exists, continue. If not, ask them to try again.
                Console.WriteLine("\nPlease enter the ID number of the account you would like to delete.\n");

                int? userEnteredID = Convert.ToInt32(Console.ReadLine());

                Debug.Assert(allMembers.Any(m => m.AccountID == userEnteredID), "Must enter a valid ID");

                bool found = false;
                //loop through the list to see if that account exists
                for(int i=0; i<allMembers.Count; i++)
                {
                    if(allMembers[i].AccountID == Convert.ToInt32(userEnteredID))
                    {
                        found = true;
                        allMembers.RemoveAt(i);
                        Console.WriteLine($"\nThe account with the ID of {userEnteredID} has been deleted");

                        //print to confirm the user has been deleted
                        foreach(Memberships member in allMembers)
                        {
                            Console.WriteLine(member);
                        }
                        Delete(allMembers);
                    }
                }
                if(!found)
                {
                    Console.WriteLine("\nNo account has that ID.\n");
                    Delete(allMembers);
                }

            }else if(updateChoice?.ToLower() == "e")
            {
                AdminMenu.Admin(allMembers);
            }else
            {
                Console.WriteLine("\nInvalid entry. Please enter one letter option from the list below.\n");
                Delete(allMembers);
            }
        }
    }
}