using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string storedValue = "";
        string storedOperator = "";
        string currentValue = "0";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumPadClick(object sender, RoutedEventArgs e)
        {
            currentValue += (((Button)sender).Content).ToString();

            if (currentValue.StartsWith('0') && currentValue.Length > 1)
            {
                currentValue = currentValue.Remove(0, 1);
            }

            output.Text = currentValue;
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            if (currentValue != "0")
            {
                currentValue = "0";
                output.Text = currentValue;
            }
            else
            {
                storedValue = "0";
                storedOperator = "";
                storedOutput.Text = "";
            }
            
        }

        private void OperatorClick(object sender, RoutedEventArgs e)
        {
            switch (storedOperator)
            {
                case "+":
                    currentValue = (Convert.ToInt32(storedValue) + Convert.ToInt32(currentValue)).ToString();
                    break;

                case "-":
                    currentValue = (Convert.ToInt32(storedValue) - Convert.ToInt32(currentValue)).ToString();
                    break;

                case "x":
                    currentValue = (Convert.ToInt32(storedValue) * Convert.ToInt32(currentValue)).ToString();
                    break;

                case "/":
                    currentValue = (Convert.ToInt32(storedValue) / Convert.ToInt32(currentValue)).ToString();
                    break;
            }

            switch (((Button)sender).Content.ToString())
            {
                case "+": storedOperator = "+"; break;

                case "-": storedOperator = "-"; break;

                case "x": storedOperator = "x"; break;

                case "/": storedOperator = "/"; break;

                case "=": storedOperator = ""; break;
            }

            if (((Button)sender).Content.ToString() != "=")
            {

                storedValue = currentValue;
                currentValue = "0";
            }

            output.Text = currentValue;
            storedOutput.Text = storedValue + " " + storedOperator;
        }
    }
}
