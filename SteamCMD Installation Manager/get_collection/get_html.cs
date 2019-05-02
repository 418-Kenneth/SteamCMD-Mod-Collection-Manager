using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using System.Collections;
using System.Net.Http;

using System.IO;


namespace SteamCMD_Installation_Manager.get_html
{
    public class get_html
    {
        string collection_base_string = "https://steamcommunity.com/sharedfiles/filedetails/?id=";      
        public async Task<List<string>> workshopids(string id)
        {
            HttpClient http = new HttpClient();
            HttpResponseMessage response = await http.GetAsync(collection_base_string + id);
            var data = await response.Content.ReadAsStringAsync();
            string[] stringSeparators = new string[] { "\r\n", "," };
            List<string> resultlist = data.Split(stringSeparators, StringSplitOptions.None).ToList<string>();
            var allids = resultlist.Where(p => p.Contains("SharedFileBindMouseHover")).ToList();
            var remove_front = allids.Select(s => s.Remove(0,42)).ToList();
            var done = remove_front.Select(s => s.Remove(s.Length-2,2)).ToList();
            return done;
        }
    }
}
