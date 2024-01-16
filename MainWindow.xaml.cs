using System;
using System.Threading;
using System.Globalization;
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
using System.Windows.Media.Animation;
using System.Runtime.CompilerServices;

namespace DateOfBirth
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dayOfBirth.ItemsSource = days;
            monthOfBirth.ItemsSource = DateTimeFormatInfo.InvariantInfo.MonthNames;
            yearOfBirth.ItemsSource = years;
        }
        //const int MYDAYOFBIRTH = 21;
        const string MYMONTHOFBIRTH = "June";
        const int MYYEAROFBIRTH = 1998;

        int attempts = 1;


        int[] days = Enumerable.Range(1, 31).ToArray();
        int[] years = Enumerable.Range(1980, 40).ToArray();

        private void dayOfBirth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dayOfBirth.SelectedValue.ToString() == "21") {
                verOfDay.Foreground = new SolidColorBrush(Colors.Green);
                verOfDay.Text = "Yes! I was born on this day!";
                monthOfBirth.IsEnabled = true;
            }
            else if (dayOfBirth.SelectedIndex < 20)
            {
                verOfDay.Foreground = new SolidColorBrush(Colors.Red);
                verOfDay.Text = "No! I was born later";
                attempts++;
            }
            else if (dayOfBirth.SelectedIndex > 20)
            {
                verOfDay.Foreground = new SolidColorBrush(Colors.Red);
                verOfDay.Text = "No! I was born before";
                attempts++;
            }
        }

        private void monthOfBirth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (monthOfBirth.SelectedValue.ToString() == MYMONTHOFBIRTH)
            {
                verOfMonth.Foreground = new SolidColorBrush(Colors.Green);
                verOfMonth.Text = "Yes! I was born in this month!";
                yearOfBirth.IsEnabled = true;
            }
            else if (monthOfBirth.SelectedIndex < 5)
            {
                verOfMonth.Foreground = new SolidColorBrush(Colors.Red);
                verOfMonth.Text = "No! I was born later";
                attempts++;
            }
            else if (monthOfBirth.SelectedIndex > 5)
            {
                verOfMonth.Foreground = new SolidColorBrush(Colors.Red);
                verOfMonth.Text = "No! I was born before";
                attempts++;
            }
        }

        private void yearOfBirth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int year = (int)yearOfBirth.SelectedValue;
            if (year == MYYEAROFBIRTH)
            {
                verOfYear.Foreground = new SolidColorBrush(Colors.Green);
                verOfYear.Text = "Yes! I was born in this year!";
                MessageBox.Show("Success! You've guessed the date of my birth! " +
                    "Your attempts: " + attempts);
            }
            else if (year < MYYEAROFBIRTH)
            {
                verOfYear.Foreground = new SolidColorBrush(Colors.Red);
                verOfYear.Text = "No! I was born later";
                attempts++;
            }
            else if (year > MYYEAROFBIRTH)
            {
                verOfYear.Foreground = new SolidColorBrush(Colors.Red);
                verOfYear.Text = "No! I was born before";
                attempts++;
            }
        }
    }
}
