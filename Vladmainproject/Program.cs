using System;
using System.Collections.Generic;

namespace Vladmainproject
{
    class Employee
    {
        public string Name;
        public List<Employee> Bosses = new List<Employee>();
        public string Department;

        public Employee(string name, string department)
        {
            Name = name;
            Department = department;
        }

        public void AddBoss(Employee boss)
        {
            Bosses.Add(boss);
        }

        public bool TakesTask(Employee from)
        {
            return Bosses.Contains(from);
        }

        public override string ToString()
        {
            return $"{Name} ({Department})";
        }
    }

    class Task
    {
        public string Title;
        public string TargetDepartment;

        public Task(string title, string targetDepartment)
        {
            Title = title;
            TargetDepartment = targetDepartment;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== ИЕРАРХИЯ ФИРМЫ =====");

            Employee timur = new Employee("Тимур", "начальство");

            Employee rashid = new Employee("Рашид", "начальство");
            Employee ilham = new Employee("О Ильхам", "начальство");

            Employee lukas = new Employee("Лукас", "бухгалтерия");

            Employee orkady = new Employee("Оркадий", "начальство");
            Employee volodya = new Employee("Володя", "начальство");

            Employee ilshat = new Employee("Ильшат", "системщики");
            Employee ivanych = new Employee("Иваныч", "системщики");
            Employee ilya = new Employee("Илья", "системщики");
            Employee vitya = new Employee("Витя", "системщики");
            Employee zhenya = new Employee("Женя", "системщики");

            Employee sergey = new Employee("Сергей", "разработчики");
            Employee lyaysan = new Employee("Ляйсан", "разработчики");
            Employee marat = new Employee("Марат", "разработчики");
            Employee dina = new Employee("Дина", "разработчики");
            Employee ildar = new Employee("Ильдар", "разработчики");
            Employee anton = new Employee("Антон", "разработчики");

            rashid.AddBoss(timur);
            ilham.AddBoss(timur);
            lukas.AddBoss(rashid);

            orkady.AddBoss(ilham);
            volodya.AddBoss(orkady);

            ilshat.AddBoss(orkady);
            sergey.AddBoss(orkady);
            sergey.AddBoss(volodya);

            ivanych.AddBoss(ilshat);
            ilya.AddBoss(ilshat);
            vitya.AddBoss(ilshat);
            zhenya.AddBoss(ilshat);

            lyaysan.AddBoss(sergey);
            marat.AddBoss(lyaysan);
            dina.AddBoss(lyaysan);
            ildar.AddBoss(lyaysan);
            anton.AddBoss(lyaysan);

            List<Employee> all = new List<Employee>
            {
                timur, rashid, ilham, lukas,
                orkady, volodya,
                ilshat, ivanych, ilya, vitya, zhenya,
                sergey, lyaysan, marat, dina, ildar, anton
            };

            List<Task> tasks = new List<Task>
            {
                new Task("Настроить сеть", "системщики"),
                new Task("Починить принтер", "системщики"),
                new Task("Написать модуль бухгалтерии", "разработчики"),
                new Task("Обновить сайт", "разработчики"),
                new Task("Провести совещание", "начальство"),
                new Task("Подписать отчёт", "начальство")
            };

            Console.WriteLine("\nЗадачи:");
            foreach (Task t in tasks)
                Console.WriteLine($"  «{t.Title}» → {t.TargetDepartment}");

            Console.WriteLine("\n===== НАЗНАЧЕНИЕ ЗАДАЧ =====");

            AssignTask(timur, rashid, tasks[0]);
            AssignTask(timur, dina, tasks[0]);
            AssignTask(sergey, dina, tasks[2]);
            AssignTask(orkady, sergey, tasks[3]);
            AssignTask(volodya, sergey, tasks[3]);
            AssignTask(lyaysan, marat, tasks[2]);
            AssignTask(ilshat, ilya, tasks[1]);
            AssignTask(ivanych, ilya, tasks[1]);
            AssignTask(timur, ilham, tasks[4]);
            AssignTask(rashid, lukas, tasks[5]);
            AssignTask(dina, lyaysan, tasks[2]);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void AssignTask(Employee from, Employee to, Task task)
        {
            Console.WriteLine($"\nОт {from.Name} даётся задача «{task.Title}» сотруднику {to.Name}.");

            if (task.TargetDepartment != to.Department && to.Department != "начальство")
                Console.WriteLine($"  ⚠ Задача для {task.TargetDepartment}, а {to.Name} — {to.Department}");

            if (to.TakesTask(from))
                Console.WriteLine($"{to.Name} БЕРЁТ задачу.");
            else
                Console.WriteLine($"{to.Name} НЕ БЕРЁТ задачу (не прямое руководство).");
        }
    }
}