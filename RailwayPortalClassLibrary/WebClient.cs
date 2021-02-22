using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace RailwayPortalClassLibrary
{
    public class WebClient
    {
        private HttpClient client;
        private string URL;

        public WebClient(string URL)
        {
            client = new HttpClient();
            this.URL = URL;
        }

        public T Send<T>(HttpMethod method, string path, params object[] args)
        {
            var jsonvalues = JsonConvert.SerializeObject(args.Length == 1 ? args[0] : args);
            var requestResult = client.SendAsync(new HttpRequestMessage()
            {
                RequestUri = new Uri(URL + '/' + path),
                Method = method,
                Content = new StringContent(jsonvalues, Encoding.UTF8, "application/json")
            }).Result;
            var content = requestResult.Content.ReadAsStringAsync().Result;
            T result = JsonConvert.DeserializeObject<T>(content);
            if (result == null)
            {
                result = default(T);
            }

            return result;
        }
    }
}
