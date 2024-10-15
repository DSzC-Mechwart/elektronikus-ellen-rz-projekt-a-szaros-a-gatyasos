using System.Windows;
using System.Collections.Generic;
using Adatmodellek;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class AdminWindow : Window
    {
        private List<Tanulo> tanulok;

        public AdminWindow(List<Tanulo> tanulok)
        {
            InitializeComponent();
            this.tanulok = tanulok;
            dataGridStudents.ItemsSource = tanulok;
        }

        private void dataGridStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridStudents.SelectedItem is Tanulo selectedTanulo)
            {
                dataGridSubjects.ItemsSource = selectedTanulo.Targyak;
            }
            else
            {
                dataGridSubjects.ItemsSource = null;
            }
        }
    }
}
