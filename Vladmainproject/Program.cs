using System;

class Program
{
    static int Max(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }

    static void Swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }

    static bool TryFactorial(int n, out long result)
    {
        result = 1;
        if (n < 0)
            return false;
        try
        {
            checked
            {
                for (int i = 2; i <= n; i++)
                    result *= i;
            }
            return true;
        }
        catch (OverflowException)
        {
            result = 0;
            return false;
        }
    }

    static long FactorialRecursive(int n)
    {
        if (n <= 1)
            return 1;
        return n * FactorialRecursive(n - 1);
    }

    static int nod(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static int nod(int a, int b, int c)
    {
        return nod(nod(a, b), c);
    }

    static long Fibonacci(int n)
    {
        if (n <= 2)
            return 1;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    static void Main()
    {
        int x = 15, y = 42;
        Console.WriteLine(Max(x, y));
        Console.WriteLine(Max(y, x));
        Console.WriteLine(Max(7, 7));

        int p = 10, q = 20;
        Console.WriteLine($"{p} {q}");
        Swap(ref p, ref q);
        Console.WriteLine($"{p} {q}");

        int[] testFactorials = { 0, 1, 5, 10, 20, 21 };
        foreach (int n in testFactorials)
        {
            if (TryFactorial(n, out long res))
                Console.WriteLine($"{n}! = {res}");
            else
                Console.WriteLine($"{n}! overflow");
        }

        foreach (int n in new[] { 0, 1, 5, 10, 20 })
            Console.WriteLine($"{n}! = {FactorialRecursive(n)}");

        Console.WriteLine(nod(48, 18));
        Console.WriteLine(nod(100, 75, 50));
        Console.WriteLine(nod(17, 13, 19));

        for (int i = 1; i <= 10; i++)
            Console.WriteLine(Fibonacci(i));

        Console.ReadKey();
    }
}
