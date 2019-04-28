using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Web;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Steam_Workshop_Collection_Downloader.get_html;

namespace Steam_Workshop_Collection_Downloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> items;
        public string dialogputput = "";

        public MainWindow()
        {
            InitializeComponent();
        }
        /// Path for steamCMD
        private void Steam_getpath_button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                steam_path_textbox.Text = openFileDlg.FileName;
            }
        }
        /// Install directory 
        private void Install_getpath_button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog openfolder = new FolderBrowserDialog();
            DialogResult result = openfolder.ShowDialog();
            install_path_textbox.Text = openfolder.SelectedPath;
        }

        /// Launch
        private async void Start_download_Click(object sender, RoutedEventArgs e)
        {
            log_textbox.Text = "";
            var steamexe = new steamcmd.steamcmd_silent_exe();
            var idlist = new get_html.get_html();
            var result = await idlist.workshopids(collection_id_textbox.Text);

            var feedback = steamexe.LaunchCommandLineApp(game_id_textbox.Text, result, install_path_textbox.Text, SteamPasswordBox.Password, steam_username_textbox.Text, AuthTextbox.Text, steam_path_textbox.Text);
            //var result = await idlist.workshopids(collection_id_textbox.Text);

            //result.ForEach(a => log_textbox.AppendText(a + Environment.NewLine));

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            log_textbox.Text = "";
            var idlist = new get_html.get_html();
            var result = await idlist.workshopids(collection_id_textbox.Text);

            result.ForEach(a => log_textbox.AppendText(a + Environment.NewLine));

        }
    }
}
