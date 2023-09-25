using System.Runtime.InteropServices;



int hp1 = 100;
int hp2 = 100;
string tryagain = "yes";

// Initial information

Console.WriteLine("Welcome!");
Console.ReadLine();
Console.WriteLine("Here is a short summary the rules of the game: ");
Console.ReadLine();
Console.WriteLine("Win by beign the only one left alive or by having the most HP left after the rounds are over.");
Console.ReadLine();
Console.WriteLine("That's it. Now lets start. I'm getting impatient.");
Console.ReadLine();

// generator = variabel som kan innehålla en slumpgenerator
Random generator = new Random();

while (tryagain == "yes")
{

    int round = 0;


    Console.WriteLine("Player 1. Please name your Warrior.");
    Console.WriteLine(@"   |\---/|
   | ,_, |
    \_`_/-..----.
 ___/ `   ' ,""+ \  sk
(__...'   __\    |`.___.';
  (_,...'(_,.`__)/'.....+");
    Console.WriteLine("");
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
    Console.WriteLine(@"              __
             /'{>
         ____) (____
       //'--;   ;--'\\
      ///////\_/\\\\\\\
jgs          m m");
    Console.WriteLine("");
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
    // namn klart här----------------------------------
    // hur många rundor vv

    Console.WriteLine("");
    Console.WriteLine("How many rounds would you like to go?");
    Console.WriteLine("Type in a number between 5 and 20.");
    int NrOfRounds = Convert.ToInt32(Console.ReadLine());

    moveon = "no";
    while (moveon == "no")
    {
        if (NrOfRounds < 5)
        {
            Console.WriteLine("You can not choose a number lower than 5.");
            Console.WriteLine("Choose a new number of rounds.");
            NrOfRounds = Convert.ToInt32(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("no");
            Console.ReadLine();
        }
    }

    // rundorna börjar här-----------------------------
    while (hp1 > 0 && hp2 > 0)
    {
        // runda nr och HP kvar
        Console.WriteLine("");
        round++;
        Console.WriteLine($"Round {round}:");
        Console.WriteLine("");
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

        Console.WriteLine($"{player1}, (A) scratch with claws, or (B) hiss to intimmidate?");
        Console.WriteLine(@"                      (`.-,')
                    .-'     ;
                _.-'   , `,-
          _ _.-'     .'  /._
        .' `  _.-.  /  ,'._;)
       (       .  )-| (
        )`,_ ,'_,'  \_;)
('_  _,'.'  (___,))
 `-:;.-'");
        
        string attack1 = Console.ReadLine().ToLower();
        // player1 attack
        
        moveon = "no";
        while (moveon == "no")
        {
            if (attack1 == "a")
            {
                int hitormiss1a = generator.Next(100);

                if (hitormiss1a > 50)
                {
                    int damage1 = generator.Next(30,60);
                    hp2 -= damage1;
                    Console.WriteLine($"HIT. {player1} does {damage1} damage to {player2}.");
                    moveon = "yes";
                }
                else
                {
                    Console.WriteLine($"MISS. {player1} does no damage to {player2}.");
                    moveon = "yes";
                }
            }
            if (attack1 == "b")
            {
                int hitormiss1b = generator.Next(100);

                if (hitormiss1b > 10)
                {
                    int damage1 = generator.Next(10, 30);
                    hp2 -= damage1;
                    Console.WriteLine($"SUCCESS. {player1} does {damage1} emotional damage to {player2}.");
                    moveon = "yes";
                }
                else
                {
                    Console.WriteLine($"FAIL. {player2} was not intimmidated and takes no damage.");
                    moveon = "yes";
                }
            }
             else if (attack1 != "a" && attack1 != "b")
            {
                Console.WriteLine("Write A or B.");
                attack1 = Console.ReadLine();
            }
        }

        Console.ReadLine();
        Console.WriteLine($"{player2}, (A) bite harshly, or (B) honk to intimmidate?");
        Console.WriteLine(@"           ___  
       _,-' ______
     .'  .-'  ____7
    /   /   ___7
  _|   /  ___7
>(')\ | ___7     jgs
  \\/     \_______
  '        _======>
  `'----\\`");
        string attack2 = Console.ReadLine().ToLower();

        moveon = "no";
        while (moveon == "no")
        {
            if (attack2 == "a")
            {
                int hitormiss2a = generator.Next(100);

                if (hitormiss2a > 50)
                {
                    int damage2 = generator.Next(30,60);
                    hp1 -= damage2;
                    Console.WriteLine($"HIT. {player2} does {damage2} damage to {player1}.");
                    moveon ="yes";
                }
                else
                {
                    Console.WriteLine($"MISS. {player2} does no damage to {player1}.");
                    moveon = "yes";
                }
            }
            if (attack2 == "b")
            {
                int hitormiss2b = generator.Next(100);

                if (hitormiss2b > 10)
                {
                    int damage2 = generator.Next(10, 30);
                    hp1 -= damage2;
                    Console.WriteLine($"SUCCESS. {player2} does {damage2} emotional damage to {player1}.");
                    moveon = "yes";
                }
                else
                {
                    Console.WriteLine($"FAIL. {player1} was not intimmidates and takes no damage.");
                    moveon = "yes";
                }
            }
            else if (attack2 != "a" && attack2 != "b")
            {
                Console.WriteLine("Write A or B.");
                attack2 = Console.ReadLine();
            }
        }
    }


    // the end result-----------------------------------------
    if (hp1 <= 0)
    {
        Console.WriteLine("");
        Console.WriteLine($"{player1}'s HP: {hp1}");
        Console.WriteLine($"{player2}'s HP: {hp2}");
        Console.WriteLine("GAME OVER!");
        Console.WriteLine($"The winner is {player2}!");
        Console.WriteLine(@"              __
             /'{>
         ____) (____
       //'--;   ;--'\\
      ///////\_/\\\\\\\
jgs          m m");
        Console.ReadLine();
        Console.WriteLine("Would you like to try again?");
        tryagain = Console.ReadLine().ToLower();
    }
    else if (hp2 <= 0)
    {
        Console.WriteLine("");
        Console.WriteLine($"{player1}'s HP: {hp1}");
        Console.WriteLine($"{player2}'s HP: {hp2}");
        Console.WriteLine("GAME OVER!");
        Console.WriteLine($"The winner is {player1}!");
        Console.WriteLine(@"   |\---/|
   | ,_, |
    \_`´/-..----.
 ___/ `   ' ,""+ \  sk
(__...'   __\    |`.___.';
  (_,...'(_,.`__)/'.....+");
        Console.ReadLine();
        Console.WriteLine("Would you like to try again?");
        tryagain = Console.ReadLine().ToLower();
    }
    else if (hp1 <= 0 && hp2 <= 0)
    {
        Console.WriteLine("");
        Console.WriteLine($"{player1}'s HP: {hp1}");
        Console.WriteLine($"{player2}'s HP: {hp2}");
        Console.WriteLine("GAME OVER!");
        Console.WriteLine("You both lost. Or won? Depends on how you look at it. In any case, you're both dead.");
        Console.ReadLine();
        Console.WriteLine("Would you like to try again?");
        tryagain = Console.ReadLine().ToLower();
    }

    while (tryagain != "yes" && tryagain != "no")
        {
            Console.WriteLine("Yes or no?");
            tryagain = Console.ReadLine().ToLower();
        }
}