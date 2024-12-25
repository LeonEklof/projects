using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string characterName = " ";
        int classChoice = 0;
        Character character = null;
        Character enemy = new Character("Goblin", 20);

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
                character = new Character(characterName, 25);

                break;
            case 2:
                Console.WriteLine("So you have chosen the Cunning Cleric. Your journey begins now adventurer!");
                Console.WriteLine("What should we call you, hero?");
                characterName = Console.ReadLine();
                Console.WriteLine($"{characterName}... truly a name fit for a hero.");
                character = new Character(characterName, 20);
                break;
            case 3:
                Console.WriteLine("So you have chosen the Rapid Ranger. Your journey begins now adventurer!");
                Console.WriteLine("What should we call you, hero?");
                characterName = Console.ReadLine();
                Console.WriteLine($"{characterName}... truly a name fit for a hero.");
                character = new Character(characterName, 15);
                break;
            default:
                Console.WriteLine("Wrong input.");
                break;
        }

        Console.WriteLine($"{characterName}. It is time for your first battle. May you be victorious...");
        battle(character, enemy);
        Console.ReadKey();
    }

    static void battle(Character player, Character enemy)
    {

        Random dmgnumber = new Random();
        int damage;
        int remPlayerHp;
        int remEnemyHp;

        while (player.isAlive() && enemy.isAlive())
        {
            damage = dmgnumber.Next(1, 6);
            remEnemyHp = enemy.takeDamage(damage);
            Console.WriteLine("Rolling for hero damage...");
            Console.WriteLine($"Hero did {damage} to the enemy!\nRemaining hp: {remEnemyHp}");

            damage = dmgnumber.Next(1, 6);
            remPlayerHp = player.takeDamage(damage);
            Console.WriteLine("Rolling for player damage...");
            Console.WriteLine($"Enemy did {damage} to the hero!\nRemaining hp: {remPlayerHp}");
            Console.ReadKey();

        }
    }
    public class Character
    {
        private string name;
        private int health;

        public Character(string name, int health)
        {
            this.health = health;
            this.name = name;
        }
        public int takeDamage(int damage)
        {
            health -= damage;

            if(health <= 0)
            {
                health = 0;
            }

            return health;
        }
        public bool isAlive()
        {
            if(health <= 0)
            {
                Console.WriteLine($"{name} has died!");
            }
            return health > 0;
        }
    }

    class MightyWarrior : Character
    {
        public MightyWarrior(string name, int health) : base(name, health)
        {

        }
    }

    class CunningCleric : Character
    {
        public CunningCleric(string name, int health) : base(name, health)
        {

        }
    }
    class RapidRanger : Character
    {
        public RapidRanger(string name, int health) : base(name, health)
        {

        }
    }
}