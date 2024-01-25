// 5. IInterest interface
//     a. Annual interest rate method
using System;
using System.Reflection.Metadata.Ecma335;

namespace Banking
{
    public interface IInterest
    {
        //properties
        decimal InterestRate { get; set; }
        //methods
        decimal CalculateAnnualInterest();
    }
}