using System;

namespace InterfacePractice
{
    interface IMinimumWage
    {
        public double FedMinWage { get; set; }
        public double StateMinWage { get; set; }
        double GetMinWage();
    }
}
