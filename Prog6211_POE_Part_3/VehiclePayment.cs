using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_6211_POE_Part_3
{
    public class VehiclePayment //class to hold the method to calculate the vehicle monthly repayments
    {
        public double CalcVehicleRepayment(double vehiclePurchasePrice, double vehicleDeposit, double vehicleInterestRate, double vehicleInsurancePayment) //method signature and parameters
        {

            double vehiclePaymentTerm = 5; //years to payback the amount owed (fixed at 5 years as per instructions)

            double owedAmount = (vehiclePurchasePrice - vehicleDeposit); //calculates the amount owed after the deposit is accounted for

            double percentInterestRate = (vehicleInterestRate / 100); //calculate the % interest value

            double totalOwed = owedAmount * (1 + (percentInterestRate * vehiclePaymentTerm)); //calculates the total amount owed including the interest

            double vehicleMonthlyRepayment = Math.Round((totalOwed / (vehiclePaymentTerm * 12)) + vehicleInsurancePayment, 2); //calculates the monthly repayments over 5 years including the insurance payments


            return vehicleMonthlyRepayment; //returns the monthly repayment
        }
    }
}
