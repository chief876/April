using April.Custom.SQLite;
using April.Parser.Implimentations;
using April.Parser.Implimentations.Parse;
using April.Parser.Implimentations.POP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace April.Parser
{
    class Program
    {
        static DatabaseContext db;
        static void Main(string[] args)
        {
            //Task_6
            AppDomain.CurrentDomain.UnhandledException += ClientException.Process;
            try
            {
                throw new Exception("1");
            }
            catch (Exception e)
            {
                Console.WriteLine("Catch clause caught : {0} \n", e.Message);
            }
            //throw new Exception("2");
             
            //Task_9
            /*using (AttachmentDownloader ad = new AttachmentDownloader("pop.yandex.ru", 995, true))
            {
                if(ad.authenticate("<your_login>", "<your_pass"))
                {
                    ad.download();
                    Console.WriteLine("Загрузка завершена...");
                }
            }*/

            //Task_5
            db = new DatabaseContext(@".\Resource\apteka_sklad.db");
            parse();
            
            Console.ReadKey();
        }

        static async void parse()
        {
            ParserWorker pw = new ParserWorker("https://apteka-april.ru");
            string[] getLines = await pw.WorkerAsync("product/64954bebilayn-gel-dlya-kupaniya-250ml/"); //ссылка на товар

            addData(getLines[0], Convert.ToInt32(getLines[1]), Convert.ToInt32(getLines[2]), getLines[3]);

            loadTable();
        }
        static void loadTable()
        {
            List<Product> products = db.Products.ToList();
            int count = products.Count();

            string name = "              Наименование              ";
            string maker = "              Производитель              ";
            string header = $" Index | {name} | Цена 1 | Цена 2 | {maker} |";
            Console.WriteLine(header + ("\n").PadRight(header.Length, '='));

            int i = 0;
            foreach (Product p in products)
            {
                Console.WriteLine($" {i.ToString().matchString(5)} | {p.Name.matchString(name.Length)} | {p.Discount_Price.ToString().matchString(5)}р | {p.Price_Without_Discount.ToString().matchString(5)}р | {p.Manufacturer.matchString(maker.Length)} |");
                i++;
            }
        }
        static void addData(string name, int price1, int price2, string manufacturer)
        {
            Product p = new Product() { Name = name, Discount_Price = price1, Price_Without_Discount = price2, Manufacturer = manufacturer };
            db.Products.Add(p);
            db.SaveChanges();
        }
    }
    public static class StringExtension
    {
        public static string matchString(this string line, int length)
        {
            if (string.IsNullOrEmpty(line))
            {
                line = "";
            }
            if(line.Length >= length)
            {
                line = line.Substring(0, length); 
            }
            else
            {
                line = line.PadRight(length);
            } 
            return line;
        }
    }
}
