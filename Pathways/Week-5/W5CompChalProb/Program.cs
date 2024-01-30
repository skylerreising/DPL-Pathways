/*

Create an application with an OOP design to help manage customer memberships (think Costco). 

Four types of memberships need to be handled - a regular, an executive, a non-profit and a corporate. 
All four types of memberships have common information including a membership id, primary contact email address, the type of membership, annual cost and the current amount of purchases for the month. 
In addition, the regular membership has a flat percent for cash-back rewards on all purchases, the executive membership has percentages for two tiers (one below $1000 and one above) of cash-back rewards, the non-profit membership has a cash-back percentage and also a field to indicate if it is a military or educational organization and if so doubles the cash-back percentage, and the corporate membership has a flat percent for cash-back rewards. 
On the administrative side, the four CRUD operations need to be implemented for a membership:
C - Create a new membership and add to the membership list.  Be sure you don't duplicate the membership ID.  It needs to be unique.
R - Read all of the memberships in the membership list.
U - Update an existing membership based on membership ID.
D - Delete an existing membership based on membership ID.
Three types of transactions need to be handled:
Purchase- A purchase will include the membership id and the amount of the purchase (which must be > 0).   All four accounts handle a purchase in the same way.  If the membership ID exists, the current amount of purchases is increased by the purchase amount.
Return - A return of an item will include the membership id and the amount of the purchase returned (which must be > 0).  All four accounts handle a return in the same way.  If the membership ID exists, the current amount of purchases is decreased by the purchase amount.
Apply cash-back reward - For the apply cash-back reward, the membership id will be provided.  Cash-back rewards are handled differently depending on the membership type as described above.  When a valid membership ID is given, the system will send a request to the rewards system for the amount of the reward.  For this application, you can simply print a console output that says "Cash-back reward request for membership xxxxxx in the amount of $yyyy has been made." Then zero out the balance. 
Technical specifications for your application include:
Create an abstract class for a membership.  Membership id, contact email, annual cost, current monthly purchases and type are to be properties.  In addition to the constructors, include a purchase method, a return method, an abstract apply cash-back rewards method, and a useful toString.
Create four classes that inherit from the membership class - one four each membership type.  Create properties for the respective data attributes, implement the apply cash-back method for each as appropriate, and override the toString as appropriate.
In addition, the regular and executive memberships will implement a special offer method from an interface.  The implementation for a regular membership will simply return 25% of the annual membership cost and the implementation for the executive membership will return 50% of the annual membership cost.
Create and test your classes and methods with hard-coded test data so that there is a list of memberships of different types, costs, and balances.
Provide the user the following administrative options:
C - Create a new membership and add to the membership list.  Be sure you don't duplicate the membership ID.  It needs to be unique.
R - Read all of the memberships in the membership list.
U - Update an existing membership based on membership ID.
D - Delete an existing membership based on membership ID.
Provide the user the following transaction options:
L - List all of the memberships in the list including all of the information for each account type.
P - Perform a purchase transaction by getting a membership number from the user and a purchase amount and if the membership exists add the purchase amount to the monthly purchase total.
T - Perform a return transaction by getting an membership number from the user and a return amount and if the membership exists, perform the return by subtracting the return amount for the monthly purchase total.
A - Apply cash-back rewards as described above by getting a membership number from the user.
Q - Quit the transaction processing.

Requirements
1. Abstract parent class memberships
    A.Common data
        i. Membership id
        ii. Primary email
        iii. Membership type
        iv. Annual cost
        v. Current amount of purchases for the month
        vi. Constructors
        vii. Purchase method
        viii. Return method
        ix. Apply cash-back rewards method
        x. ToString
    B. Regular child class
        i. Flat % for cash-back rewards on all purchases
        ii. Apply cash-back rewards method
        iii. Implement special offer method from interface
            a. Return 25% of annual membership cost
        iv. ToString as appropriate
    C. Executive child class
        i. Cash-back % for two tiers
            a. Below $1000
            b. >= $1000
        ii. Apply cash-back rewards method
        iii. Implement special offer method from interface
            a. Return 50% of annual membership cost
        iv. ToString as appropriate
    D. Non-Profit child class
        i. Cash-back %
        ii. Field for military or educational organization
            a. If military or educational, double cash-back %
        iii. Apply cash-back rewards method
        iv. ToString as appropriate
    E. Corporate child class
        i. Flat % for cash-back rewards
        ii. Apply cash-back rewards method
        iii. ToString as appropriate
    F. Special offer interface
        i. Special offer method
2. Administrative menu with CRUD operations
    A. A list of memberships
        i. C - Create membership and add to the list
            a. No duplicated ids, id has to be unique
        ii. R - Read all mempberships in the list.
        iii. U - Update a membership based on id
        iv. D - Delete a membership based on id
3. Customer menu with transactions
    A. L - List all memberships and all info for each account type (same as the Read method)
    B. P - Purchase
        i. Membership id
        ii. amount of purchase > 0
        iii. Amount of purchase increased by amount if amount > 0 and id exists
    C. T - Return Transaction
        i. Membership id
        ii. amout of purchase return > 0
        iii. All accounts handle return in same way 
        iv. If id exists and purchase return > 0 current amount of purchases, decrease by the purchase amount
    D. A - Apply cash-back reward
        i. Membership id
        ii. Different for each membership type (see child classes above)
        iii. Print to console "Cash-back reward request for membership xxxxxx in the amount of $yyyy has been made."
        iv. Zero out the balance
    E. Q - Quit the transaction processing
4. Create and test classes and methods with hard-coded data

Steps
1. Write out requirements (Done)
2. UML Diagram (Done)
3. Create and test iteratively and incrementally
    A. Program
    B. Hard coded data
    C. Classes and interface

*/
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Members
{
    class Program
    {
        //Create a list of Memberships and pass it to Memberships class
        public static List<Memberships> AllMemberships()
        {
            //ADD MEMBERSHIPS HERE
            

            return new List<Memberships>();
        }
        public static void Main(string[] args)
        {   

        }
    }
}