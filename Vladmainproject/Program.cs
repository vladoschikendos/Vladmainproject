using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Vladmainproject
{
    class Student
    {
        public string Surname;
        public string Name;
        public int BirthYear;
        public string Exam;
        public int Points;

        public override string ToString()
        {
            return $"{Surname} {Name}, {BirthYear} г.р., экзамен: {Exam}, баллы: {Points}";
        }
    }

    class Grandma
    {
        public string Name;
        public int Age;
        public List<string> Diseases = new List<string>();

        public override string ToString()
        {
            string d = Diseases.Count == 0 ? "нет болезней" : string.Join(", ", Diseases);
            return $"{Name}, {Age} лет, болезни: [{d}]";
        }
    }

    class Hospital
    {
        public string Name;
        public List<string> Cures = new List<string>();
        public int Capacity;
        public List<Grandma> Patients = new List<Grandma>();

        public override string ToString()
        {
            string cures = string.Join(", ", Cures);
            double percent = Capacity == 0 ? 0 : (double)Patients.Count / Capacity * 100;
            return $"{Name} | лечит: [{cures}] | пациентов: {Patients.Count}/{Capacity} ({percent:F1}%)";
        }
    }

    internal class Program
    {
        static void Task1()
        {
            Console.WriteLine("\n===== ПУНКТ 1: Картинки =====");

            List<int> pictures = new List<int>();
            for (int i = 1; i <= 32; i++)
            {
                pictures.Add(i);
                pictures.Add(i);
            }

            Console.WriteLine("Изначальный List:");
            Console.WriteLine(string.Join(" ", pictures));

            Random rnd = new Random();
            for (int i = pictures.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                int tmp = pictures[i];
                pictures[i] = pictures[j];
                pictures[j] = tmp;
            }

            Console.WriteLine("\nПеремешанный List:");
            Console.WriteLine(string.Join(" ", pictures));
        }

        static void Task2()
        {
            Console.WriteLine("\n===== ПУНКТ 2: Студенты =====");

            string filePath = "students.txt";
            if (!File.Exists(filePath))
            {
                string[] defaultStudents =
                {
                    "Иванов Иван 2005 Математика 85",
                    "Петров Пётр 2004 Физика 72",
                    "Сидоров Сидор 2005 Информатика 90",
                    "Кузнецова Анна 2004 Химия 78",
                    "Смирнов Алексей 2005 Биология 65",
                    "Попова Мария 2004 Литература 88",
                    "Васильев Дмитрий 2005 История 74",
                    "Новикова Елена 2004 География 81",
                    "Морозов Сергей 2005 Английский 95",
                    "Фёдорова Ольга 2004 Обществознание 70"
                };
                File.WriteAllLines(filePath, defaultStudents);
                Console.WriteLine($"Создан файл {filePath} с 10 студентами.");
            }

            Dictionary<string, Student> students = new Dictionary<string, Student>();
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] p = line.Split(' ');
                if (p.Length >= 5)
                {
                    Student s = new Student
                    {
                        Surname = p[0],
                        Name = p[1],
                        BirthYear = int.Parse(p[2]),
                        Exam = p[3],
                        Points = int.Parse(p[4])
                    };
                    students[s.Surname + " " + s.Name] = s;
                }
            }

            Console.WriteLine("Загружено студентов: " + students.Count);

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("  Новый студент  — добавить");
                Console.WriteLine("  Удалить        — удалить по Фамилии Имени");
                Console.WriteLine("  Сортировать    — сортировка по баллам");
                Console.WriteLine("  Показать       — вывести всех");
                Console.WriteLine("  Выход          — выйти из меню");
                Console.Write("Введите команду: ");
                string cmd = Console.ReadLine();

                if (cmd == "Выход") break;

                if (cmd == "Новый студент")
                {
                    Console.Write("Фамилия: "); string sur = Console.ReadLine();
                    Console.Write("Имя: "); string nm = Console.ReadLine();
                    Console.Write("Год рождения: "); int yr = int.Parse(Console.ReadLine());
                    Console.Write("Экзамен: "); string ex = Console.ReadLine();
                    Console.Write("Баллы: "); int pts = int.Parse(Console.ReadLine());

                    Student s = new Student { Surname = sur, Name = nm, BirthYear = yr, Exam = ex, Points = pts };
                    students[sur + " " + nm] = s;
                    Console.WriteLine("Студент добавлен.");
                }
                else if (cmd == "Удалить")
                {
                    Console.Write("Фамилия Имя для удаления: ");
                    string key = Console.ReadLine();
                    if (students.Remove(key))
                        Console.WriteLine("Удалён.");
                    else
                        Console.WriteLine("Не найден.");
                }
                else if (cmd == "Сортировать")
                {
                    var sorted = students.Values.OrderBy(s => s.Points).ToList();
                    Console.WriteLine("Отсортировано по баллам (возрастание):");
                    foreach (var s in sorted)
                        Console.WriteLine("  " + s);
                }
                else if (cmd == "Показать")
                {
                    foreach (var s in students.Values)
                        Console.WriteLine("  " + s);
                }
            }
        }

        static void Task3()
        {
            Console.WriteLine("\n===== ПУНКТ 3: Бабули и Больницы =====");

            Stack<Hospital> hospitals = new Stack<Hospital>();

            Hospital h1 = new Hospital { Name = "Городская", Capacity = 2 };
            h1.Cures.Add("Грипп"); h1.Cures.Add("Кашель"); h1.Cures.Add("Простуда");

            Hospital h2 = new Hospital { Name = "Областная", Capacity = 1 };
            h2.Cures.Add("Давление"); h2.Cures.Add("Сердце");

            Hospital h3 = new Hospital { Name = "Частная", Capacity = 3 };
            h3.Cures.Add("Аллергия"); h3.Cures.Add("Грипп"); h3.Cures.Add("Давление");

            hospitals.Push(h1);
            hospitals.Push(h2);
            hospitals.Push(h3);

            Queue<Grandma> grandmas = new Queue<Grandma>();

            Console.WriteLine("Введите бабуль. Для завершения введите пустое имя.");
            while (true)
            {
                Console.Write("Имя бабули (Enter — закончить): ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) break;

                Console.Write("Возраст: ");
                int age = int.Parse(Console.ReadLine());

                Grandma g = new Grandma { Name = name, Age = age };

                Console.Write("Болезни через запятую (Enter — нет болезней): ");
                string dis = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dis))
                {
                    foreach (string d in dis.Split(','))
                        g.Diseases.Add(d.Trim());
                }
                grandmas.Enqueue(g);
            }

            if (grandmas.Count == 0)
            {
                Console.WriteLine("Добавлю тестовых бабуль для демонстрации.");
                var g1 = new Grandma { Name = "Баба Нюра", Age = 78 };
                g1.Diseases.Add("Грипп"); g1.Diseases.Add("Давление");
                grandmas.Enqueue(g1);

                var g2 = new Grandma { Name = "Баба Зина", Age = 85 };
                g2.Diseases.Add("Аллергия");
                grandmas.Enqueue(g2);

                var g3 = new Grandma { Name = "Баба Валя", Age = 70 };
                grandmas.Enqueue(g3);

                var g4 = new Grandma { Name = "Баба Катя", Age = 90 };
                g4.Diseases.Add("Рак"); g4.Diseases.Add("Диабет");
                grandmas.Enqueue(g4);
            }

            Console.WriteLine("\n--- Распределение бабуль по больницам ---");

            while (grandmas.Count > 0)
            {
                Grandma g = grandmas.Dequeue();
                bool placed = false;

                Console.WriteLine($"\nПришла: {g}");

                if (g.Diseases.Count == 0)
                {
                    foreach (Hospital h in hospitals)
                    {
                        if (h.Patients.Count < h.Capacity)
                        {
                            h.Patients.Add(g);
                            Console.WriteLine($"  → в {h.Name} (просто спросить)");
                            placed = true;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Hospital h in hospitals)
                    {
                        if (h.Patients.Count >= h.Capacity) continue;

                        int matches = 0;
                        foreach (string d in g.Diseases)
                            if (h.Cures.Contains(d)) matches++;

                        double percent = (double)matches / g.Diseases.Count * 100;
                        if (percent > 50)
                        {
                            h.Patients.Add(g);
                            Console.WriteLine($"  → в {h.Name} (лечит {percent:F0}% болезней)");
                            placed = true;
                            break;
                        }
                    }
                }

                if (!placed)
                    Console.WriteLine("  ✗ осталась на улице плакать");
            }

            Console.WriteLine("\n--- Все бабули в больницах ---");
            foreach (Hospital h in hospitals)
                foreach (Grandma g in h.Patients)
                    Console.WriteLine("  " + g);

            Console.WriteLine("\n--- Все больницы ---");
            foreach (Hospital h in hospitals)
                Console.WriteLine("  " + h);
        }

        

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}