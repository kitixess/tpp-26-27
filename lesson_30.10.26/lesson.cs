using System;
public class Character
{
    private string name;
    private int hp;
    private int power;
    private static int count;

    public Character(string name, int hp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        count++;
    }

    public string Name
    {
        get 
        {
            return name;
        }
        set
        {
            name = value; 
        }
    }

    public int Hp
    {
        get 
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    public int Power
    {
        get 
        {
            return power;
        }
        set
        {
            power = value;
        }
    }

    public void TakeDamage(int damage)
    {
        this.Hp -= damage; 
    }

    public virtual void Attack(Character target)
    {
        target.TakeDamage(this.power);
        Console.WriteLine($"{this.Name} атакует {target.Name} и наносит {this.Power} урона");
    }

    public void GetStatus()
    {
        Console.WriteLine($"Персонаж: {this.Name}, Здоровье: {this.Hp}");
    }

    public static int HowMany()
    {
        return count;
    }

    public static bool IsValidStats(int hp, int power)
    {
        if (hp > 0 & power > 0)
        {
            return true;
        }
        else return false;
    }

    public bool IsAlive()
    {
        if (this.Hp > 0) return true;
        else return false;
    }
}

public class Player : Character
{
    public Player(string name, int hp, int power) : base(name, hp, power)
    {
        
    }

    public override void Attack(Character target)
    {
        Console.WriteLine($"Игрок {Name} атакует на {this.Power}!");
        target.TakeDamage(this.Power);
    }
}

public class Enemy : Character
{
    public Enemy(string name, int hp, int power) : base(name, hp, power)
    {
    }

    public override void Attack(Character target)
    {
        Console.WriteLine($"Враг {this.Name} атакует на {this.Power}!");
        target.TakeDamage(this.Power);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("пока нет ничего");
    }
}