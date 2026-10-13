using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("№4.1");
        Console.Write("Введите номер дня в году: ");
        int dy = int.Parse(Console.ReadLine());

        int[] dm = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        string[] mN = { "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };

        int mI = 0;
        while (dy > dm[mI])
        {
            dy -= dm[mI];
            mI++;
        }

        Console.WriteLine($"{dy} {mN[mI]}");

        Console.WriteLine("№4.2");

        Console.Write("Введите номер дня в году: ");

        try
        {
            int dy2 = int.Parse(Console.ReadLine());


            if (dy2 < 1 || dy2 > 365)
            {
                Console.WriteLine("Число должно быть в диапазоне от 1 до 365!");
            }

            int[] dm2 = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] mN2 = { "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };

            int mI2 = 0;
            while (dy2 > dm2[mI2])
            {
                dy2 -= dm2[mI2];
                mI2++;
            }

            Console.WriteLine($"{dy2} {mN2[mI2]}");
        }
        catch
        {
        }
        Console.WriteLine("ДОмашнее задание 4.1");
        Console.Write("Введите год: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Введите номер дня в году: ");
        int dy3 = int.Parse(Console.ReadLine());

        bool Leap = (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);

        int[] dm3;
        if (Leap)
        {
            dm3 = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        }
        else
        {
            dm3 = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        }

        string[] mN3 = { "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };

        int mI3 = 0;
        while (dy3 > dm3[mI3])
        {
            dy3 -= dm3[mI3];
            mI3++;
        }

        Console.WriteLine($"{dy3} {mN3[mI3]}");
    }
}