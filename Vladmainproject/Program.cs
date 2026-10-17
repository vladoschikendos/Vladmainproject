using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Vladmainproject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("6.1");
            Console.Write("Введите имя файла:");
            string[] file = new string[1];
            file[0] = Console.ReadLine();
            int cg = 0;
            int g = 0;
            string glas = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";
            string soglas = "бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩ";
            foreach (var item in file[0])
            {
                Console.WriteLine(item);
                if (glas.IndexOf(item) >= 0)
                    g++;
                else if (soglas.IndexOf(item) >= 0)
                    cg++;
            }
            Console.WriteLine($"Гласные: {g} ");
            Console.WriteLine($"Согласные: {cg} ");


            Console.WriteLine("6.2");
        }
    }
}
