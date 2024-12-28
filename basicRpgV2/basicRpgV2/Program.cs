using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        string playerChoice;
        enemyCreator spawn = new enemyCreator();
        Character nextEnemy = spawn.getNextEnemy();
        Character player = new Character("Leon", 20);
        //Character enemy = new Character("Goblin", 20);
        Console.WriteLine("Please choose your class. : type Warrior");
        playerChoice = Console.ReadLine();
        playerChoice.ToLower();

        //create warrior class
        if(playerChoice == "warrior")
        {
            player = new Warrior("Leon", 25);
        }

        while (spawn.getTotalEnemies() > 0)
        {
            //time to fight
            while (player.isAlive() && nextEnemy.isAlive())
            {
                //attack chooses which ability to use
                player.attack(nextEnemy);
                nextEnemy.attack(player);
            }
            Console.WriteLine("A new enemy has spawned!");
            nextEnemy = spawn.getNextEnemy();
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
                Console.WriteLine($"\n{name} used Basic Attack! It dealt {damage} damage!");
                break;
            case 2:
                damage = random.Next(3, 6);
                Console.WriteLine($"\n{name} used Charged Attack! It dealt {damage} damage!");
                break;
        }

        //Sends rolled damage to subtract enemy HP
        c.takeDamage(c, damage);
        //Console.WriteLine($"{name} hit {c.name} for {damage} damage!");
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
    int cd;
    bool onCd = false;
    private string ab1 = "- Basic attack \n\t1 - 3 dmg; 0 turn cd";
    private string ab2 = "- Charged attack \n\t3 - 5 dmg; 2 turn cd";
    public Warrior(string name, int health) : base(name, health)
    {
        this.name = name;
    }
    public override void attack(Character enemy)
    {
        //decides between using skill 1 or skill 2 
        Console.WriteLine("\nChoose an attack:");
        Console.WriteLine(ab1);
        Console.WriteLine(ab2);
        attackChoice = Convert.ToInt32(Console.ReadLine());
        if (attackChoice == 2)
        {
            if (onCd == true)
            {
                Console.WriteLine($"This skill is still on cd for {cd} more turns !");
                attack(enemy);
            }
            else if (onCd == false)
            {
                cd = 3;
                onCd = true;
            }
        }
        if (cd <= 0)
        {
            onCd = false;
        }
        //calls dealdamage to roll for damage on enemy
        if (onCd == true)
        {
            cd--;

            dealDamage(enemy, attackChoice);
        }
    }
}

class enemyCreator
{
    //spawns a random amount of enemies to fight
    List<Character> characters = new List<Character>();
    public enemyCreator()
    {
        Random numberOfCharacters = new Random();
        int x = numberOfCharacters.Next(1, 6);
        for (int i = 0; i < x; i++)
        {
            characters.Add(new Character(" ", 15));
        }
    }
    public Character getNextEnemy()
    {
        Character nextEnemy = characters.First();
        characters.Remove(nextEnemy);
        return nextEnemy;
    }
    public int getTotalEnemies()
    {
        return characters.Count();
    }
}