using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April.Parser.Implimentations.Parse
{
    class ParserWorker
    {
        RestSharpLoader loader;
        private string baseUrl;
        private string page;
        public ParserWorker(string baseUrl)
        {
            this.baseUrl = baseUrl;
            loader = new RestSharpLoader(baseUrl);
        }

        public async Task<string[]> WorkerAsync(string page)
        {
            var source = loader.GetSourceByPage(page);
            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(source);

            string[] arr = new string[]
            {
                AptekaParser.getName(document),
                AptekaParser.getDiscount(document)[0],
                AptekaParser.getDiscount(document)[1],
                AptekaParser.getMaker(document)
            };

            return arr;
        }
    }
}
