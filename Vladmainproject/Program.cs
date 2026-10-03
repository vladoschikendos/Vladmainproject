using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите номер дня в году: ");
        int dy = int.Parse(Console.ReadLine());

        int[] dm = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        string[] mN = { "января", "февраля", "марта", "апреля", "мая", "июня","июля", "августа", "сентября", "октября", "ноября", "декабря" };

        int mI = 0;
        while (dy > dm[mI])
        {
            dy -= dm[mI];
            mI++;
        }

        Console.WriteLine($"{dy} {mN[mI]}");
    }
}