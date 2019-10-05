using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SteamCMD_Installation_Manager.SteamCMD
{
    public class steamCMD
    // example of code line to download
    //"steamcmd.exe" +login user password +set_steam_guard_code ####  +force_install_dir c:\does\not\matter +"workshop_download_item 107410 463939057" +"workshop_download_item 107410 463939057" +"workshop_download_item 107410 463939057" +"workshop_download_item 107410 463939057" validate +quit
    // +\"workshop_download_item {4} {5}\"

    {
        /// <summary>
        /// Mod installation Function
        /// </summary>
        /// <param name="gameid"></param>
        /// <param name="modid"></param>
        /// <param name="installdir"></param>
        /// <param name="steampass"></param>
        /// <param name="steamuser"></param>
        /// <param name="steamdir"></param>
        /// <returns></returns>
        public string DownloadMods(string gameid, List<string> modid, string installdir, string steampass, string steamuser, string steamdir)
        {
            var modstring = "";

            modid.ForEach(p => modstring += string.Format(" +\"workshop_download_item {0} {1}\"", gameid, p));

            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = "G:\steam_cmd_test\cmd\";
            startInfo.FileName = steamdir;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = string.Format("+login {0} {1} +force_install_dir '{2}' {3} validate +quit", steamuser, steampass, installdir, modstring);

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                Process exe = new Process();
                exe.StartInfo = startInfo;
                exe.Start();
                exe.WaitForExit();
                exe.Dispose();
                return exe.StandardOutput.ReadLine();
            }
            catch
            {
                return "Error";
                // Log error.
            }
        }

        /// <summary>
        /// Server installation function
        /// </summary>
        /// <param name="gameid"></param>
        /// <param name="modid"></param>
        /// <param name="installdir"></param>
        /// <param name="steampass"></param>
        /// <param name="steamuser"></param>
        /// <param name="steamauth"></param>
        /// <param name="steamdir"></param>
        /// <returns></returns>
        public string InstallServer(string gameid, List<string> modid, string installdir, string steampass, string steamuser, string steamauth, string steamdir)
        {
            var modstring = "";

            modid.ForEach(p => modstring = p);
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = steamdir;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = string.Format("+login {0} {1} +set_steam_guard_code {2} +force_install_dir {3} +\"workshop_download_item {4} {5}\" validate +quit", steamuser, steampass, steamauth, installdir, gameid, modid);

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                Process exe = new Process();
                exe.StartInfo = startInfo;
                exe.Start();
                exe.WaitForExit();
                exe.Dispose();
                return exe.StandardOutput.ReadLine();
            }

            catch
            {
                return "Error";
                // Log error.
            }
        }
    }
}
