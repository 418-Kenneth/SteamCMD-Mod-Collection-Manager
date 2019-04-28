using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Steam_Workshop_Collection_Downloader.steamcmd
{
    public class steamcmd_silent_exe
    // example of code line to download
    //"steamcmd.exe" +login user password +set_steam_guard_code ####  +force_install_dir c:\does\not\matter +"workshop_download_item 107410 463939057" +"workshop_download_item 107410 463939057" +"workshop_download_item 107410 463939057" +"workshop_download_item 107410 463939057" validate +quit
    {
        public int LaunchCommandLineApp(string gameid, List<string> modid, string steamdir, string steampass, string steamuser, string steamauth)
        {
            // For the example
            const string ex1 = "+login";
            const string ex2 = "+set_steam_guard_code";
            const string ex3 = "+force_install_dir";
            const string ex4 = "+\"workshop_download_item";
            const string ex5 = "validate";
            const string ex6 = "+quit";
            //const string ex7 = "validate";
            //const string ex8 = "+quit";
            //const string ex9 = "";




            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "SteamCMD.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y " + ex2;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
                return 0;
            }
            catch
            {
                return -1;
                // Log error.
            }
        }
    }
}
