using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string characterName;
        int classChoice = 0;
        Character character;

        Console.WriteLine("------------------\nWelcome to the Basic RPG game!\n------------------");
        Console.WriteLine("Let's start of by choosing a class shall we!\n------------------");
        Console.WriteLine("Type 1 for the Mighty Warrior class! \nType 2 for the Cunning Cleric class!\nType 3 for the Rapid Ranger class!");
        classChoice = Convert.ToInt32(Console.ReadLine());



        switch (classChoice)
        {
            case 1:
                Console.WriteLine("So you have chosen the Mighy Warrior. Your journey begins now adventurer!");
                Console.WriteLine("What should we call you, hero?");
                characterName = Console.ReadLine();
                Console.WriteLine($"{characterName}... truly a name fit for a hero.");
                character = new MightyWarrior(characterName, 25);

                break;
            case 2:
                Console.WriteLine("So you have chosen the Cunning Cleric. Your journey begins now adventurer!");
                Console.WriteLine("What should we call you, hero?");
                characterName = Console.ReadLine();
                Console.WriteLine($"{characterName}... truly a name fit for a hero.");
                character = new CunningCleric(characterName, 20);
                break;
            case 3:
                Console.WriteLine("So you have chosen the Rapid Ranger. Your journey begins now adventurer!");
                Console.WriteLine("What should we call you, hero?");
                characterName = Console.ReadLine();
                Console.WriteLine($"{characterName}... truly a name fit for a hero.");
                character = new RapidRanger(characterName, 15);
                break;
            case (> 3):
                Console.WriteLine("Wrong input.");
                break;
        }



        Console.ReadKey();
    }
}
public class Character
{
    private string name;
    private int health;
    private bool isAlive;

    public Character(string name, int health)
    {

    }
    public void dealDamage(int damage)
    {
    
    }
    public void receiveDamage(Character character)
    {

    }
    public bool isDead()
    {
        return isAlive;
    }
}

class MightyWarrior : Character
{
    public MightyWarrior(string name, int health) : base(name, health)
    {

    }
    public void dealDamage()
    { 
    
    }
}

class CunningCleric : Character
{
    public CunningCleric(string name, int health) : base(name, health)
    {

    }
    public void dealDamage()
    { 
    
    }
}
class RapidRanger : Character
{
    public RapidRanger(string name, int health) : base(name, health)
    {

    }
    public void dealDamage()
    { 
    
    }
}