using System;


enum AccountType
{
    Savings,   
    Checking,  
    Credit     
}

class BankAccount
{
    private string accountNumber;
    private decimal balance;
    private AccountType type;

    //7.2
    private static int lastNumber = 1000;

    
    private static string GenerateNumber()
    {
        lastNumber++;
        return "ACC-" + lastNumber;
    }

    
    public BankAccount(AccountType type, decimal initialBalance)
    {
        this.accountNumber = GenerateNumber();
        this.type = type;
        this.balance = initialBalance;
    }

    
    public string GetAccountNumber() { return accountNumber; }
    public decimal GetBalance() { return balance; }
    public AccountType GetAccountType() { return type; }

    public void SetAccountType(AccountType type) { this.type = type; }

    //7.3
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма пополнения должна быть положительной.");
            return;
        }
        balance += amount;
        Console.WriteLine($"Пополнено на {amount}. Баланс: {balance}");
    }

    //7.3
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма снятия должна быть положительной.");
            return;
        }
        if (amount > balance)
        {
            Console.WriteLine($"Недостаточно средств. Баланс: {balance}");
            return;
        }
        balance -= amount;
        Console.WriteLine($"Снято {amount}. Баланс: {balance}");
    }

   
    public void PrintInfo()
    {
        Console.WriteLine($"Номер счета: {accountNumber}");
        Console.WriteLine($"Баланс: {balance}");
        Console.WriteLine($"Тип счета: {type}");
    }
}

class Program
{
    static void Main()
    {
        
        BankAccount account1 = new BankAccount(AccountType.Savings, 5000m);
        account1.PrintInfo();

        Console.WriteLine("\n--- Операции ---");
        account1.Deposit(1500m);
        account1.Withdraw(2000m);
        account1.Withdraw(10000m);

        Console.WriteLine("\n--- Итог ---");
        account1.PrintInfo();

        
        BankAccount account2 = new BankAccount(AccountType.Checking, 0m);
        Console.WriteLine("\nВторой счет:");
        account2.PrintInfo();
    }
}