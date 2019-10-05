using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using System.Collections;
using System.Net.Http;

using System.IO;


namespace SteamCMD_Installation_Manager.HTTP_Readers
{
    public class Get_Modcollection
    {
        private const string collection_base_string = "https://steamcommunity.com/sharedfiles/filedetails/?id=";      

        /// <summary>
        /// Get ID's Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<string>> workshopids(string id)
        {
            try
            {
                HttpClient httpclient = new HttpClient();
                HttpResponseMessage response = await httpclient.GetAsync(collection_base_string + id);
                var data = await response.Content.ReadAsStringAsync();
                string[] stringSeparators = new string[] { "\r\n", "," };
                List<string> result = data.Split(stringSeparators, StringSplitOptions.None).ToList<string>().Where(p => p.Contains("SharedFileBindMouseHover")).Select(s => s.Remove(0, 42)).Select(b => b.Remove(b.Length - 2, 2)).ToList(); ;
                httpclient.Dispose();
                response.Dispose();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return new List<string> {"Error no string"};
            }
        }
    }
}
