using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите номер дня в году (1-365): ");
        if (!int.TryParse(Console.ReadLine(), out int dayOfYear) || dayOfYear < 1 || dayOfYear > 365)
        {
            Console.WriteLine("Некорректный ввод. Нужно число от 1 до 365.");
            return;
        }

        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        string[] monthNames = { "января", "февраля", "марта", "апреля", "мая", "июня",
                                "июля", "августа", "сентября", "октября", "ноября", "декабря" };

        int monthIndex = 0;
        while (dayOfYear > daysInMonth[monthIndex])
        {
            dayOfYear -= daysInMonth[monthIndex];
            monthIndex++;
        }

        Console.WriteLine($"{dayOfYear} {monthNames[monthIndex]}");
    }
}