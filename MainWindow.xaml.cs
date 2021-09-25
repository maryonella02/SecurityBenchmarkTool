using System.Windows;

namespace SBT
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

        private void MnuOpen_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Input"; 
            dialog.DefaultExt = ".audit"; 

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string path = dialog.FileName;
                string json = JsonHelper.ShowJSON(path);
                tbMultiLine.Text = json;
            }

        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Output"; 
            dialog.DefaultExt = ".json"; 

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
                JsonHelper.ExportToJsonFile(tbMultiLine.Text, filename);
            }
        }
    }
}
