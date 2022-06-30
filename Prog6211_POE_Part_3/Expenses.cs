using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_6211_POE_Part_3
{
   public abstract class Expenses // abstract class expenses to store the expenses
    {

        public List<double> expenses = new List<double>(); //list to store the expense values
        public List<string> expenseList = new List<string>(); //list to store the expense types

        public abstract void Value(double value); //declaration of abstract method
    }

    public class Groceries : Expenses //child class of expenses for "Groceries"
    {
        public override void Value(double value) //implementation of abstract method from parent class
        {
            expenses.Add(value);   // adds the value to the expense value list

        }

    }
    public class Utilities : Expenses  //child class of expenses for lights and water
    {
        public override void Value(double value) //implementation of abstract method from parent class
        {
            expenses.Add(value);    // adds the value to the expense value list

        }

    }
    public class TravelCosts : Expenses  //child class of expenses for travel costs
    {
        public override void Value(double value) //implementation of abstract method from parent class
        {
            expenses.Add(value);   // adds the value to the expense value list

        }

    }
    public class Communication : Expenses  //child class of expenses for cell phone and telephone expenses
    {
        public override void Value(double value) //implementation of abstract method from parent class
        {
            expenses.Add(value);   // adds the value to the expense value list

        }

    }
    public class Other : Expenses //child class of expenses for miscellaneous expenses
    {
        public override void Value(double value) //implementation of abstract method from parent class
        {
            expenses.Add(value);   // adds the value to the expense value list

        }

    }
    public class LivingExpense : Expenses  //child class of expenses for either rent or monthly loan repayment
    {
        public override void Value(double value) //implementation of abstract method from parent class
        {
            expenses.Add(value);   // adds the value to the expense value list
        }

    }

    public class VehicleExpense : Expenses  //child class of expenses for monthly vehicle repayment
    {
        public override void Value(double value) //implementation of abstract method from parent class
        {
            expenses.Add(value);   // adds the value to the expense value list
        }

    }
}
