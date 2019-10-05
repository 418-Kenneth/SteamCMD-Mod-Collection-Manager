using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.Threading;

namespace SteamCMD_Mod_Collection_Manager
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
            var steamexe = new SteamCMD.steamCMD();
            var idlist = new HTTP_Readers.Get_Modcollection();
            var result = await idlist.workshopids(collection_id_textbox.Text);
            log_textbox.Text = steamexe.DownloadMods(game_id_textbox.Text, result, install_path_textbox.Text, SteamPasswordBox.Password, steam_username_textbox.Text, steam_path_textbox.Text);
        }


        private async void RetriveModCollection(object sender, RoutedEventArgs e)
        {
            log_textbox.Text = "";
            var idlist = new HTTP_Readers.Get_Modcollection();
            var result = await idlist.workshopids(collection_id_textbox.Text);

            result.ForEach(a => log_textbox.AppendText(a + Environment.NewLine));
        }

        private void anony_btn_Click(object sender, RoutedEventArgs e)
        {
            if((string)anony_btn.Content == "ON")
            {
                anony_btn.Content = "OFF";
                steam_username_textbox.Text = "";
                SteamPasswordBox.Password = "";
                steam_username_textbox.IsEnabled = true;
                SteamPasswordBox.IsEnabled = true;
            }
            else
            {
                anony_btn.Content = "ON";
                steam_username_textbox.Text = "anonymous";
                SteamPasswordBox.Password = "";
                steam_username_textbox.IsEnabled = false;
                SteamPasswordBox.IsEnabled = false;
            }
        }
    }
}
