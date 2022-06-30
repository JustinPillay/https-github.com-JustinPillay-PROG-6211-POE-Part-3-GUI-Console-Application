using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_6211_POE_Part_3
{
    public class HomeLoan //class to hold the method to calculate the home loan monthly repayments
    {
        public double CalcHomeLoan(double homePurchasePrice, double homeDeposit, double homePaymentTerm, double homeInterestRate) //method signature and parameters
        {

            double owedAmount = (homePurchasePrice - homeDeposit); //calculate the owed amount after deposit is paid

            double percentInterestRate = (homeInterestRate / 100); //get the % interest value

            double years = (homePaymentTerm / 12);  //calculate the years to payback

            double totalOwed = owedAmount * (1 + (percentInterestRate * years)); //calculation for owed amount including interest over years amount

            double homeLoanMonthlyRepayments = Math.Round(totalOwed / homePaymentTerm, 2); //calculate the monthly repayments over 20 years

            return homeLoanMonthlyRepayments;  //return monthly repayments value
        }
    }
}
