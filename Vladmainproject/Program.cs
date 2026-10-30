using System;
using System.IO;

// Абстрактный класс
abstract class Животное
{
    protected string имя;
    protected int возраст;
    protected string порода;
    protected bool вСемье;
    protected double здоровье;

    
    public Животное(string имя, int возраст, string порода)
    {
        this.имя = имя;
        this.возраст = возраст;
        this.порода = порода;
        this.вСемье = false;
        this.здоровье = 100;
    }

    
    public Животное(string имя, string порода)
    {
        this.имя = имя;
        this.возраст = 1;
        this.порода = порода;
        this.вСемье = false;
        this.здоровье = 100;
    }

    
    public string Имя
    {
        get { return имя; }
        set { имя = value; }
    }

   
    public int Возраст
    {
        get { return возраст; }
    }

    public string Порода
    {
        get { return порода; }
        set { порода = value; }
    }

    public bool ВСемье
    {
        get { return вСемье; }
    }

    public double Здоровье
    {
        get { return здоровье; }
        set
        {
            if (value < 0) здоровье = 0;
            else if (value > 100) здоровье = 100;
            else здоровье = value;
        }
    }

    
    public abstract void ПодатьГолос();

    
    public void Покормить()
    {
        здоровье += 5;
        if (здоровье > 100) здоровье = 100;
        Console.WriteLine($"{имя} покормлен(а). Здоровье: {здоровье}");
    }

    public void ПроверитьЗдоровье()
    {
        Console.WriteLine($"Здоровье {имя}: {здоровье}%");
        if (здоровье < 50) Console.WriteLine($"{имя} нуждается в ветеринаре!");
        else Console.WriteLine($"{имя} здоров(а).");
    }

    public void ОформитьВСемью(string хозяин)
    {
        if (вСемье)
        {
            Console.WriteLine($"{имя} уже в семье.");
            return;
        }
        вСемье = true;
        Console.WriteLine($"{имя} оформлен(а) в семью к {хозяин}!");
    }

    public virtual void ПоказатьКарточку()
    {
        Console.WriteLine("--- Карточка питомца ---");
        Console.WriteLine($"Имя: {имя}");
        Console.WriteLine($"Возраст: {возраст}");
        Console.WriteLine($"Порода: {порода}");
        Console.WriteLine($"Здоровье: {здоровье}");
        Console.WriteLine($"В семье: {(вСемье ? "Да" : "Нет")}");
    }
}


class Кошка : Животное
{
    public Кошка(string имя, int возраст, string порода) : base(имя, возраст, порода) { }
    public Кошка(string имя, string порода) : base(имя, порода) { }

    public override void ПодатьГолос()
    {
        Console.WriteLine($"{имя}: Мяу!");
    }

    public void Мурлыкать()
    {
        Console.WriteLine($"{имя} мурлычет...");
    }

    public override void ПоказатьКарточку()
    {
        base.ПоказатьКарточку();
        Console.WriteLine("Тип: Кошка");
    }
}


class Собака : Животное
{
    public Собака(string имя, int возраст, string порода) : base(имя, возраст, порода) { }
    public Собака(string имя, string порода) : base(имя, порода) { }

    public override void ПодатьГолос()
    {
        Console.WriteLine($"{имя}: Гав!");
    }

    public void ПринестиМяч()
    {
        Console.WriteLine($"{имя} приносит мяч!");
    }

    public override void ПоказатьКарточку()
    {
        base.ПоказатьКарточку();
        Console.WriteLine("Тип: Собака");
    }
}

class Program
{
    static void Main()
    {
        
        string[] строки = @"D:\Влад\Downloads\питомцы.txt";

        Животное[] питомцы = new Животное[строки.Length];

        for (int i = 0; i < строки.Length; i++)
        {
            string[] части = строки[i].Split(';');
            string тип = части[0];
            string имя = части[1];
            int возраст = int.Parse(части[2]);
            string порода = части[3];

            if (тип == "Кошка")
                питомцы[i] = new Кошка(имя, возраст, порода);
            else
                питомцы[i] = new Собака(имя, возраст, порода);
        }

        
        foreach (Животное п in питомцы)
        {
            п.ПоказатьКарточку();
            п.ПодатьГолос();
            п.Покормить();
            п.ПроверитьЗдоровье();
            п.ОформитьВСемью("Иван");
            Console.WriteLine();
        }

        
        Кошка к = new Кошка("Мурка", "Персидская");
        Собака с = new Собака("Рекс", "Лабрадор");
        к.Мурлыкать();
        с.ПринестиМяч();

        
        к.Имя = "Мурка2";
        к.Порода = "Сиамская";
        Console.WriteLine($"Переименована кошка: {к.Имя}, порода: {к.Порода}");
    }
}