using System;
using System.Text;

namespace Vladmainproject
{
    enum DaysOfWeek
    {
        Понедельник = 1,
        Вторник = 2,
        Среда = 3,
        Четверг = 4,
        Пятница = 5,
        Суббота = 6,
        Воскресенье = 7
    }

    class Program
    {
        static void Task1()
        {
            int[] s = {2, 5, 8, 12, 13, 15, 18, 17, 25, 30 };

            bool isSorted = true;
            int vI = -1;

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] >= s[i + 1])
                {
                    isSorted = false;
                    vI = i + 1;
                    break;
                }
            }

            if (isSorted)
            {
                Console.WriteLine("Последовательность упорядочена по возрастанию.");
            }
            else
            {
                Console.WriteLine($"Первое нарушение на позиции: {vI}");
            }
            Console.WriteLine();
        }

        static void Task2()
        {
            try
            {
                int k = int.Parse(Console.ReadLine());

                if (k < 6 || k > 14)
                {
                    Console.WriteLine("Номер карты должен быть от 6 до 14!");
                }

                if (k == 11) Console.WriteLine("Валет");
                else if (k == 12) Console.WriteLine("Дама");
                else if (k == 13) Console.WriteLine("Король");
                else if (k == 14) Console.WriteLine("Туз");
                else Console.WriteLine($"{k}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine();
            }
        }

        static void Task3()
        {
            string input = Console.ReadLine();
            string iL = input.Trim().ToLower();

            switch (iL)
            {
                case "jabroni":
                    Console.WriteLine("Patron Tequila");
                    break;
                case "school counselor":
                    Console.WriteLine("Anything with Alcohol");
                    break;
                case "programmer":
                    Console.WriteLine("Hipster Craft Beer");
                    break;
                case "bike gang member":
                    Console.WriteLine("Moonshine");
                    break;
                case "politician":
                    Console.WriteLine("Your tax dollars");
                    break;
                case "rapper":
                    Console.WriteLine("Cristal");
                    break;
                default:
                    Console.WriteLine("Beer");
                    break;
            }
            Console.WriteLine();
        }

        static void Task4()
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int dayNum) && dayNum >= 1 && dayNum <= 7)
            {
                DaysOfWeek day = (DaysOfWeek)dayNum;
                Console.WriteLine($"{day}");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
            Console.WriteLine();
        }

        static void Task5()
        {
            string[] items = { "Car", "Hello Kitty", "Book", "Barbie doll", "Phone", "Hello Kitty" };
            int dollsInBag = 0;

            foreach (string item in items)
            {
                if (item == "Hello Kitty" || item == "Barbie doll")
                {
                    dollsInBag++;
                }
            }

            Console.WriteLine($"{dollsInBag}");
            Console.WriteLine();
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Task1();
            Task2();
            Task3();
            Task4();
            Task5();

            Console.ReadLine();
        }
    }
}
