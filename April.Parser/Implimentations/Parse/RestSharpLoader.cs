using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace April.Parser.Implimentations.Parse
{
    class RestSharpLoader
    {
        readonly RestClient client;
        readonly string url;
        public RestSharpLoader(string baseUrl)
        {
            client = new RestClient(baseUrl);
            url = baseUrl;
        }
        public string GetSourceByPage(string page)
        {
            var currentUrl = $"{url}/{page}/";
            var request = new RestRequest(currentUrl, Method.GET);
            var responce = client.Execute(request);
            string source = null;

            if (responce != null && responce.StatusCode == HttpStatusCode.OK)
            {
                source = responce.Content;
            }
            return source;
        }
    }
}
