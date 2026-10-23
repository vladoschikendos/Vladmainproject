using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Vladmainproject
{
    internal class Program
    {
        static (int glas, int coglas) CountLetters(char[] chars)
        {
            // Наборы гласных и согласных (русские + английские, строчные и заглавные)
            string glas = "аеёиоуыэюяaeiouyАЕЁИОУЫЭЮЯAEIOUY";
            string coglas = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxzБВГДЖЗЙКЛМНПРСТФХЦЧШЩBCDFGHJKLMNPQRSTVWXZ";

            int v = 0, c = 0;

            // Проход по массиву символов
            foreach (char ch in chars)
            {
                if (glas.IndexOf(ch) >= 0) v++;
                else if (coglas.IndexOf(ch) >= 0) c++;
            }

            return (v, c);
        }
        static double[] AverageByMonth(int[,] temperature)
        {
            int months = temperature.GetLength(0);
            int days = temperature.GetLength(1);
            double[] avg = new double[months];

            for (int m = 0; m < months; m++)
            {
                int sum = 0;
                for (int d = 0; d < days; d++)
                    sum += temperature[m, d];
                avg[m] = (double)sum / days;
            }
            return avg;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("6.1");

            string fullPath = @"D:\Влад\Downloads\дз5 текст для 6.1.txt";

            if (!File.Exists(fullPath))
            {
                Console.WriteLine($"Файл не найден: {fullPath}");
                return;
            }

            // Читаем содержимое файла в массив символов
            char[] chars = File.ReadAllText(fullPath).ToCharArray();

            // Подсчёт гласных и согласных
            var (glas, coglas) = CountLetters(chars);

            Console.WriteLine($"Файл: {fullPath}");
            Console.WriteLine($"Гласных букв: {glas}");
            Console.WriteLine($"Согласных букв: {coglas}");


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


            Console.WriteLine("6.3");
            Random rnd = new Random();
            int[,] temperature = new int[12, 30];
            for (int m = 0; m < 12; m++)
                for (int d = 0; d < 30; d++)
                    temperature[m, d] = rnd.Next(-20, 31);

            double[] avg = AverageByMonth(temperature);
            Console.WriteLine("Средние температуры по месяцам:");
            for (int m = 0; m < 12; m++)
                Console.WriteLine($"Месяц {m + 1}: {avg[m]:F2}");

            Array.Sort(avg);
            Console.WriteLine("\nОтсортированные средние температуры:");
            foreach (double t in avg)
                Console.Write($"{t:F2}  ");
            Console.WriteLine();
        }   
    }
}
