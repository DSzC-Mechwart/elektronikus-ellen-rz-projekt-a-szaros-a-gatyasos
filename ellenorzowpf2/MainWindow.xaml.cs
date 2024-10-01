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
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Specialized;

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

        public void Feladat1()
        {
            string tantargyak = comboboxTan.Text;
            int evfolyam = Convert.ToInt32(comboboxOszt.Text);
            string kozvSzak = comboboxkozszak.Text;
            int hetioraszam = Convert.ToInt32(oraszamInput.Text);
            int evesoraszam =0;
            
            Tantargy uj = new(tantargyak, evfolyam, kozvSzak, hetioraszam, evesoraszam);

                if (evfolyam == 9 || evfolyam == 10 || evfolyam == 11)
                {
                    evesoraszam = hetioraszam * 36;
                    
                }
                else if (evfolyam == 12)
                {
                    if (kozvSzak == "Közismeret")
                    {
                        evesoraszam = hetioraszam * 31;
                    }
                    else
                    {
                        evesoraszam = hetioraszam * 36;
                    }
                }
                else
                {
                    evesoraszam = hetioraszam * 31;
                }
            
            evesoszamLabel.Content = evesoraszam;
            adatok.Add(uj);
        }
        public void Feladat2()
        {
            Feladat1();
            string json = JsonSerializer.Serialize(adatok);
            File.WriteAllText(@"C:\Users\varga.mate\Documents\MATE\Projekt\elektronikus-ellen-rz-projekt-a-szaros-a-gatyasos\ellenorzowpf2\tantargy.json", json);
        }
        public void Feladat3()
        { 
            
        }
        private void CsvMentes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void JsonMentes_Click(object sender, RoutedEventArgs e)
        {
            Feladat2();
        }

    }
}