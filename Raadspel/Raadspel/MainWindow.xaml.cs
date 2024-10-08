using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Raadspel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dateTimeLabel.Content = DateTime.Now;
        }

        Random randomNumber = new Random();
        int number;
        int attempts = 0;

        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            number = randomNumber.Next(1, 101);
            attempts = 0;
            resultTextBox.Clear();
            attemptsTextBox.Clear();
        }

        private void evaluateButton_Click(object sender, RoutedEventArgs e)
        {
            if (number != 0)
            {



                int gok;
                bool input = int.TryParse(numberTextBox.Text, out gok);

                if (gok > number)
                {
                    resultTextBox.Text = "Raad lager!";
                    attempts = attempts + 1;
                    numberTextBox.Clear();
                    numberTextBox.Focus();
                }

                else if (gok < number)
                {
                    resultTextBox.Text = "Raad hoger!";
                    attempts++;
                    numberTextBox.Clear();
                    numberTextBox.Focus();
                }

                else
                {
                    attempts++;
                    resultTextBox.Text = "Proficiat! U heeft het getal geraden!";
                    attemptsTextBox.Text = "Aantal keer geraden: " + attempts.ToString();
                }
            }
            else
            {
                resultTextBox.Text = "Klik eerst op 'Nieuw' om een getal te genereren!";
            }
        }
    }
}