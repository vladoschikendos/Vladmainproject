using System;
using System.Collections.Generic;


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vladmainproject
{
    class BankAccount
    {
        public string Owner;
        public decimal Balance;

        public BankAccount(string owner, decimal balance)
        {
            Owner = owner;
            Balance = balance;
        }

        public void Transfer(BankAccount from, decimal sum)
        {
            if (from.Balance < sum)
            {
                Console.WriteLine($"Недостаточно средств на счёте {from.Owner}");
                return;
            }
            from.Balance -= sum;
            this.Balance += sum;
            Console.WriteLine($"Переведено {sum} от {from.Owner} к {this.Owner}");
        }

        public override string ToString()
        {
            return $"{Owner}: {Balance}";
        }
    }

    class Song
    {
        string name;
        string author;
        public Song prev;

        public void SetName(string n) { name = n; }
        public void SetAuthor(string a) { author = a; }
        public void SetPrev(Song p) { prev = p; }

        public string Title()
        {
            return $"{name} — {author}";
        }

        public void Print()
        {
            Console.WriteLine($"Песня: {name}, исполнитель: {author}");
        }

        public override bool Equals(object d)
        {
            if (d is Song other)
                return this.name == other.name && this.author == other.author;
            return false;
        }

        public override int GetHashCode()
        {
            return (name + author).GetHashCode();
        }
    }

    internal class Program
    {
        static string Reverse(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static bool IsFormattable(object obj)
        {
            if (obj is IFormattable)
            {
                IFormattable f = obj as IFormattable;
                return f != null;
            }
            return false;
        }

        public static void SearchMail(ref string s)
        {
            int idx = s.IndexOf('#');
            if (idx >= 0)
                s = s.Substring(idx + 1).Trim();
        }

        static void Task81()
        {
            Console.WriteLine("\n===== УПРАЖНЕНИЕ 8.1 =====");
            BankAccount a = new BankAccount("Влад", 1000);
            BankAccount b = new BankAccount("Иван", 500);

            Console.WriteLine("До перевода:");
            Console.WriteLine("  " + a);
            Console.WriteLine("  " + b);

            b.Transfer(a, 300);

            Console.WriteLine("После перевода:");
            Console.WriteLine("  " + a);
            Console.WriteLine("  " + b);
        }

        static void Task82()
        {
            Console.WriteLine("\n===== УПРАЖНЕНИЕ 8.2 =====");
            Console.Write("Введите строку: ");
            string s = Console.ReadLine();
            Console.WriteLine("В обратном порядке: " + Reverse(s));
        }

        static void Task83()
        {
            Console.WriteLine("\n===== УПРАЖНЕНИЕ 8.3 =====");
            Console.Write("Введите имя файла: ");
            string input = Console.ReadLine();

            if (!File.Exists(input))
            {
                Console.WriteLine("Файл не существует. Работа завершена.");
                return;
            }

            string output = "output.txt";
            string content = File.ReadAllText(input);
            File.WriteAllText(output, content.ToUpper());
            Console.WriteLine($"Содержимое записано в {output} заглавными буквами.");
        }

        static void Task84()
        {
            Console.WriteLine("\n===== УПРАЖНЕНИЕ 8.4 =====");
            object[] objects = { 123, "строка", 3.14, new object(), DateTime.Now };

            foreach (object o in objects)
            {
                Console.WriteLine($"{o} ({o.GetType().Name}) реализует IFormattable: {IsFormattable(o)}");
            }
        }

        static void Task81Home()
        {
            Console.WriteLine("\n===== ДОМАШНЕЕ ЗАДАНИЕ 8.1 =====");

            string inputFile = "fio_mail.txt";
            if (!File.Exists(inputFile))
            {
                File.WriteAllLines(inputFile, new[]
                {
                    "Иванов Иван Иванович # iviviv@mail.ru",
                    "Петров Петр Петрович # petr@mail.ru"
                });
                Console.WriteLine($"Создан файл {inputFile}");
            }

            string[] lines = File.ReadAllLines(inputFile);
            List<string> emails = new List<string>();

            foreach (string line in lines)
            {
                string s = line;
                SearchMail(ref s);
                emails.Add(s);
            }

            File.WriteAllLines("emails.txt", emails);
            Console.WriteLine("Список адресов записан в emails.txt:");
            foreach (string e in emails)
                Console.WriteLine("  " + e);
        }

        static void Task82Home()
        {
            Console.WriteLine("\n===== ДОМАШНЕЕ ЗАДАНИЕ 8.2 =====");

            List<Song> songs = new List<Song>();

            Song s1 = new Song();
            s1.SetName("Кукла колдуна"); s1.SetAuthor("Король и Шут");
            songs.Add(s1);

            Song s2 = new Song();
            s2.SetName("Группа крови"); s2.SetAuthor("Кино");
            songs.Add(s2);

            Song s3 = new Song();
            s3.SetName("Город под подошвой"); s3.SetAuthor("Оксимирон");
            songs.Add(s3);

            Song s4 = new Song();
            s4.SetName("Владимирский централ"); s4.SetAuthor("Михаил Круг");
            songs.Add(s4);

            s1.SetPrev(null);
            s2.SetPrev(s1);
            s3.SetPrev(s2);
            s4.SetPrev(s3);

            Console.WriteLine("Список песен:");
            foreach (Song song in songs)
                song.Print();

            Console.WriteLine("\nСравнение первой и второй песни:");
            if (songs[0].Equals(songs[1]))
                Console.WriteLine("  Песни одинаковые");
            else
                Console.WriteLine("  Песни разные");

            Console.WriteLine("\nСравнение первой и третьей песни:");
            if (songs[0].Equals(songs[2]))
                Console.WriteLine("  Песни одинаковые");
            else
                Console.WriteLine("  Песни разные");
        }

        static void Main(string[] args)
        {
            Task81();
            Task82();
            Task83();
            Task84();
            Task81Home();
            Task82Home();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
