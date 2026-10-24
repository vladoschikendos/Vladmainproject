using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Vladmainproject
{
    internal class Program
    {
       
        static (int glas, int coglas) CountLetters(char[] chars)
        {
            string glas = "аеёиоуыэюяaeiouyАЕЁИОУЫЭЮЯAEIOUY";
            string coglas = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxzБВГДЖЗЙКЛМНПРСТФХЦЧШЩBCDFGHJKLMNPQRSTVWXZ";
            int v = 0, c = 0;
            foreach (char ch in chars)
            {
                if (glas.IndexOf(ch) >= 0) v++;
                else if (coglas.IndexOf(ch) >= 0) c++;
            }
            return (v, c);
        }

        
        static (int glas, int coglas) CountLettersList(List<char> chars)
        {
            string glas = "аеёиоуыэюяaeiouyАЕЁИОУЫЭЮЯAEIOUY";
            string coglas = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxzБВГДЖЗЙКЛМНПРСТФХЦЧШЩBCDFGHJKLMNPQRSTVWXZ";
            int v = 0, c = 0;
            foreach (char ch in chars)          
            {
                if (glas.IndexOf(ch) >= 0) v++;
                else if (coglas.IndexOf(ch) >= 0) c++;
            }
            return (v, c);
        }

        
        static void PrintMatrix(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine();
            }
        }

        static int[,] MultiplyMatrix(int[,] a, int[,] b)
        {
            int n = a.GetLength(0), m = a.GetLength(1), p = b.GetLength(1);
            if (m != b.GetLength(0))
                throw new ArgumentException("Несовместимые размеры матриц");

            int[,] result = new int[n, p];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < p; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < m; k++)
                        sum += a[i, k] * b[k, j];
                    result[i, j] = sum;
                }
            return result;
        }

        
        static void PrintMatrixLinked(LinkedList<LinkedList<int>> m)
        {
            foreach (var row in m)
            {
                foreach (var x in row)
                    Console.Write(x + " ");
                Console.WriteLine();
            }
        }

        static LinkedList<LinkedList<int>> MultiplyMatrixLinked(LinkedList<LinkedList<int>> a,LinkedList<LinkedList<int>> b)
        {
            
            var A = new List<List<int>>();
            foreach (var row in a) A.Add(new List<int>(row));

            var B = new List<List<int>>();
            foreach (var row in b) B.Add(new List<int>(row));

            int n = A.Count, m = A[0].Count, p = B[0].Count;
            if (m != B.Count)
                throw new ArgumentException("Несовместимые размеры матриц");

            var result = new LinkedList<LinkedList<int>>();
            for (int i = 0; i < n; i++)
            {
                var newRow = new LinkedList<int>();
                for (int j = 0; j < p; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < m; k++)
                        sum += A[i][k] * B[k][j];
                    newRow.AddLast(sum);
                }
                result.AddLast(newRow);
            }
            return result;
        }

        static LinkedList<LinkedList<int>> MakeLinkedMatrix(params int[][] rows)
        {
            var m = new LinkedList<LinkedList<int>>();
            foreach (var r in rows)
            {
                var row = new LinkedList<int>();
                foreach (var x in r) row.AddLast(x);
                m.AddLast(row);
            }
            return m;
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

        
        static Dictionary<string, double> AverageByMonthDict(Dictionary<string, int[]> temps)
        {
            var result = new Dictionary<string, double>();
            foreach (var kv in temps)
            {
                int sum = 0;
                foreach (int t in kv.Value) sum += t;
                result[kv.Key] = (double)sum / kv.Value.Length;
            }
            return result;
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("6.1");
            
            string fullPath = @"D:\Влад\Downloads\дз5 текст для 6.1.txt";

            if (!File.Exists(fullPath))
            {
                Console.WriteLine($"Файл не найден: {fullPath}");
            }
            else
            {
                char[] chars = File.ReadAllText(fullPath).ToCharArray();
                var (glas, coglas) = CountLetters(chars);
                Console.WriteLine($"Файл: {fullPath}");
                Console.WriteLine($"Гласных букв: {glas}");
                Console.WriteLine($"Согласных букв: {coglas}");
            }
            Console.WriteLine();

           
            Console.WriteLine("6.2");
            
            int[,] ma = { { 1, 2 }, { 3, 4 } };
            int[,] mb = { { 5, 6 }, { 7, 8 } };

            Console.WriteLine("Вывод матрицы А");
            PrintMatrix(ma);
            Console.WriteLine("Вывод матрицы Б");
            PrintMatrix(mb);

            int[,] mc = MultiplyMatrix(ma, mb);
            Console.WriteLine("Результат умножения матриц:");
            PrintMatrix(mc);
            Console.WriteLine();

           
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
            Console.WriteLine();

           
            Console.WriteLine("ДОМАШНЕЕ ЗАДАНИЕ 6.1 (List<T>)");
            
            if (File.Exists(fullPath))
            {
                
                List<char> charsList = new List<char>(File.ReadAllText(fullPath));
                var (g, c) = CountLettersList(charsList);
                Console.WriteLine($"Файл: {fullPath}");
                Console.WriteLine($"Гласных букв: {g}");
                Console.WriteLine($"Согласных букв: {c}");
            }
            else
            {
                Console.WriteLine($"Файл не найден: {fullPath}");
            }
            Console.WriteLine();

            
            Console.WriteLine("ДОМАШНЕЕ ЗАДАНИЕ 6.2 (LinkedList<LinkedList<int>>)");
            
            var la = MakeLinkedMatrix(new[] { 1, 2 }, new[] { 3, 4 });
            var lb = MakeLinkedMatrix(new[] { 5, 6 }, new[] { 7, 8 });

            Console.WriteLine("Вывод матрицы А");
            PrintMatrixLinked(la);
            Console.WriteLine("Вывод матрицы Б");
            PrintMatrixLinked(lb);

            var lc = MultiplyMatrixLinked(la, lb);
            Console.WriteLine("Результат умножения матриц:");
            PrintMatrixLinked(lc);
            Console.WriteLine();

            
            Console.WriteLine("ДОМАШНЕЕ ЗАДАНИЕ 6.3 (Dictionary<string, int[]>)");
            
            string[] monthNames = { "Январь", "Февраль", "Март", "Апрель", "Май",
                                    "Июнь", "Июль", "Август", "Сентябрь", "Октябрь",
                                    "Ноябрь", "Декабрь" };

            var temperatureDict = new Dictionary<string, int[]>();
            foreach (var name in monthNames)
            {
                int[] days = new int[30];
                for (int d = 0; d < 30; d++)
                    days[d] = rnd.Next(-20, 31);
                temperatureDict[name] = days;
            }

            var avgDict = AverageByMonthDict(temperatureDict);
            Console.WriteLine("Средние температуры по месяцам:");
            foreach (var kv in avgDict)
                Console.WriteLine($"{kv.Key}: {kv.Value:F2}");

            
            var sortedAvg = avgDict.OrderBy(kv => kv.Value).ToList();
            Console.WriteLine("\nОтсортированные средние температуры:");
            foreach (var kv in sortedAvg)
                Console.Write($"{kv.Key}: {kv.Value:F2}  ");
            Console.WriteLine();
        }
    }
}
