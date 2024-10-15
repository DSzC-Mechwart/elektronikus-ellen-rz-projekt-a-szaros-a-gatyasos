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

namespace Project_WPFapp
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

        // Kollégista checkbox eseménykezelő
        private void chkKollegista_Checked(object sender, RoutedEventArgs e)
        {
            // Ha be van pipálva a kollégista checkbox, akkor láthatóvá tesszük a kollégiumi mezőt
            if (chkKollegista.IsChecked == true)
            {
                lblKollName.Visibility = Visibility.Visible;
                txtKollName.Visibility = Visibility.Visible;
            }
            else
            {
                lblKollName.Visibility = Visibility.Collapsed;
                txtKollName.Visibility = Visibility.Collapsed;
            }
        }

        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            string nev = txtNev.Text;
            string szulHely = txtSzulHely.Text;
            DateTime szulIdo = dpSzulIdo.SelectedDate.HasValue ? dpSzulIdo.SelectedDate.Value : DateTime.MinValue;
            string anyjaNeve = txtAnyjaNeve.Text;
            string lakcim = txtLakcim.Text;
            DateTime beiratkozasDatuma = dpBeiratkozas.SelectedDate.HasValue ? dpBeiratkozas.SelectedDate.Value : DateTime.MinValue;
            string szak = txtSzak.Text;
            string osztaly = txtOsztaly.Text;
            bool kollegista = chkKollegista.IsChecked == true;
            string kollName = txtKollName.Text;
            string telefon = txtTelefon.Text;
            string email = txtEmail.Text;

            
            string output = $"Név: {nev}\n" +
                            $"Születési hely: {szulHely}\n" +
                            $"Születési idő: {szulIdo.ToShortDateString()}\n" +
                            $"Anyja neve: {anyjaNeve}\n" +
                            $"Lakcím: {lakcim}\n" +
                            $"Beiratkozás dátuma: {beiratkozasDatuma.ToShortDateString()}\n" +
                            $"Szak: {szak}\n" +
                            $"Osztály: {osztaly}\n" +
                            $"Kollégista: {(kollegista ? "Igen" : "Nem")}\n" +
                            $"{(kollegista ? $"Kollégium neve: {kollName}\n" : "")}" +
                            $"Telefon: {telefon}\n" +
                            $"Email: {email}";

            MessageBox.Show(output, "Mentett adatok");
        }
    }

}