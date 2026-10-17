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
            /*Console.WriteLine("6.1");
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
            Console.WriteLine($"Согласные: {cg} ");*/


            Console.WriteLine("6.2");
            int[,] ma = { { 1, 2 }, { 3, 4 } };
            int[,] mb = { { 5, 6 }, { 7, 8 } };
            Console.WriteLine("Вывод матрицы А");
            for (int i = 0; i < ma.GetLength(0); i++)
            {
                for (int j = 0; j < ma.GetLength(1); j++)
                    Console.Write(ma[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Вывод матрицы Б");
            for (int i = 0; i < mb.GetLength(0); i++)
            {
                for (int j = 0; j < mb.GetLength(1); j++)
                    Console.Write(mb[i, j] + " ");
                Console.WriteLine();
            }
            int[,] mc = new int[2, 2];

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < 2; k++)
                        sum += ma[i, k] * mb[k, j];
                    mc[i, j] = sum;
                }
            Console.WriteLine("Результат умножения матриц:");
            for (int i = 0; i < mc.GetLength(0); i++)
            {
                for (int j = 0; j < mc.GetLength(1); j++)
                    Console.Write(mc[i, j] + " ");
                Console.WriteLine();
            }
        }   
    }
}
