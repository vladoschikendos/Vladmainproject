using System;
using System.Text;

enum VUZ
{
    КГУ,
    КАИ,
    КХТИ
}

struct Rabotnik
{
    public string Name;
    public VUZ Vuz;

    public Rabotnik(string name, VUZ vuz)
    {
        Name = name;
        Vuz = vuz;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Rabotnik[] rabotniki =
        {
            new Rabotnik("Иванов Иван", VUZ.КГУ),
            new Rabotnik("Петров Петр", VUZ.КАИ),
            new Rabotnik("Сидоров Сидор", VUZ.КХТИ)
        };

        foreach (var r in rabotniki)
        {
            Console.WriteLine($"Имя: {r.Name}, ВУЗ: {r.Vuz}");
        }
    }
}