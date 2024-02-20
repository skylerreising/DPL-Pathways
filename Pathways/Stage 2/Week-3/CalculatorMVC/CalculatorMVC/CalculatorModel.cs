using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVC
{
    public class CalculatorModel
    {
        public double Num1 { get; set; }

        public double Num2 { get; set; }
        public string OperatorSign { get; set; }


        public CalculatorModel()
        {
            Num1 = 0;
            Num2 = 0;
            OperatorSign = "";
        }

        public CalculatorModel(double num1, double num2, string operatorSign)
        {
            Num1 = num1;
            Num2 = num2;
            OperatorSign = operatorSign;
        }

        public double CalculateNumbers()
        {
            if(OperatorSign == "+")
            {
                return Num1 + Num2;
            }
            else if(OperatorSign == "-")
            {
                return Num1 - Num2;
            }
            else if(OperatorSign == "*")
            {
                return Num1 * Num2;
            }
            else
            {
                if(Num2 != 0)
                {
                    return Num1 / Num2;
                }
                return double .NaN;
            }
        }
    }
}
