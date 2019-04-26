using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using System.Collections;
using System.Net.Http;

using System.IO;


namespace Steam_Workshop_Collection_Downloader.get_html
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
            
            
           
            //Replace("SharedFileBindMouseHover", ""));
            //var test = resultlist.Select(p => p.Contains("sharedfile_"));

            List<string> result = null;
            return result;
        }
    }
}
