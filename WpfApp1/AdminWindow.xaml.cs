using System.Collections.Generic;
using System.Windows;

namespace TanuloApp
{
    public partial class AdminWindow : Window
    {
        public AdminWindow(List<Tanulo> tanulok)
        {
            InitializeComponent();
            MegjelenitAtlagokat(tanulok);
        }

        private void MegjelenitAtlagokat(List<Tanulo> tanulok)
        {
            targyAtlagokListBox.Items.Clear();
            tanuloAtlagokListBox.Items.Clear();

            foreach (var tanulo in tanulok)
            {
                foreach (var targy in tanulo.Targyak)
                {
                    targyAtlagokListBox.Items.Add($"{targy.Nev}: Átlag - {targy.Atlag:F2}");
                }

                tanuloAtlagokListBox.Items.Add($"{tanulo.Nev}: Összesített átlag - {tanulo.OsszesitettAtlag:F2}");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
