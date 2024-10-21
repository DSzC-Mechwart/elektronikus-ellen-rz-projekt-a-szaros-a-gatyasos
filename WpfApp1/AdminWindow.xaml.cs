using Adatmodellek;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class AdminWindow : Window
    {
        public AdminWindow(List<Tanulo> tanulok)
        {
            InitializeComponent();
            FrissitTanulokAtlagai(tanulok);
            FrissitOsztalyAtlag(tanulok);
        }

        private void FrissitTanulokAtlagai(List<Tanulo> tanulok)
        {
            tanulokAtlagListBox.Items.Clear();

            foreach (var tanulo in tanulok)
            {
                double osszesitettAtlag = tanulo.Targyak.Count > 0
                    ? tanulo.Targyak.Average(t => t.Atlag)
                    : 0;

                bool isAtRisk = tanulo.Targyak.Count(t => t.Atlag < 1.75) >= 3;
                string atlagText = $"{tanulo.Nev} - Összesített átlag: {osszesitettAtlag:F2}" + (isAtRisk ? " (Veszélyeztetett)" : "");

                tanulokAtlagListBox.Items.Add(atlagText);
            }
        }

        private void FrissitOsztalyAtlag(List<Tanulo> tanulok)
        {
            double osztalyAtlag = tanulok.Average(t => t.Targyak.Average(x => x.Atlag));
            var osztalyAtlagText = $"Osztály átlaga: {osztalyAtlag:F2}";
            tanulokAtlagListBox.Items.Add(osztalyAtlagText);
        }
    }
}
