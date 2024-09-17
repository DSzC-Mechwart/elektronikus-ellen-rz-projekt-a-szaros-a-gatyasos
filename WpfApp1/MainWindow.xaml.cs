using System.Windows;
using System.Windows.Controls;
using WpfApp1.Adatmodellek;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Name == "StudentNameInput")
                    StudentNamePlaceholder.Visibility = string.IsNullOrWhiteSpace(textBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                else if (textBox.Name == "GradeInput")
                    GradePlaceholder.Visibility = string.IsNullOrWhiteSpace(textBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                else if (textBox.Name == "TopicInput")
                    TopicPlaceholder.Visibility = string.IsNullOrWhiteSpace(textBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                else if (textBox.Name == "AssessmentTypeInput")
                    AssessmentPlaceholder.Visibility = string.IsNullOrWhiteSpace(textBox.Text) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void BejelentkezesGomb_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bejelentkezés sikeres!");
            LoginScreen.Visibility = Visibility.Collapsed;
            GradeInputScreen.Visibility = Visibility.Visible;
        }

        private void JegyHozzaadGomb_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Jegy hozzáadva!");
        }

        private void AdminGomb_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
        }
    }
}
