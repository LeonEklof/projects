using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        string playerChoice;
        Character player = new Character("Leon", 20);
        Character enemy = new Character("Goblin", 20);
        Console.WriteLine("Please choose your class. : type Warrior");
        playerChoice = Console.ReadLine();
        playerChoice.ToLower();

        //create warrior class
        if(playerChoice == "warrior")
        {
            player = new Warrior("Leon", 25);
        }

        //time to fight
        while (player.isAlive() && enemy.isAlive())
        {
            //attack chooses which ability to use
            player.attack(enemy);
            enemy.attack(player);
        }
    }
}
public class Character
{
    Random random = new Random();
    int damage;
    private string name;
    private int health;
    private bool alive;
    public Character(string name, int health)
    {
        this.name = name;
        this.health = health;
    }
    public virtual void attack(Character enemy)
    {
        dealDamage(enemy, 1);
    }
    public void dealDamage(Character c, int ability)
    {
        //rolls damage based on ability used
        switch (ability)
        {
            case 1:
                damage = random.Next(1, 4);
                Console.WriteLine($"{name} used Basic Attack! It dealt {damage} damage!");
                break;
            case 2:
                damage = random.Next(3, 6);
                Console.WriteLine($"{name} used Basic Attack! It dealt {damage} damage!");
                break;
        }

        //Sends rolled damage to subtract enemy HP
        c.takeDamage(c, damage);
        Console.WriteLine($"{name} hit {c.name} for {damage} damage!");
    }
    public void takeDamage(Character target, int damage)
    {
        //Subtracts enemy hp based on damage received
        health -= damage;
        Console.WriteLine($"{name} has: " + health + " health left!");
        //checks whether target still alive 
        target.isAlive();
    }
    public bool isAlive()
    {
        if (health >= 1)
        {
            alive = true;
        }
        else
        {
            health = 0;
            alive = false;
            Console.WriteLine($"{name} has died!");
            Console.ReadKey();
        }
        return alive;
    }
}
public class Warrior : Character
{
    Random random = new Random();
    int attackChoice;
    int damage;
    string name;
    private string ab1 = "Basic attack; 1 - 3 dmg; 0 turn cd";
    private string ab2 = "Charged attack; 3 - 5 dmg; 2 turn cd";
    public Warrior(string name, int health) : base(name, health)
    {
        this.name = name;
    }
    public override void attack(Character enemy)
    {
        //decides between using skill 1 or skill 2 
        attackChoice = Convert.ToInt32(Console.ReadLine());

        //calls dealdamage to roll for damage on enemy
        enemy.dealDamage(enemy, attackChoice);
    }
}