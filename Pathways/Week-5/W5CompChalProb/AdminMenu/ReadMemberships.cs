using System;
using System.Linq;

namespace Members
{
    public class ReadMemberships
    {
        public static void Read(List<Memberships> allMembers)
        {
            foreach(Memberships member in allMembers)
            {
                Console.WriteLine(member);
            }
            MainMenu.TheMenu(allMembers);
        }
    }
}