using System.Runtime.InteropServices;



int hp1 = 100;
int hp2 = 100;
string tryagain = "yes";

// generator = variabel som kan innehålla en slumpgenerator
Random generator = new Random();

while (tryagain == "yes")
{
    int round = 0;


    // namn
    Console.WriteLine("Player 1. Please name your Warrior.");
    Console.Write("Name: ");
    string player1 = Console.ReadLine();


    string moveon = "no";
    while (moveon == "no")
    {
        // player1.Length = en int för antalet bokstäver i stringen player1
        if (player1.Length < 3)
        {
            Console.WriteLine("The name cannot be shorter than 3 characters. Try again.");
            Console.Write("Name: ");
            player1 = Console.ReadLine();
        }
        else if (player1.Length > 10)
        {
            Console.WriteLine("The name cannot be longer than 10 characters. Try again.");
            Console.Write("Name: ");
            player1 = Console.ReadLine();
        }
        else
        {
            moveon = "yes";
        }
    }

    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("Player 2. Please name your warrior.");
    Console.Write("Name: ");
    string player2 = Console.ReadLine();


    moveon = "no";
    while (moveon == "no")
    {
        if (player2.Length < 3)
        {
            Console.WriteLine("The name cannot be shorter than 3 characters. Try again.");
            Console.Write("Name: ");
            player2 = Console.ReadLine();
        }
        else if (player2.Length > 10)
        {
            Console.WriteLine("The name cannot be longer than 10 characters. Try again.");
            Console.Write("Name: ");
            player2 = Console.ReadLine();
        }
        else
        {
            moveon = "yes";
        }
    }


    // rundorna börjar här-----------------------------
    while (hp1 > 0 && hp2 > 0)
    {
        // runda nr och HP kvar
        Console.WriteLine("");
        round++;
        Console.WriteLine($"Round {round}:");
        Console.WriteLine($"{player1}'s HP: {hp1}");
        Console.WriteLine($"{player2}'s HP: {hp2}");
        Console.ReadLine();

        // skada player 1
        // .Next eftersom man stoppar in generator talet och får ut nästa tal, typ. 
        // (20) för att ange vad max talet ska vara, annars blir det max värdet som en int kan ha
        // om (20,100) = som minst 20, som max 100

        // int damage1 = generator.Next(20);
        // hp2 -= damage1;
        // hp2 = Math.Max(0, hp2);
        // Console.WriteLine($"{player1} does {damage1} damage to {player2}");
        // Console.ReadLine();

        // // skada player 2
        // int damage2 = generator.Next(20);
        // hp1 -= damage2;
        // hp1 = Math.Max(0, hp1);
        // Console.WriteLine($"{player2} does {damage2} damage to {player1}");
        // Console.ReadLine();

        Console.WriteLine($"{player1}, (A)cast strong but difficult spell or (B)stab lightly with a dagger?");
        string attack = Console.ReadLine().ToLower();
        // player1 attack
        if (attack == "a")
        {
            int hitormiss1a = generator.Next(100);

            if (hitormiss1a > 60)
            {
                int damage1 = generator.Next(30,60);
                hp2 -= damage1;
                Console.WriteLine($"HIT. {player1} does {damage1} damage to {player2}.");
            }
            else
            {
                Console.WriteLine($"MISS. {player1} does no damage to {player2}.");
            }
        if (attack == "b")
        {
            int hitormiss1b = generator.Next(100);

            if (hitormiss1b > 20)
            {
                int damage2 = generator.Next(10, 30);
                hp2 -= damage2;
                Console.WriteLine($"HIT. {player2} does {damage2} damage to {player1}.");
            }
            else
            {
                Console.WriteLine($"MISS. {player2} does no damage to {player1}.");
            }
        }
        }

    }


    // the end result
    if (hp1 <= 0)
    {
        Console.WriteLine("");
        Console.WriteLine("GAME OVER!");
        Console.WriteLine($"The winner is {player2}!");
        Console.ReadLine();
        Console.WriteLine("Would you like to try again?");
        tryagain = Console.ReadLine().ToLower();
    }
    else if (hp2 <= 0)
    {
        Console.WriteLine("");
        Console.WriteLine("GAME OVER!");
        Console.WriteLine($"The winner is {player1}!");
        Console.ReadLine();
        Console.WriteLine("Would you like to try again?");
        tryagain = Console.ReadLine().ToLower();
    }
    else if (hp1 <= 0 && hp2 <= 0)
    {
        Console.WriteLine("");
        Console.WriteLine("GAME OVER!");
        Console.WriteLine("You both lost. Or won? Depends on how you look at it. In any case, you're both dead.");
        Console.ReadLine();
        Console.WriteLine("Would you like to try again?");
        tryagain = Console.ReadLine().ToLower();
    }
}