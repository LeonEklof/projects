class Program 
{
    static void Main(string[] args) 
    {
        Console.WriteLine(" --------------------- \nWelcome to the gladiator trials!\n-----------------------");
        Console.WriteLine("Please choose a class!");
        Character player = CharacterSelection();
        Console.WriteLine("Time to Battle!");
        Character enemy = new Character("Tyler1");
        Battle(player, enemy);
        Console.ReadKey();
    }
    
    static Character CharacterSelection() 
    {
        string name = "";
        int choice = 0;
        Character player = null;
        try 
        {
            Console.WriteLine("PRESS 1 FOR WARRIOR CLASS\nPRESS 2 FOR MAGE CLASS\n...");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Awesome! Now choose a name for your gladiator!");
            name = Console.ReadLine();
            if (name == "")
            {
                name = "Dumbass";
            }
        }
        catch (FormatException) 
        {
            Console.WriteLine("Wrong input, try again!");
        }

        switch (choice)
        {
            case 1: 
                return new Warrior(name);
            case 2:
                return new Mage(name);   
            default:
                return new Idiot(name);                
        }
    }
    static void Battle(Character player, Character enemy) 
    {
        Random random = new Random();
        Console.WriteLine($"{player.name} is fighting {enemy.name}!");

        while(player.IsAlive() && enemy.IsAlive()) 
        {
            Console.WriteLine("Rolling the dice for player damage!");
            Console.ReadKey();
            player.DealDamage(enemy, random.Next(1, 6));
            if (!enemy.IsAlive()) 
            {
                Console.WriteLine($"{enemy.name} has DIED! You are victorious!");
                return;
            }
            Console.WriteLine("Rolling the dice for enemy damage!");
            Console.ReadKey();
            enemy.DealDamage(player, random.Next(1, 6));
            if (!player.IsAlive()) 
            {
                Console.WriteLine($"{player.name} has DIED! You lost!");
                return;
            }
            Console.ReadKey();
        }
    }
}

public class Character 
{
    int hp = 20;
    public string name = "";

    public Character(string name)
    {
        this.name = name;
    }
    public void DealDamage(Character defender, int damage) 
    {
        defender.setHp(defender.hp - damage);
        Console.WriteLine($"{name} has dealt {damage} damage to {defender.name}! {defender.name} has {defender.hp} hp left!");
    }

    public void setHp(int hp)
    {
        this.hp = hp;
    }
    public bool IsAlive() 
    {
        return hp > 0; 
    }
}

class Mage : Character
{
    public Mage(string name) : base(name)
    {
        Console.WriteLine($"From here on out you are {name} the cunning mage!");
        this.name = name;
    }
}
class Warrior : Character
{
    public Warrior(string name) : base(name)
    {
        Console.WriteLine($"From here on out you are {name} the mighty warrior!");
        this.name = name;
    }
}
class Idiot : Character
{
    public Idiot(string name) : base(name)
    {
        Console.WriteLine($"You selected an invalid class, so from here on out you are {name} the idiot!");
        this.name = name;
    }
}