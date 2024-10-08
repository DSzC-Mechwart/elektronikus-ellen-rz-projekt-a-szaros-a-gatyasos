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
using static System.Net.Mime.MediaTypeNames;
using System.Collections;


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
        List<Tantargy> AllData = new List<Tantargy>();

        public void Feladat1()
        {
            
            string tantargyak = comboboxTan.Text;
            int evfolyam = Convert.ToInt32(comboboxOszt.Text);
            string kozvSzak = comboboxkozszak.Text;
            int hetioraszam = Convert.ToInt32(oraszamInput.Text);
            int evesoraszam =0;
            

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
            Tantargy uj = new(tantargyak, evfolyam, kozvSzak, hetioraszam, evesoraszam);
            evesoszamLabel.Content = evesoraszam;
            adatok.Add(uj);
            AllData.Add(uj);
        }
        public void Feladat2()
        {
            Feladat1();
            string json = JsonSerializer.Serialize(adatok);
            string file = System.IO.Directory.GetCurrentDirectory();
            File.WriteAllText($@"{file}\tantargy.json", json, Encoding.UTF8);
            adatok.Clear();
            
        }
        public void Feladat3()
        {
            Feladat1();
            string fileName = System.IO.Directory.GetCurrentDirectory();
            using (StreamWriter sw = new($@"{fileName}\tantargy.csv", true, Encoding.UTF8))
            {
                sw.WriteLine($"{comboboxTan.Text}; {comboboxOszt.Text}; {comboboxkozszak.Text}; {oraszamInput.Text}; {evesoszamLabel.Content}");
            }
            adatok.Clear();
        }
        private void CsvMentes_Click(object sender, RoutedEventArgs e)
        {
            Feladat3();
        }

        private void JsonMentes_Click(object sender, RoutedEventArgs e)
        {
            Feladat2();
        }
        
        private void JsTorles_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CsvTorles_Click(object sender, RoutedEventArgs e)
        {

            
            
        }
    }
    
}