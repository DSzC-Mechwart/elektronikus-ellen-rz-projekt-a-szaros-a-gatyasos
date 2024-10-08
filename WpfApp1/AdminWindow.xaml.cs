using System.Windows;
using System.Collections.Generic;
using Adatmodellek;

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
    }
}
