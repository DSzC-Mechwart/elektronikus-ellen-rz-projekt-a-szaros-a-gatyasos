﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ellenorzowpf2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Tantargy> adatok = new List<Tantargy>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Feladat1();
        }
        public void Feladat1()
        {
            string tantargyak = tantargyInput.Text;
            string evfolyam = evfolyamInput.Text;
            string kozvSzak = kozvszakInput.Text;
            string hetioraszam = hetioraszamInput.Text;
            
        }
    }
}