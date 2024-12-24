using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" --------------------- \nWelcome to the gladiator trials!\n-----------------------");
        Console.WriteLine("Please choose a class !");
        Character player = characterSelection();
        Console.WriteLine("Time to BATTLE !");
        Enemy enemy = new Enemy();
        battle(player, enemy);
        Console.ReadKey();
    }
    static Character characterSelection()
    {
        string name = " ";
        int characterChoice = 0;
        Character player = null;
        try
        {
            Console.WriteLine("PRESS 1 FOR WARRIOR CLASS\nPRESS 2 FOR MAGE CLASS\n...");
            characterChoice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Awesome! Now choose a name for your gladiator!");
            name = Console.ReadLine();

        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input, try again!");
        }

        if (characterChoice == 1)
        {
            Console.WriteLine($"From here on out you are {name} the mighty warrior!");
            player = new Mage();
        }
        else if (characterChoice == 2)
        {
            Console.WriteLine($"From here on out you are {name} the cunning mage!");
            player = new Warrior();
        }

        return player;
    }
    static void battle(Character player, Character enemy)
    {
        Random random = new Random();
        bool playerAlive = true;
        bool enemyAlive = true;
        int playerDamage;
        int enemyDamage;
        Console.WriteLine("You are now fighting the mighty GOBLIN!");

        while(playerAlive && enemyAlive)
        {
            playerDamage = random.Next(1, 6);
            enemyDamage = random.Next(1, 6);
            Console.WriteLine("Rolling the dice for player damage!");
            Console.ReadKey();
            player.dealDamage(enemy, playerDamage);
            Console.WriteLine("Rolling the dice for enemy damage!");
            Console.ReadKey();
            enemy.dealDamage(player, enemyDamage);
            Console.ReadKey();
            playerAlive = player.isAlive();
            enemyAlive = enemy.isAlive();
        }

        if (playerAlive == false)
        {
            Console.WriteLine("The player has DIED! You lost!");
        }
        else if (enemyAlive == false)
        {
            Console.WriteLine("You defeated the enemy! You are victorious!");
        }

        Console.ReadKey();
  
    }

}

public class Character
{
    public bool alive;
    public int playerHp = 20;
    public int enemyHp = 20;
    string name = " ";
    public virtual void takeDamage(Character x)
    {

    }
    public virtual void dealDamage(Character x, int dmg)
    {

    }
    public virtual bool isAlive()
    {
        return playerHp > 0;  // The player is alive if playerHp > 0
    }
}
class Mage : Character
{
    public override void dealDamage(Character x, int dmg)
    {
        Console.WriteLine($"The player dealt {dmg} to enemy!");
        enemyHp -= dmg;

        Console.WriteLine($"Enemy has {enemyHp} hp left!");

        if (x.enemyHp <= 0)
        {
            x.alive = false; // Mark the enemy as dead if their HP is <= 0
        }
    }
    public override bool isAlive()
    {
        return playerHp > 0; // Check if player is still alive
    }
}
class Warrior : Character
{
    public override void dealDamage(Character x, int dmg)
    {
        Console.WriteLine($"The player dealt {dmg} to enemy!");
        enemyHp -= dmg;
        Console.WriteLine($"Enemy has {enemyHp} hp left!");

        if (x.enemyHp <= 0)
        {
            x.alive = false; // Mark the enemy as dead if their HP is <= 0
        }
    }
    public override bool isAlive()
    {
        return playerHp > 0; // Check if player is still alive
    }
}

public class Enemy : Character
{
    public override void dealDamage(Character x, int dmg)
    {
        Console.WriteLine($"The enemy dealt {dmg} to player!");
        playerHp -= dmg;
        Console.WriteLine($"Player has {playerHp} hp left!");

        if (x.playerHp <= 0)
        {
            x.alive = false; // Mark the enemy as dead if their HP is <= 0
        }
    }
    public override bool isAlive()
    {
        return enemyHp > 0; // Check if enemy is still alive
    }
}
