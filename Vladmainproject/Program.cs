using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("1: " + Math.Round(Math.E, 1));

        Console.WriteLine("2:\n50\n10");

        Random rnd = new Random();
        Console.WriteLine("3:");
        for (int i = 0; i < 4; i++)
            Console.WriteLine(rnd.Next(1, 100));

        Console.WriteLine("4: введите число");
        double num4 = double.Parse(Console.ReadLine());
        Console.WriteLine(num4 + 10);

        
        Console.WriteLine("5: введите x");
        double x5 = double.Parse(Console.ReadLine());
        Console.WriteLine(Math.Cos(x5));

        
        Console.WriteLine("6: введите a, b, h");
        double a6 = double.Parse(Console.ReadLine());
        double b6 = double.Parse(Console.ReadLine());
        double h6 = double.Parse(Console.ReadLine());
        double side = Math.Sqrt(h6 * h6 + Math.Pow((b6 - a6) / 2, 2));
        Console.WriteLine(a6 + b6 + 2 * side);

        
        Console.WriteLine("7:");
        Console.WriteLine("Мир Труд Май");
        Console.WriteLine("Мир");
        Console.WriteLine("Труд");
        Console.WriteLine("Май");

        
        Console.WriteLine("8: введите 2 числа");
        double a8 = double.Parse(Console.ReadLine());
        double b8 = double.Parse(Console.ReadLine());
        double t8 = a8; a8 = b8; b8 = t8;
        Console.WriteLine(a8 + " " + b8);

        
        Console.WriteLine("9: введите число");
        double num9 = double.Parse(Console.ReadLine());
        Console.WriteLine("Вы ввели число " + num9);

        
        Console.WriteLine("10: введите a, b, c");
        double a10 = double.Parse(Console.ReadLine());
        double b10 = double.Parse(Console.ReadLine());
        double c10 = double.Parse(Console.ReadLine());
        double d = b10 * b10 - 4 * a10 * c10;
        if (d > 0)
        {
            Console.WriteLine((-b10 + Math.Sqrt(d)) / (2 * a10));
            Console.WriteLine((-b10 - Math.Sqrt(d)) / (2 * a10));
        }
        else if (d == 0)
            Console.WriteLine(-b10 / (2 * a10));
        else
            Console.WriteLine("Корней нет");

        
        Console.WriteLine("11: введите 2 целых числа");
        int a11 = int.Parse(Console.ReadLine());
        int b11 = int.Parse(Console.ReadLine());
        Console.WriteLine("Среднее арифметическое: " + (a11 + b11) / 2.0);
        Console.WriteLine("Среднее геометрическое: " + Math.Sqrt(a11 * b11));
      
        Console.WriteLine("12: введите x1, y1, x2, y2");
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());
        Console.WriteLine(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));

        
        Console.WriteLine("13: введите a, b, c");
        int a13 = int.Parse(Console.ReadLine());
        int b13 = int.Parse(Console.ReadLine());
        int c13 = int.Parse(Console.ReadLine());
        
        int ta = a13, tb = b13, tc = c13;
        b13 = tc; a13 = tb; c13 = ta;
        Console.WriteLine("а) " + a13 + " " + b13 + " " + c13);
        
        ta = a13; tb = b13; tc = c13;
        b13 = ta; c13 = tb; a13 = tc;
        Console.WriteLine("б) " + a13 + " " + b13 + " " + c13);


        Console.WriteLine("14: введите n секунд");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Часов: " + n / 3600);
        Console.WriteLine("Минут с начала часа: " + (n % 3600) / 60);
        Console.WriteLine("Секунд с начала минуты: " + n % 60);

       
        Console.WriteLine("15: " + (543 / 130));

        
        Console.WriteLine("16: введите 3-значное число");
        int num16 = int.Parse(Console.ReadLine());
        Console.WriteLine(num16 % 10 * 100 + num16 / 10);

        
        Console.WriteLine("17: введите n > 999");
        int n17 = int.Parse(Console.ReadLine());
        Console.WriteLine("Сотен: " + (n17 / 100) % 10);
        Console.WriteLine("Тысяч: " + n17 / 1000);

        
        Console.WriteLine("18а: введите имя");
        string name18 = Console.ReadLine();
        Console.WriteLine(name18);
        Console.WriteLine("18б: введите имя");
        name18 = Console.ReadLine();
        Console.WriteLine("Привет, " + name18);

        
        Console.WriteLine("19: поздоровайтесь");
        Console.ReadLine();
        Console.WriteLine("Как вас зовут?");
        string name19 = Console.ReadLine();
        Console.WriteLine("Привет, " + name19);
        Console.WriteLine("Спросите о тайной комнате");
        Console.ReadLine();
        Console.WriteLine("Да");
        Console.WriteLine("Спросите, можете ли рассказать");
        Console.ReadLine();
        Console.WriteLine("Нет");
        System.Threading.Thread.Sleep(5000);
        Console.WriteLine("но могу показать");
        Console.ForegroundColor = (ConsoleColor)rnd.Next(1, 16);
        Console.ResetColor();

        Console.WriteLine("20a: случайные 12 цифр");
        int[] digits = new int[12];
        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            digits[i] = rnd.Next(0, 10);
            Console.Write(digits[i]);
            sum += digits[i] * (i % 2 == 0 ? 1 : 3);
        }
        int check = (10 - sum % 10) % 10;
        Console.WriteLine(" -> контрольная цифра: " + check);

        Console.WriteLine("20b: введите 12 цифр по одной");
        int[] digits2 = new int[12];
        int sum2 = 0;
        for (int i = 0; i < 12; i++)
        {
            digits2[i] = int.Parse(Console.ReadLine());
            sum2 += digits2[i] * (i % 2 == 0 ? 1 : 3);
        }
        Console.WriteLine("Контрольная цифра: " + (10 - sum2 % 10) % 10);
    }
}
