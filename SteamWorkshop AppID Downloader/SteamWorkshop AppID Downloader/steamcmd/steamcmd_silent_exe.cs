using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Steam_Workshop_Collection_Downloader.steamcmd
{
    public class steamcmd_silent_exe
    {
        public void LaunchCommandLineApp()
        {
            // For the example
            const string ex1 = "C:\\";
            const string ex2 = "C:\\Dir";

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
            }
            catch
            {
                // Log error.
            }
        }
    }
}
