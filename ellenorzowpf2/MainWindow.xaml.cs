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
            string json = JsonSerializer.Serialize(AllData);
            string file = System.IO.Directory.GetCurrentDirectory();
            File.WriteAllText($@"{file}\tantargy.json", json, Encoding.UTF8);
            adatok.Clear();
        }
        public void Feladat3()
        {
            string fileName = System.IO.Directory.GetCurrentDirectory();
            using (StreamWriter sw = new($@"{fileName}\tantargy.csv", true, Encoding.UTF8))
            {
                sw.WriteLine($"{comboboxTan.Text}; {comboboxOszt.Text}; {comboboxkozszak.Text}; {oraszamInput.Text}; {evesoszamLabel.Content}");
            }
            adatok.Clear();
        }
        private void CsvMentes_Click(object sender, RoutedEventArgs e)
        {
            Feladat1();
            Feladat3();
        }

        private void JsonMentes_Click(object sender, RoutedEventArgs e)
        {
            Feladat1();
            Feladat2();
        }
        
        private void JsTorles_Click(object sender, RoutedEventArgs e)
        {
            string fileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "tantargy.json");
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                List<Tantargy> data = JsonSerializer.Deserialize<List<Tantargy>>(json);

                if (data != null && data.Count > 0)
                {
                    data.RemoveAt(data.Count - 1);

                    string updatedJson = JsonSerializer.Serialize(data);
                    File.WriteAllText(fileName, updatedJson, Encoding.UTF8);
                }
            }
        }

        private void CsvTorles_Click(object sender, RoutedEventArgs e)
        {
            string fileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "tantargy.csv");

            if (File.Exists(fileName))
            {
                var lines = File.ReadAllLines(fileName).ToList();

                if (lines.Count > 0)
                {
                    lines.RemoveAt(lines.Count - 1);

                    File.WriteAllLines(fileName, lines, Encoding.UTF8); 
                }
            }
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            Kimutatast();

        }
        public void Kimutatast()
        {
            var kimutatas = new StringBuilder();

            var csoportok = AllData.GroupBy(x => x.Evfolyam)
                .OrderBy(x => x.Key);  

            foreach (var evfolyamCsoport in csoportok)
            {
                int evfolyam = evfolyamCsoport.Key;

               
                var szakmaiCsoportok = evfolyamCsoport.GroupBy(x => x.Kozvszak)
                    .OrderBy(x => x.Key);

                kimutatas.AppendLine($"Évfolyam: {evfolyam}");

                int osszesKozismeretiOra = 0;
                int osszesSzakmaiOra = 0;

                foreach (var szakCsoport in szakmaiCsoportok)
                {
                    string szakma = szakCsoport.Key;
                    int tantargySzam = szakCsoport.Count();
                    int osszOraszam = szakCsoport.Sum(x => x.EvesOraSzam);

                    kimutatas.AppendLine($"  {szakma}: {tantargySzam} tantárgy, {osszOraszam} óra");

                    if (szakma == "Közismeret")
                    {
                        osszesKozismeretiOra += osszOraszam;
                    }
                    else if (szakma == "Szakma")
                    {
                        osszesSzakmaiOra += osszOraszam;
                    }
                }

                int osszesOra = osszesKozismeretiOra + osszesSzakmaiOra;

               
                kimutatas.AppendLine($"  Összes közismereti óraszám: {osszesKozismeretiOra}");
                kimutatas.AppendLine($"  Összes szakmai óraszám: {osszesSzakmaiOra}");
                kimutatas.AppendLine($"  Összesített óraszám: {osszesOra}");
                kimutatas.AppendLine();
            }

           
            kimutatasTextBlock.Text = kimutatas.ToString();
        }
        Dictionary<string, List<string>> tanuloTantargyak = new Dictionary<string, List<string>>();

        private void HozzarendelesButton_Click(object sender, RoutedEventArgs e)
        {
            string kivantTanulo = (comboboxTanulo.SelectedItem as ComboBoxItem)?.Content.ToString();
            string kivantTantargy = (comboboxTan.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (kivantTanulo != null && kivantTantargy != null)
            {
                if (!tanuloTantargyak.ContainsKey(kivantTanulo))
                {
                    tanuloTantargyak[kivantTanulo] = new List<string>();
                }

                tanuloTantargyak[kivantTanulo].Add(kivantTantargy);

                listBoxTantargyak.Items.Clear();
                foreach (var tantargy in tanuloTantargyak[kivantTanulo])
                {
                    listBoxTantargyak.Items.Add(tantargy);
                }
            }
        }
    }
    
}