using System;
using System.Linq;

namespace Members
{
    public class MainMenu
    {
        public static void TheMenu(List<Memberships> allMembers)
        {
            //Get user's main menu choice
            Console.WriteLine("Please choose a menu:\n\"A\" - Admin\n\"M\" - Member\n\"Q\" - Quit");
            string? mainMenuChoice = Console.ReadLine();

            if(mainMenuChoice?.ToLower() == "a" || mainMenuChoice?.ToLower() == "admin")
            {
                AdminMenu.Admin(allMembers);
            }else if(mainMenuChoice?.ToLower() == "m" || mainMenuChoice?.ToLower() == "member")
            {
                CustomerMenu.Customer(allMembers);
            }else if(mainMenuChoice?.ToLower() == "q" || mainMenuChoice?.ToLower() == "quit")
            {
                Quit();
            }else
            {
                Console.WriteLine("\nInvalid entry. Please enter \"A\" or \"M\" to select admin or member menu.\n");
                TheMenu(allMembers);
            }
        }

        public static void Quit()
        {
            Console.WriteLine("\nGood bye.\n");
        }
    }
}