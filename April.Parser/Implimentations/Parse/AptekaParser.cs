using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April.Parser.Implimentations.Parse
{
    public static class AptekaParser
    {
        public static string getName(IHtmlDocument document)
        {
            string result = null;
            var items = document.QuerySelectorAll("h1").Where(item => item.ClassName != null && item.ClassName.Contains("product__title"));

            foreach (var item in items)
            {
                result = item.TextContent;
            }
            if (!String.IsNullOrEmpty(result))
            {
                alignString(ref result);
            }
            return result;
        }
        public static string getMaker(IHtmlDocument document)
        {
            string result = null;
            var items = document.QuerySelectorAll("li").Where(item => item.ClassName != null && item.ClassName.Contains("product__info-list-item"));

            foreach (var item in items)
            {
                if (item.TextContent.ToLower().Contains("производитель")) result = item.TextContent;
            }
            if (!String.IsNullOrEmpty(result))
            {
                alignString(ref result);
                result = result.Replace("Производитель:", "");
            }
            return result;
        }
        public static string[] getDiscount(IHtmlDocument document)
        {
            string[] arr = new string[2];
            int a = 0;
            string line = null;
            List<string> list = new List<string>();
            var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("price price-block__price"));

            foreach (var item in items)
            {
                if (item.TextContent.ToLower().Contains("цена")) line = item.TextContent;
                list.Add(item.TextContent);
            }
            if (!String.IsNullOrEmpty(line))
            {
                alignString(ref line);
                char[] c = line.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == ':')
                    {
                        while (c[i] != 'p')
                        {
                            i++;
                            if (c[i] == 'p')
                            {
                                a++;
                                break;
                            }
                            else
                            {
                                arr[a] += c[i].ToString();
                            }
                        }
                    }
                    if (a == 2)
                    {
                        break;
                    }
                }
            }
            return arr;
        }
        private static void alignString(ref string line)
        {
            line = line.Replace("\n", "");
            line = line.Replace("  ", "");
        }
    }
}
