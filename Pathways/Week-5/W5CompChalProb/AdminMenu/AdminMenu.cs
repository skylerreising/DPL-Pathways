// 2. Administrative menu with CRUD operations
//     A. A list of memberships
//         i. C - Create membership and add to the list
//             a. No duplicated ids, id has to be unique
//         ii. R - Read all mempberships in the list.
//         iii. U - Update a membership based on id
//         iv. D - Delete a membership based on id
using System;
using System.Linq;

namespace Members
{
    public class AdminMenu
    {
        public static void Admin(List<Memberships> allMembers)
        {
            //Get user's admin menu choice
            Console.WriteLine("\nPlease choose an option:\n\"C\" - Create a membership\n\"R\" - See a list of members\n\"U\" - Update a membership\n\"D\" - Delete a memberhips\n\"E\" - Exit to main menu");
            string? adminMenuChoice = Console.ReadLine();

            if(adminMenuChoice?.ToLower() == "c")
            {
                CreateMembership.Create(allMembers);
            }else if(adminMenuChoice?.ToLower() == "r")
            {
                ReadMemberships.Read(allMembers);
            }else if(adminMenuChoice?.ToLower() == "u")
            {
                UpdateMembership.Update(allMembers);
            }else if(adminMenuChoice?.ToLower() == "d")
            {
                DeleteMembership.Delete(allMembers);
            }else if(adminMenuChoice?.ToLower() == "e")
            {
                MainMenu.TheMenu(allMembers);
            }else
            {
                Console.WriteLine("\nInvalid entry. Please enter one letter option from the list below.\n");
                Admin(allMembers);
            }
        }
    }
}