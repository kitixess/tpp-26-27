using System;
using System.Collections.Generic;
class Program
{
    static void PrintBalance(decimal balance, string currency = "₽")
    {
        Console.WriteLine($"Текущий баланс: {balance} {currency}");
    }
    
    static decimal AddBalance(decimal balance, List<string> history)
    {
        Console.Write("Введите сумму для пополнения: ");
        decimal n = decimal.Parse(Console.ReadLine());

        if (n > 0)
        {
            balance += n;
            history.Add($"Пополнение: +{n} ₽. Баланс: {balance} ₽");
            Console.WriteLine($"Счёт пополненен на {n} ₽");
        }
        else
        {
            Console.WriteLine("Ваша сумма должна быть больше нуля!");
        }

        return balance;
    }
    
    static decimal WithdrawMoney(decimal balance, List<string> history)
    {
        Console.Write("Введите сумму для снятия: ");
        decimal n = decimal.Parse(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("Ваша сумма должна быть больше нуля!");
        }
        else if (n > balance)
        {
            Console.WriteLine("Недостаточно средств!");
        }
        else
        {
            balance -= n;
            history.Add($"Снятие: -{n} ₽. Баланс: {balance} ₽");
            Console.WriteLine($"Со счёта снято {n} ₽.");
        }

        return balance;
    }
    
    static void PrintHistory(List<string> history)
    {
        Console.WriteLine("История операций:");
        for (int i = 0; i < history.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {history[i]}");
        }
    }
    
    static void Main()
    {
        Console.Write("Введите начальный баланс: ");
        decimal balance = decimal.Parse(Console.ReadLine());

        List<string> history = new List<string>();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Показать баланс");
            Console.WriteLine("2. Пополнить счёт");
            Console.WriteLine("3. Снять деньги");
            Console.WriteLine("4. Показать историю операций");
            Console.WriteLine("0. Выйти");
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();
            Console.WriteLine();
            if (choice == "1")
            {
                PrintBalance(balance);
            }
            else if (choice == "2")
            {
                balance = AddBalance(balance, history);
            }
            else if (choice == "3")
            {
                balance = WithdrawMoney(balance, history);
            }
            else if (choice == "4")
            {
                PrintHistory(history);
            }
			else if (choice == "0")
			{
				Console.WriteLine("До свидания :)");
				break;
			}
        }
    }
}

