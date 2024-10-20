using Adatmodellek;
using System.Collections.Generic;
using System.Windows;

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

        private void dataGridStudents_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGridStudents.SelectedItem is Tanulo selectedTanulo)
            {
                dataGridSubjects.ItemsSource = selectedTanulo.Targyak;
            }
        }
    }
}
