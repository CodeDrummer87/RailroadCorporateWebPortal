using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace RailwayPortalClassLibrary
{
    public class AppWebClient
    {
        private static HttpClient client;
        private string URL;

        public AppWebClient(string URL)
        {
            client = new HttpClient();
            this.URL = URL;
            //System.Net.ServicePointManager.DnsRefreshTimeout = 120000;
            var servicePoint = System.Net.ServicePointManager.FindServicePoint(new Uri(URL));
            servicePoint.ConnectionLeaseTimeout = 0;
        }

        public User Send<T>(HttpMethod method, string path, params object[] args)
        {
            var jsonvalues = JsonConvert.SerializeObject(args.Length == 1 ? args[0] : args);
            var requestResult = client.SendAsync(new HttpRequestMessage()
            {
                RequestUri = new Uri(URL + '/' + path),
                Method = method,
                Content = new StringContent(jsonvalues, Encoding.UTF8, "application/json")
            }).Result;
            var content = requestResult.Content.ReadAsStringAsync().Result;
            User result = JsonConvert.DeserializeObject<User>(content);
            if (result == null)
            {
                result = default(User);
            }

            return result;
        }

        public SessionModel Get<T>(string path)
        {
            var requestResult = client.SendAsync(new HttpRequestMessage()
            {
                RequestUri = new Uri(URL + '/' + path),
                Method = HttpMethod.Get
            }).Result;
            var content = requestResult.Content.ReadAsStringAsync().Result;
            SessionModel model = JsonConvert.DeserializeObject<SessionModel>(content);
            if (model == null)
            {
                model = default(SessionModel);
            }

            return model;
        }
    }
}
