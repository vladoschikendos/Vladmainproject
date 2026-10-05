using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vladmainproject
{
    class Program
    {
        // №1
        static void Task1()
        {
            Console.WriteLine("1. Информация о типах данных:");
            Console.WriteLine($"sbyte   – {sbyte.MaxValue} – {sbyte.MinValue}");
            Console.WriteLine($"byte    – {byte.MaxValue} – {byte.MinValue}");
            Console.WriteLine($"short   – {short.MaxValue} – {short.MinValue}");
            Console.WriteLine($"ushort  – {ushort.MaxValue} – {ushort.MinValue}");
            Console.WriteLine($"int     – {int.MaxValue} – {int.MinValue}");
            Console.WriteLine($"uint    – {uint.MaxValue} – {uint.MinValue}");
            Console.WriteLine($"long    – {long.MaxValue} – {long.MinValue}");
            Console.WriteLine($"ulong   – {ulong.MaxValue} – {ulong.MinValue}");
            Console.WriteLine($"float   – {float.MaxValue} – {float.MinValue}");
            Console.WriteLine($"double  – {double.MaxValue} – {double.MinValue}");
            Console.WriteLine($"decimal – {decimal.MaxValue} – {decimal.MinValue}");
            Console.WriteLine($"char    – {(int)char.MaxValue} – {(int)char.MinValue}");
            Console.WriteLine($"bool    – {bool.TrueString} – {bool.FalseString}");
            Console.WriteLine();
        }

        // №2
        static void Task2()
        {
            Console.WriteLine("2. Ввод данных пользователя:");
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите город: ");
            string city = Console.ReadLine();
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Введите PIN-код: ");
            string pin = Console.ReadLine();
            Console.WriteLine("Введённая информация:");
            Console.WriteLine($"Имя:     {name}");
            Console.WriteLine($"Город:   {city}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"PIN-код: {pin}");
        }

        // №3
        static void Task3()
        {
            Console.WriteLine("3. Преобразование регистра строки:");
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();
            string sb = "";
            foreach (char c in input)
            {
                if (char.IsLower(c))
                    sb.Append(char.ToUpper(c));
                else if (char.IsUpper(c))
                    sb.Append(char.ToLower(c));
                else
                    sb.Append(c);
            }
            Console.WriteLine($"Результат: {sb}");
        }

    }
