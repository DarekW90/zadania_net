using System;
using System.Windows;
using System.Windows.Controls;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        private double _currentValue = 0;
        private double _previousValue = 0;
        private string _operation = "";
        private bool _newInput = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (_newInput)
            {
                DisplayTextBox.Text = button.Content.ToString();
                _newInput = false;
            }
            else
            {
                DisplayTextBox.Text += button.Content.ToString();
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            _operation = button.Content.ToString();
            _previousValue = double.Parse(DisplayTextBox.Text);
            PreviousOperationLabel.Content = $"{_previousValue} {_operation}";
            _newInput = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            _currentValue = double.Parse(DisplayTextBox.Text);
            double result = PerformOperation(_previousValue, _currentValue, _operation);
            DisplayTextBox.Text = result.ToString();
            PreviousOperationLabel.Content = $"{_previousValue} {_operation} {_currentValue} = {result}";
            _newInput = true;
        }

        private double PerformOperation(double val1, double val2, string operation)
        {
            switch (operation)
            {
                case "+": return val1 + val2;
                case "-": return val1 - val2;
                case "*": return val1 * val2;
                case "/": return val1 / val2;
                case "x^y": return Math.Pow(val1, val2);
                case "%": return val1 * val2 / 100;
                case "mod": return val1 % val2;
                default: throw new InvalidOperationException("Nieznana operacja");
            }
        }

        private void Function_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            _currentValue = double.Parse(DisplayTextBox.Text);
            double result = PerformFunction(_currentValue, button.Content.ToString());
            DisplayTextBox.Text = result.ToString();
            PreviousOperationLabel.Content = $"{button.Content}({_currentValue}) = {result}";
            _newInput = true;
        }

        private double PerformFunction(double value, string function)
        {
            switch (function)
            {
                case "sqrt": return Math.Sqrt(value);
                case "1/x": return 1 / value;
                case "log": return Math.Log10(value);
                case "ln": return Math.Log(value);
                case "floor": return Math.Floor(value);
                case "ceil": return Math.Ceiling(value);
                case "fact": return Factorial(value);
                default: throw new InvalidOperationException("Nieznana funkcja");
            }
        }

        private double Factorial(double value)
        {
            if (value < 0) throw new InvalidOperationException("Liczba musi być nieujemna");
            if (value == 0) return 1;
            double result = 1;
            for (int i = 1; i <= Math.Floor(value); i++)
            {
                result *= i;
            }
            return result;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            DisplayTextBox.Text = "0";
            PreviousOperationLabel.Content = "";
            _currentValue = 0;
            _previousValue = 0;
            _operation = "";
            _newInput = true;
        }
    }
}
