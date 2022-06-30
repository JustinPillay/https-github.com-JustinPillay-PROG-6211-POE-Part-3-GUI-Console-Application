using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_6211_POE_Part_3
{
    public class Balance //class to hold the method to calculate the remaining income after expenses and deductions
    {
        public double CalcBalance(double grossIncome, double taxDeduction, double totalExpenses) //method signature and parameters
        {

            double netIncome = (grossIncome - (grossIncome * (taxDeduction / 100))); //net income calculated by gross income - tax deduction

            double balance = netIncome - totalExpenses; // balance calculated by net income minus sum of all expenses (incl loan and vehicle payments) 

            return balance; //returns balance
        }
    }
}
