using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVC
{
    public class CalculatorController
    {
        private CalculatorModel calcModel;
        private CalculatorView calcView;

        public CalculatorController()
        {
            //instanciate a view
            calcView = new CalculatorView();

            //instantiate a model
            calcModel = new CalculatorModel();

            //Loop until user decides to quit
            while(calcView.CalcOrQuit())//View method to ask if user wants to calculate or quit
            {
                calcModel.Num1 = calcView.GetNum1();
                calcModel.OperatorSign = calcView.GetOperator();
                calcModel.Num2 = calcView.GetNum2();
                calcView.ShowResult(calcModel.Num1, calcModel.OperatorSign, calcModel.Num2, calcModel.CalculateNumbers());
            }
        }
    }
}
