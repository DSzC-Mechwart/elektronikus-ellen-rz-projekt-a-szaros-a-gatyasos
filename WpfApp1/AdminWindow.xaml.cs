using System.Windows;

namespace WpfApp1
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            LoadSubjectAverages();
        }

        private void LoadSubjectAverages()
        {
            SubjectAverageList.Items.Add("Matematika: 4.5");
            SubjectAverageList.Items.Add("Történelem: 3.7");
            SubjectAverageList.Items.Add("Fizika: 4.0");
            SubjectAverageList.Items.Add("Informatika: 3.2");
        }
    }
}
