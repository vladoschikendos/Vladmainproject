using System;
using System.Text;

namespace Vladmainproject
{
    struct Drink
    {
        public string Name;     
        public double Alcohol;   
        public Drink(string name, double alcohol)
        {
            Name = name;
            Alcohol = alcohol;
        }
    }
    struct Student
    {
        public string LastName;     
        public string FirstName;   
        public int Id;              
        public DateTime BirthDate;  
        public char Category;       
        public Drink DrinkInfo;     
        public double Volume;       
        public Student(string lastName, string firstName, int id, DateTime birthDate,
                       char category, Drink drink, double volume)
        {
            LastName = lastName;
            FirstName = firstName;
            Id = id;
            BirthDate = birthDate;
            Category = category;
            DrinkInfo = drink;
            Volume = volume;
        }


        public double PA => Volume * DrinkInfo.Alcohol / 100.0;
    }
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

            Console.WriteLine("\nВведённая информация:");
            Console.WriteLine($"Имя:     {name}");
            Console.WriteLine($"Город:   {city}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"PIN-код: {pin}");
            Console.WriteLine();
        }

        // №3
        static void Task3()
        {
            Console.WriteLine("3. Преобразование регистра строки:");
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            var sb = new StringBuilder(input.Length);
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
        // №4
        static void Task4()
        {
            Console.WriteLine("4. Подсчёт вхождений подстроки:");
            Console.Write("Введите строку: ");
            string text = Console.ReadLine();
            Console.Write("Введите подстроку: ");
            string sub = Console.ReadLine();
            int count = 0;
            int index = 0;

            while ((index = text.IndexOf(sub, index)) != -1)
            {
                count++;
                index += sub.Length; 
            }

            Console.WriteLine($"Количество вхождений: {count}");
            Console.WriteLine();
        }
        // №5
        static void Task5()
        {
            Console.WriteLine("5. Сколько бутылок виски нужно купить:");
            Console.Write("Стандартная цена бутылки: ");
            long nP = long.Parse(Console.ReadLine());
            Console.Write("Скидка в Duty Free (%): ");
            long sP = long.Parse(Console.ReadLine());
            Console.Write("Стоимость отпуска: ");
            long hP = long.Parse(Console.ReadLine());

            long sPB = nP * sP; 
            if (sPB == 0)
            {
                Console.WriteLine("Скидка нулевая — экономия никогда не покроет отпуск.");
                Console.WriteLine();
                return;
            }
            long bottles = hP * 100 / sPB;
            Console.WriteLine($"Нужно купить бутылок: {bottles}");
            Console.WriteLine();
        }
        static void Task6()
        {
            Console.WriteLine("6. Студенты и алкоголь:");
            Console.WriteLine();

            Drink beer = new Drink("Пиво", 4.5);
            Drink wine = new Drink("Вино", 12.0);
            Drink vodka = new Drink("Водка", 40.0);
            Drink whiskey = new Drink("Виски", 43.0);
            Drink juice = new Drink("Сок", 0.0);

            Student[] students = new Student[]
            {
                new Student("Иванов",  "Иван",   101, new DateTime(2003, 5, 14), 'a', vodka,   2.5),
                new Student("Петров",  "Пётр",   102, new DateTime(2004, 2, 20), 'b', beer,    1.8),
                new Student("Сидоров", "Семён",  103, new DateTime(2002, 11, 3), 'c', wine,    0.75),
                new Student("Кузнецов","Кирилл", 104, new DateTime(2005, 7, 30), 'd', juice,   0.5),
                new Student("Смирнов", "Сергей", 105, new DateTime(2003, 9, 12), 'a', whiskey, 1.2),
            };

     
            Console.WriteLine($"{"Фамилия"}{"Имя"}{"ID"}{"Дата рожд."}{"Кат."}{"Напиток"}{"Объём, л"}{"Спирт, %"}{"Чист. спирт, л"}");
            Console.WriteLine(new string('-', 90));

            foreach (var s in students)
            {
                Console.WriteLine($"{s.LastName}{s.FirstName}{s.Id}{s.BirthDate:dd.MM.yyyy}{s.Category}{s.DrinkInfo.Name}{s.Volume}{s.DrinkInfo.Alcohol}{s.PA}");
            }
            Console.WriteLine();

            
            double totalVolume = 0;
            double totalAlcohol = 0;
            foreach (var s in students)
            {
                totalVolume += s.Volume;
                totalAlcohol += s.PA;
            }

            Console.WriteLine($"Общий объём выпитой жидкости: {totalVolume} л");
            Console.WriteLine($"Общий объём чистого алкоголя: {totalAlcohol} л");
            Console.WriteLine();

            Console.WriteLine("Доля каждого студента:");
            Console.WriteLine($"{"Фамилия"}{"Жидкость, %"}{"Алкоголь, %"}");
            Console.WriteLine("-");

            foreach (var s in students)
            {
                double volPercent = s.Volume / totalVolume * 100;
                double alcPercent = s.PA/ totalAlcohol * 100;

                Console.WriteLine($"{s.LastName}{volPercent}{alcPercent}");
            }

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
            Task6();
        }
    }
}