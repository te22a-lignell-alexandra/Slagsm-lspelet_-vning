// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

int hp1 = 100;
int hp2 = 100;
string tryagain = "yes";

Random generator = new Random();

while (tryagain == "yes")
{
int round = 0;

// namn
Console.WriteLine("Player 1. Please name your Warrior.");
Console.Write("Name: ");
string player1 = Console.ReadLine();

Console.WriteLine("Player 2. Please name your warrior.");
Console.Write("Name: ");
string player2 = Console.ReadLine();

    while (hp1 > 0  && hp2 > 0)
    {
        // runda nr och HP kvar
        Console.WriteLine("");
        round ++;
        Console.WriteLine($"Round {round}:");
        Console.WriteLine($"\n{player1}'s HP: {hp1}");
        Console.WriteLine($"{player2}'s HP: {hp2}\n");
        Console.ReadLine();

        // skada player 1
        int damage1 = generator.Next(20);
        hp2 -= damage1;
        hp2 = Math.Max(0, hp2);
        Console.WriteLine($"{player1} does {damage1} damage to {player2}");
        Console.ReadLine();

        // skada player 2
        int damage2 = generator.Next(20);
        hp1 -= damage2;
        hp1 = Math.Max(0, hp1);
        Console.WriteLine($"{player2} does {damage2} damage to {player1}");
        Console.ReadLine();
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