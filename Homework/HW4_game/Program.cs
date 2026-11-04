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

    public override string ToString()
    {
        return $"{this.Name} (НР: {this.Hp})";
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (obj is Character other)
        {
            return this.Name == other.Name;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
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

    public override string ToString()
    {
        return $"Игрок {this.Name} (НР: {this.Hp})";
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

    public override string ToString()
    {
        return $"Враг {this.Name} (НР: {this.Hp})";
    }
}

class Program
{
    static void Main()
    {
        Player player = new Player("Полина", 10, 3);
        Enemy enemy = new Enemy("Варя", 8, 2);

        Console.WriteLine($"создан персонаж: {player}");
        Console.WriteLine($"создан персонаж: {enemy}");
        Console.WriteLine($"всего персонажей: {Character.HowMany()}");
        Console.WriteLine();

        List<Character> characters = new List<Character>();
        characters.Add(player);
        characters.Add(enemy);

        Console.WriteLine("Бой начинается!");
        Console.WriteLine();

        while (player.IsAlive() == true & enemy.IsAlive() == true)
        {
            characters[0].Attack(characters[1]);
            Console.WriteLine($"{enemy}");
            Console.WriteLine();

            if (enemy.IsAlive() == false)
            {
                break;
            }

            characters[1].Attack(characters[0]);
            Console.WriteLine($"{player}");
            Console.WriteLine();
        }

        Console.WriteLine("результат боя:");
        if (player.IsAlive() == true & enemy.IsAlive() == false)
        {
            Console.WriteLine("Враг побеждён! Игрок одержал победу!");
        }
        else if (player.IsAlive() == false & enemy.IsAlive() == true)
        {
            Console.WriteLine("Игрок побеждён! Враг одержал победу!");
        }
        else
        {
            Console.WriteLine("Ничья!");
        }
    }
}