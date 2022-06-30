using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Prog_6211_POE_Part_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public delegate void ShowWarning(double grossIncome, double totalExpenses); //declaration of delegate

        Groceries exp = new Groceries(); //object of abstract class child
        HomeLoan hl = new HomeLoan(); //object of HomeLoan class
        VehiclePayment vp = new VehiclePayment(); //object of VehiclePayment class
        Balance bl = new Balance(); //object of Balance class


        double grossIncome = 0; //stores gross income
        double taxDeduction = 0; //stores user's tax deduction
        double homePurchasePrice = 0; //stores user's home purchase price if they opt to purchase a home
        double homeDeposit = 0; //stores user's home deposit
        double homePaymentTerm = 0; //stores user's payment term on home loan
        double homeInterestRate = 0; //stores user's interest rate on home loan
        double homeMonthlyRepayment = 0; //stores user's home loan monthly repayment
        double vehiclePurchasePrice = 0; //stores user's vehicle purchase price if they opt to purchase a vehicle
        double vehicleDeposit = 0; //stores user's deposit on vehicle purchase
        double vehicleInterestRate = 0; //stores user's vehicle loan interest rate
        double vehicleInsurancePayment = 0; //stores user's estimated monthly insurance payment
        double vehicleMonthlyRepayment = 0; //stores user's monthly repayment (including interest and insurance)
        double totalExpenses = 0; //stores user's total expenses (including homeloan and vehicle payments if applicable)
        double balance = 0; //stores balance value
        double P, A, r, t, n = 0; //variables for savings calculation

        string vehicleModel; //stores vehicle model
        string vehicleMake; //stores vehicle make
        string reason; //stores reason for savings

        private void btnSubmit_Click(object sender, RoutedEventArgs e) //button click event handler
        {
            //clears both lists in the event a user doesn't fill in all requirements
            exp.expenseList.Clear();
            exp.expenses.Clear();

            //loop to ensure that an income is entered and is not 0
            int validInput = 0;
            while (validInput == 0)
            {
                if (txtboxIncome.Text == "" || txtboxIncome.Text == "0")
                {
                    MessageBox.Show("Please enter a value for your income! This value cannot be 0.");
                    return;
                }
                else
                {
                    grossIncome = Convert.ToDouble(txtboxIncome.Text);
                    validInput++;
                }
            }

            //checks if there is a value in field
            if (txtboxTaxDeduction.Text == "")
            {
                MessageBox.Show("Please enter a value for your tax deduction!");
                return;
            }
            //writes value to taxDeduction variable
            else
            {
                taxDeduction = Convert.ToDouble(txtboxTaxDeduction.Text);
            }

            //checks if there is a value in field
            if (txtboxGroceries.Text == "")
            {
                MessageBox.Show("Please enter a value for your Groceries expense! If you do not have a Grocery expense, please enter a 0.");
                return;
            }
            //calls method from Expenses class to add user input to list for corresponding expense type
            else
            {
                exp.Value(Convert.ToDouble(txtboxGroceries.Text));
                exp.expenseList.Add("Groceries");
            }
            //checks if there is a value in field
            if (txtboxUtilities.Text == "")
            {
                MessageBox.Show("Please enter a value for your Utilities expense! If you do not have a Utilies expense, please enter a 0.");
                return;
            }
            //calls method from Expenses class to add user input to list for corresponding expense type
            else
            {
                exp.Value(Convert.ToDouble(txtboxUtilities.Text));
                exp.expenseList.Add("Utilities Cost");
            }
            //checks if there is a value in field
            if (txtboxTravel.Text == "")
            {
                MessageBox.Show("Please enter a value for your Travel expense! If you do not have a Travel expense, please enter a 0.");
                return;
            }
            //calls method from Expenses class to add user input to list for corresponding expense type
            else
            {
                exp.Value(Convert.ToDouble(txtboxTravel.Text));
                exp.expenseList.Add("Travel Costs");
            }
            //checks if there is a value in field
            if (txtboxCommunication.Text == "")
            {
                MessageBox.Show("Please enter a value for your Communication expense! If you do not have a Communication expense, please enter a 0.");
                return;
            }
            //calls method from Expenses class to add user input to list for corresponding expense type
            else
            {
                exp.Value(Convert.ToDouble(txtboxCommunication.Text));
                exp.expenseList.Add("Communication");
            }
            //checks if there is a value in field
            if (txtboxOther.Text == "")
            {
                MessageBox.Show("Please enter a value for your other expenses! If you do not have other expenses, please enter a 0.");
                return;
            }
            //calls method from Expenses class to add user input to list for corresponding expense type
            else
            {
                exp.Value(Convert.ToDouble(txtboxOther.Text));
                exp.expenseList.Add("Other Expenses");
            }

            //checks that the user chooses either renting or purchasing
            if (rbtnRenting.IsChecked == false && rbtnPurchasing.IsChecked == false)
            {

                MessageBox.Show("Please select either Renting or Purchasing, then fill out the required fields.");
                return;
            }

            //sequence to capture all renting information and write the expense type and value to the lists in Expense class
            if (rbtnRenting.IsChecked == true)
            {

                if (txtboxRentalAmount.Text == "" || txtboxRentalAmount.Text == "0")
                {

                    MessageBox.Show("Please enter a value for your Rental Amount! This value cannot be 0.");
                    return;
                }

                else
                {
                    //calls method from Expenses class to add user input to list for Rent Amount expense type
                    exp.Value(Convert.ToDouble(txtboxRentalAmount.Text));
                    exp.expenseList.Add("Rent Amount");
                }


            }

            //sequence to capture all purchasing information and write the values to the relevant variables for purchasing a home
            else if (rbtnPurchasing.IsChecked == true)
            {
                //checks if there is a value in field that isnt 0
                if (txtboxHomePurchasePrice.Text == "" || txtboxHomePurchasePrice.Text == "0")
                {
                    MessageBox.Show("Please enter a value for your Purchase Price! This value cannot be 0.");
                    return;
                }
                else
                {
                    homePurchasePrice = Convert.ToDouble(txtboxHomePurchasePrice.Text);
                }
                //checks that there is a value in the field
                if (txtboxHomeDeposit.Text == "")
                {
                    MessageBox.Show("Please enter a value for your Deposit.");
                    return;
                }
                else
                {
                    homeDeposit = Convert.ToDouble(txtboxHomeDeposit.Text);
                }
                //checks if there is a value in field that isnt 0
                if (txtboxHomeInterestRate.Text == "" || txtboxHomeInterestRate.Text == "0")
                {
                    MessageBox.Show("Please enter a value for your Interest Rate. This value cannot be 0.");
                    return;
                }
                else
                {
                    homeInterestRate = Convert.ToDouble(txtboxHomeInterestRate.Text);
                }
                //checks if there is a value in field that isnt 0
                if (txtboxHomePaymentTerm.Text == "" || txtboxHomePaymentTerm.Text == "0")
                {
                    MessageBox.Show("Please enter a value for your Payment Term.This value cannot be 0.");
                    return;
                }
                else
                {
                    homePaymentTerm = Convert.ToDouble(txtboxHomePaymentTerm.Text);
                }
                //calls method from HomeLoan class to calculate homeloan monthly repayment
                homeMonthlyRepayment = hl.CalcHomeLoan(homePurchasePrice, homeDeposit, homePaymentTerm, homeInterestRate);
                //adds the expense type and value to the lists in the Expense class
                exp.Value(homeMonthlyRepayment);
                exp.expenseList.Add("Bond Payment");

            }


            // checks that the user chooses either yes or no to purchasing a vehicle
            if (rbtnVehicleNo.IsChecked == false && rbtnVehicleYes.IsChecked == false)
            {
                MessageBox.Show("Please select either Yes or No to whether you are purchasing a vehicle, if yes, please fill out the required fields.");
                return;
            }

            //sequence to capture all fields and save to corresponding variables
            if (rbtnVehicleYes.IsChecked == true)
            {
                //checks field isnt empty
                if (txtboxVehicleMake.Text == "")
                {
                    MessageBox.Show("Please enter the make of the vehicle you are purchasing!");
                    return;
                }
                else
                {

                    vehicleMake = txtboxVehicleMake.Text;

                }
                //checks field isnt empty
                if (txtboxVehicleModel.Text == "")
                {
                    MessageBox.Show("Please enter the make of the vehicle you are purchasing!");
                    return;
                }
                else
                {

                    vehicleModel = txtboxVehicleModel.Text;

                }
                //checks fields isnt empty or 0
                if (txtboxVehiclePurchasePrice.Text == "" || txtboxVehiclePurchasePrice.Text == "0")
                {
                    MessageBox.Show("Please enter a value for your Vehicle Purchase Price.This value cannot be 0.");
                    return;
                }
                else
                {
                    vehiclePurchasePrice = Convert.ToDouble(txtboxVehiclePurchasePrice.Text);
                }
                //checks fields isnt empty or 0
                if (txtboxVehicleDeposit.Text == "" || txtboxVehicleDeposit.Text == "0")
                {
                    MessageBox.Show("Please enter a value for your Vehicle Purchase Price.This value cannot be 0.");
                    return;
                }
                else
                {
                    vehicleDeposit = Convert.ToDouble(txtboxVehicleDeposit.Text);
                }
                //checks fields isnt empty or 0
                if (txtboxVehicleInterestRate.Text == "" || txtboxVehicleInterestRate.Text == "0")
                {
                    MessageBox.Show("Please enter a value for your Vehicle Interest Rate.This value cannot be 0.");
                    return;
                }
                else
                {
                    vehicleInterestRate = Convert.ToDouble(txtboxVehicleInterestRate.Text);
                }
                //checks fields isnt empty or 0
                if (txtboxVehiclePremium.Text == "" || txtboxVehiclePremium.Text == "0")
                {
                    MessageBox.Show("Please enter a value for your Vehicle Interest Rate.This value cannot be 0.");
                    return;
                }
                else
                {
                    vehicleInsurancePayment = Convert.ToDouble(txtboxVehiclePremium.Text);
                }

                //calls method from Vehicle payment class to calculate monthly repayments
                vehicleMonthlyRepayment = vp.CalcVehicleRepayment(vehiclePurchasePrice, vehicleDeposit, vehicleInterestRate, vehicleInsurancePayment);

                //adds the expense type and value to the lists in the Expense class
                exp.Value(vehicleMonthlyRepayment);
                exp.expenseList.Add("Car Payment");


            }

            //calculates the total expenses from expenses list
            totalExpenses = exp.expenses.Sum(x => Convert.ToDouble(x));

            //formatting for textbox that displays expenses in descending order
            string headers = "Expense Type\t\tExpense Value\n\n";
            string report = "";

            //"zips" the 2 lists together to be able to keep the correct indexes for expense value and expense type aligned
            var expenseTypeAndExpenseAmount = exp.expenseList.Zip(exp.expenses, (w, n) => new { word = w, number = n });

            //sorts the zipped list by desc order
            expenseTypeAndExpenseAmount = expenseTypeAndExpenseAmount.OrderByDescending(item => item.number);

            //creates string for each expense and expense type
            foreach (var nw in expenseTypeAndExpenseAmount)
            {
                report += nw.word + "\t\tR" + nw.number + "\n";
            }
            //writes the corresponding pairs of expenses and expense types into the textbox
            txtboxReport.Text = headers + report;

            //calls the expense warning function via delegate
            ExpenseWarning(grossIncome, taxDeduction, totalExpenses);

            //calls function from Balance class to calculate user's balance after deduction and expenses
            balance = bl.CalcBalance(grossIncome, taxDeduction, totalExpenses);

            //outputs balance in Balance textbox
            txtboxBalance.Text = "Your balance at the end of the month will be:\n" + "R" + balance.ToString();

            //checks if user will be using savings module
            if (rbtnSavingsYes.IsChecked == true)
            {
                //checks field isn't empty
                if (txtboxSavingReason.Text == "")
                {

                    MessageBox.Show("Please enter a reason for your saving goal!");
                    return;

                }
                //checks field isn't empty
                if (txtboxGoal.Text == "")
                {

                    MessageBox.Show("Please enter your saving goal!");
                    return;

                }
                //checks field isn't empty
                if (txtboxSavingsInterestRate.Text == "")
                {

                    MessageBox.Show("Please enter the estimated interest rate for your savings!");
                    return;

                }
                //checks field isn't empty
                if (txtboxSavingDuration.Text == "")
                {

                    MessageBox.Show("Please enter the amount of time in years for your savings goal!");
                    return;

                }

                //saves user input to variable for output later on
                reason = txtboxSavingReason.Text;

                //assigning variable to user input to calculate reverse compound interest
                A = Convert.ToDouble(txtboxGoal.Text);
                r = Convert.ToDouble(txtboxSavingsInterestRate.Text) / 100;
                t = Convert.ToDouble(txtboxSavingDuration.Text);
                n = 12;

                //formula to calculate reverse compound interest (Calculates principal amount in terms of A)
                P = A / (Math.Pow((1 + r / n), n * t));
                P = P / (t * n);

                //string formatting for output
                txtboxSavingsResult.Text = "Assuming interest is compounded annually, " +
                    "you will need to save:\nR" + Math.Round(P, 2) + " per month to reach your goal for " + reason + ".";
            }
            else if (rbtnSavingsNo.IsChecked == true)
            {
                return;
            }

        }

        public void ExpenseWarning(double grossIncome, double taxDeduction, double totalExpenses) //method to calculate expense warning --> will be called by delegate
        {

            double netIncome = (grossIncome - (grossIncome * (taxDeduction / 100))); //net income calculated by gross income - tax deduction

            if (totalExpenses >= ((75/100) * netIncome)) //criteria of expenses being over 75% to show warning
            {

                MessageBox.Show("You will have less than 25% of your income remaining!"); //shows warning

            }
            else if (totalExpenses <= ((75 / 100) * netIncome))
            {
                MessageBox.Show("You will have over 25% of your income remaining!");  //shows user that spending is under 75%
            }
        }



        //hides/shows ui depending on user choice
        private void rbtnPurchasing_Checked(object sender, RoutedEventArgs e)
        {
            cnvRental.Visibility = Visibility.Collapsed;
            txtboxRentalAmount.Clear();
            cnvPurchasing.Visibility = Visibility.Visible;

        }
        //hides/shows ui depending on user choice
        private void rbtnRenting_Checked(object sender, RoutedEventArgs e)
        {
            cnvPurchasing.Visibility = Visibility.Collapsed;
            txtboxHomePurchasePrice.Clear();
            txtboxHomeDeposit.Clear();
            txtboxHomeInterestRate.Clear();
            txtboxHomePaymentTerm.Clear();
            cnvRental.Visibility = Visibility.Visible;
        }
        //hides/shows ui depending on user choice
        private void rbtnVehicleYes_Checked(object sender, RoutedEventArgs e)
        {
            cnvVehicle.Visibility = Visibility.Visible;
        }
        //hides/shows ui depending on user choice
        private void rbtnVehicleNo_Checked(object sender, RoutedEventArgs e)
        {
            cnvVehicle.Visibility = Visibility.Collapsed;
        }
        //menu item that exits the programme
        private void miSystem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        //ensures user can only input numbers
        private void txtboxIncome_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxTaxDeduction_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxGroceries_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxUtilities_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxTravel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxCommunication_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxOther_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxRentalAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxHomePurchasePrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxHomeDeposit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxHomeInterestRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxHomePaymentTerm_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxVehiclePurchasePrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxDeposit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxVehicleInterestRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxVehiclePremium_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void rbtnSavingsYes_Checked(object sender, RoutedEventArgs e)
        {
            cnvSavings.Visibility = Visibility.Visible;
        }
        //ensures user can only input numbers
        private void rbtnSavingsNo_Checked(object sender, RoutedEventArgs e)
        {
            cnvSavings.Visibility = Visibility.Collapsed;
        }
        //ensures user can only input numbers
        private void txtboxVehicleDeposit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxGoal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxSavingsInterestRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        //ensures user can only input numbers
        private void txtboxSavingDuration_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
