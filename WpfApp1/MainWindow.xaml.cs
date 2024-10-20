using Adatmodellek;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private List<Tanulo> tanulok;
        private Tanulo? kivalasztottTanulo;

        public MainWindow()
        {
            InitializeComponent();
            tanulok = new List<Tanulo>
            {
                new Tanulo { Nev = "Palotai Péter", Targyak = new List<Targy>
                    {
                        new Targy { Nev = "Szoftverfejlesztés" },
                        new Targy { Nev = "Irodalom" },
                        new Targy { Nev = "Matematika" }
                    }
                },
                new Tanulo { Nev = "Berta Benedek", Targyak = new List<Targy>
                    {
                        new Targy { Nev = "Szoftverfejlesztés" },
                        new Targy { Nev = "Irodalom" },
                        new Targy { Nev = "Matematika" }
                    }
                },
                new Tanulo { Nev = "Varga Máté", Targyak = new List<Targy>
                    {
                        new Targy { Nev = "Szoftverfejlesztés" },
                        new Targy { Nev = "Irodalom" },
                        new Targy { Nev = "Matematika" }
                    }
                },
                new Tanulo { Nev = "Terdik Gergő", Targyak = new List<Targy>
                    {
                        new Targy { Nev = "Szoftverfejlesztés" },
                        new Targy { Nev = "Irodalom" },
                        new Targy { Nev = "Matematika" }
                    }
                }
            };

            tanuloComboBox.ItemsSource = tanulok;
        }

        private void tanuloComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kivalasztottTanulo = tanuloComboBox.SelectedItem as Tanulo;
            if (kivalasztottTanulo != null)
            {
                targyComboBox.ItemsSource = kivalasztottTanulo.Targyak;
                FrissitJegyek();
                FrissitLemorzsolodas();
            }
        }


        private void FrissitLemorzsolodas()
        {
            if (kivalasztottTanulo != null)
            {
                bool isAtRisk = kivalasztottTanulo.Targyak.Count(t => t.Atlag < 1.75) >= 3;
                lemorzsolodasCheckBox.IsChecked = isAtRisk;
            }
        }

        private void AddJegy_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(jegyErtekTextBox.Text, out double ertek) && targyComboBox.SelectedItem is Targy kivalasztottTargy)
            {
                var jegy = new Jegy
                {
                    Ertek = ertek,
                    Tema = jegyTemaTextBox.Text,
                    SzamonkeresTipus = szamonkeresTipusTextBox.Text
                };

                kivalasztottTargy.Jegyek.Add(jegy);

                FrissitJegyek();
                FrissitLemorzsolodas();
            }
        }

        private void FrissitJegyek()
        {
            jegyekListBox.Items.Clear();
            jegyekScrollPanel.Children.Clear();

            if (kivalasztottTanulo != null)
            {
                foreach (var targy in kivalasztottTanulo.Targyak)
                {
                    var atlagText = targy.Atlag < 2.0 ? $" (Átlag: {targy.Atlag:F2})" : $"Átlag: {targy.Atlag:F2}";
                    var text = targy.Nev + " " + atlagText;
                    var color = targy.Atlag < 2.0 ? Brushes.Red : Brushes.Black;

                    var listItem = new ListBoxItem { Content = text, Foreground = color };
                    jegyekListBox.Items.Add(listItem);

                    foreach (var jegy in targy.Jegyek)
                    {
                        var jegyTextBlock = new TextBlock
                        {
                            Text = $"Jegy: {jegy.Ertek} - Tantárgy: {targy.Nev}",
                            Margin = new Thickness(5),
                            ToolTip = $"Téma: {jegy.Tema}\nSzámonkérés típusa: {jegy.SzamonkeresTipus}"
                        };

                        jegyTextBlock.MouseEnter += (s, ev) => jegyTextBlock.Foreground = Brushes.Blue;
                        jegyTextBlock.MouseLeave += (s, ev) => jegyTextBlock.Foreground = Brushes.Black;

                        jegyekScrollPanel.Children.Add(jegyTextBlock);
                    }
                }
            }
        }


        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow(tanulok);
            adminWindow.ShowDialog();
        }
    }
}
