﻿using Adatmodellek;
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
        private Tanulo kivalasztottTanulo;

        public MainWindow()
        {
            InitializeComponent();
            tanulok = new List<Tanulo>
            {
                new Tanulo { Nev = "Kiss Péter", Targyak = new List<Targy>
                    {
                        new Targy { Nev = "Matematika" },
                        new Targy { Nev = "Magyar" }
                    }
                },
                new Tanulo { Nev = "Nagy Anna", Targyak = new List<Targy>
                    {
                        new Targy { Nev = "Történelem" },
                        new Targy { Nev = "Angol" }
                    }
                },
                new Tanulo { Nev = "Tóth Gábor", Targyak = new List<Targy>
                    {
                        new Targy { Nev = "Fizika" },
                        new Targy { Nev = "Kémia" }
                    }
                },
                new Tanulo { Nev = "Szabó Laura", Targyak = new List<Targy>
                    {
                        new Targy { Nev = "Biológia" },
                        new Targy { Nev = "Informatika" }
                    }
                }
            };

            tanuloComboBox.ItemsSource = tanulok;
        }

        private void tanuloComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kivalasztottTanulo = tanuloComboBox.SelectedItem as Tanulo;
            targyComboBox.ItemsSource = kivalasztottTanulo?.Targyak;
            FrissitJegyek();
            FrissitLemorzsolodas();
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

        private void FrissitLemorzsolodas()
        {
            if (kivalasztottTanulo != null)
            {
                bool isAtRisk = false;

                foreach (var targy in kivalasztottTanulo.Targyak)
                {
                    double atlag = targy.Atlag;
                    if (atlag < 1.75)
                    {
                        isAtRisk = true;
                        break;
                    }
                }

                lemorzsolodasCheckBox.IsChecked = isAtRisk;
            }
        }


        private void FrissitJegyek()
        {
            jegyekListBox.Items.Clear();
            foreach (var targy in kivalasztottTanulo?.Targyak)
            {
                var atlagText = targy.Atlag < 2.0 ? $" (Átlag: {targy.Atlag:F2})" : $"Átlag: {targy.Atlag:F2}";
                var text = targy.Nev + " " + atlagText;
                var color = targy.Atlag < 2.0 ? Brushes.Red : Brushes.Black;

                var listItem = new ListBoxItem { Content = text, Foreground = color };
                jegyekListBox.Items.Add(listItem);
            }
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Admin nézet megnyitása.");
        }
    }
}
