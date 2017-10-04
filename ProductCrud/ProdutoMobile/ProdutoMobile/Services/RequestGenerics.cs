using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace ProdutoMobile.Services
{
    public class RequestGenerics<T>
    {
        
        private static string UriApi { get { return "http://localhost:57116/api/"; } }

        public static async Task<List<T>> GetJson(int? id, string uri)
        {
            try
            {
                #region RequestJson
                System.Net.Http.HttpClient httpClientTeste = new System.Net.Http.HttpClient();
                httpClientTeste.DefaultRequestHeaders.Accept.TryParseAdd("application/json");
                //UriApi
                var uriId = UriApi + uri;
                if (id != null || id != 0)
                {
                    uriId += id;
                }
                string ResponseStringTeste = await httpClientTeste.GetStringAsync(new Uri(uriId));
                var jsonTeste = JsonConvert.DeserializeObject<List<T>>(ResponseStringTeste);
                return (List<T>)jsonTeste;
                #endregion
            }
            catch (Exception ex)
            {
                return null;
            }

        }
       

    }
}
