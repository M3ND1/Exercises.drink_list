using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;
namespace drink_list_json
{
    public class DisplayTable
    {
        public static void display<T>(List<T> list, string tableName) where T : class
        {
            Console.Clear();
            ConsoleTableBuilder
                .From(list)
                .WithColumn(tableName)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine(TableAligntment.Left);
        }
    }
}
