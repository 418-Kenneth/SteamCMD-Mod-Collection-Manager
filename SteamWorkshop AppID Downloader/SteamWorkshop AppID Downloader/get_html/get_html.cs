using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using System.Collections;
using System.Net.Http;

using System.IO;
using HtmlAgilityPack;

namespace Steam_Workshop_Collection_Downloader.get_html
{
    public class get_html
    {

        string collection_base_string = "https://steamcommunity.com/sharedfiles/filedetails/?id=";
        private List<string> result;

        public async Task<List<string>> workshopids(string id)
        {
            HttpClient http = new HttpClient();
            

            HttpResponseMessage response = await http.GetAsync(collection_base_string + id);
            Stream stream = await response.Content.ReadAsStreamAsync();
            
            var doc = new HtmlDocument();
            doc.LoadHtml(stream.ToString());
            //var nodes = doc.DocumentNode.SetAttributeValue


            //List<string> result = null;

            return result;
        }
    }
}
