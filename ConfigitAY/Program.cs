using ConfigitAYLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigitAY
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"C:\Dev\ConfigitAY\ConfigitAY\testdata");
            foreach (var item in files)
            {
                if (item.Contains("input"))
                {
                    using (DataInput di = new DataInput())
                    {
                        var data = di.GetFile(item);
                        Console.WriteLine(item + " " + data.Check());
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
