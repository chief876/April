using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace April.ConvertJsonToDataTable
{
    public static class Convert
    {
        public static DataTable JsonToDataTable(string jsonString)
        {
            try
            {
                return (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
            }
            catch(JsonReaderException ex)
            {
                string message = $"Исключение: {ex.Message}";
                message += "\n\nПример:\n[\n  {\"имя_столбца_1\":\"данные\", \"имя_столбца_2\":\"данные\"},\n  {\"имя_столбца_1\":\"данные\", \"имя_столбца_2\":\"данные\"}\n]";
                MessageBox.Show(message, "Ошибка: Проверьте синтаксис!");
                return null;
            }
        }
        public static string DataTableToJson(DataTable dt)
        {
            return JsonConvert.SerializeObject(dt);
        }
    }
}
