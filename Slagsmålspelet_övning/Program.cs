using System.Runtime.InteropServices;


// namnet på kodblocket är SayHello
// Static (svårt att berätta vad den gör men den behövs)
// paranteserna är vad man stoppar in i metoden, variabler, text, nummer etc.?
// console.WriteLine("hej"); är en metod, vi stoppar in hej i metoden WriteLine
// metoder: gör saker ("verb"), paranteserna ()
// say hello är en void metod, den tar inte emot något och ger inte ifrån sig något (writeline = tar emot, readline = ger ut)
// Tänk på hundarna

// Sayhello(); kallar på hunden SayHello vv
// Metoden/hunden kan ligga varsomhelst i koden, den kan ligga längst ner
// Använd metoder om: man sitter och skriver samma saker hela tiden, man har svårt att läsa av logiken i sin kod 
// (eg. interaktiv berättelse, ha texten utanför if satserna och kalla på texternas metoder i if satserna istället)

// static void SayHello()
// {
//     Console.WriteLine("Hello");
// }


int hp1 = 100;
int hp2 = 100;
string tryagain = "yes";
int wins1 = 0;
int wins2 = 0;

// Initial information

Console.WriteLine("Welcome!");
Console.ReadLine();
Console.WriteLine("Here is a short summary the rules of the game: ");
Console.ReadLine();
Console.WriteLine("Win by beign the only one left alive or by having the most HP left after the rounds are over.");
Console.ReadLine();
Console.WriteLine("That's it. Now lets start.");
Console.ReadLine();


// namn
Console.WriteLine("Player 1. Please name your Warrior.");

DrawCat();
Console.WriteLine("");
Console.Write("Name: ");
string player1 = GetName();

Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Player 2. Please name your warrior.");

DrawGoose();
Console.WriteLine("");
Console.Write("Name: ");
string player2 = GetName();

// namn klart här----------------------------------
// Börja spelets while loop, namn är samma om man kör igen
// hur många rundor vv

// generator = variabel som kan innehålla en slumpgenerator
Random generator = new Random();

while (tryagain == "yes")
{

    int round = 0;
    hp1 = 100;
    hp2 = 100;

    Console.WriteLine("");
    Console.WriteLine("How many rounds would you like to go?");

    bool success = false;
    int NrOfRounds = 0;
    while (!success || NrOfRounds < 5 || NrOfRounds > 20)
    {
        Console.WriteLine("Type in a number between 5 and 20.");
        // int NrOfRounds = Convert.ToInt32(Console.ReadLine());
        success = int.TryParse(Console.ReadLine(), out NrOfRounds);
    }

    // rundorna börjar här-----------------------------
    while (hp1 > 0 && hp2 > 0 && round < NrOfRounds)
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
        DrawCatAttack();

        string attack1 = Console.ReadLine().ToLower();
        // player1 attack

        string moveon = "no";
        while (moveon == "no")
        {
            if (attack1 == "a")
            {
                int hitormiss1a = generator.Next(100);

                if (hitormiss1a > 55)
                {
                    int damage1 = generator.Next(40, 50);
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

                if (hitormiss1b > 20)
                {
                    int damage1 = generator.Next(10, 20);
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
        DrawGooseAttack();
        string attack2 = Console.ReadLine().ToLower();

        moveon = "no";
        while (moveon == "no")
        {
            if (attack2 == "a")
            {
                int hitormiss2a = generator.Next(100);

                if (hitormiss2a > 55)
                {
                    int damage2 = generator.Next(40, 50);
                    hp1 -= damage2;
                    Console.WriteLine($"HIT. {player2} does {damage2} damage to {player1}.");
                    moveon = "yes";
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

                if (hitormiss2b > 20)
                {
                    int damage2 = generator.Next(10, 20);
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

    // End of rounds/Someone dies--------------------------
    // ----------------------------------------------------

    if (NrOfRounds == round || hp1 <= 0 || hp2 <= 0)
    {
        Console.ReadLine();
        Console.WriteLine("");

        if (hp1 > hp2 && hp1 > 0)
        {
            Console.WriteLine("");
            Console.WriteLine($"{player1}'s HP: {hp1}");
            Console.WriteLine($"{player2}'s HP: {hp2}");
            Console.WriteLine("");
            Console.WriteLine("GAME OVER!");
            Console.WriteLine($"The winner is {player1}!");
            wins1++;
            DrawCat();
        }
        else if (hp2 > hp1 && hp2 > 0)
        {
            Console.WriteLine("");
            Console.WriteLine($"{player1}'s HP: {hp1}");
            Console.WriteLine($"{player2}'s HP: {hp2}");
            Console.WriteLine("");
            Console.WriteLine("GAME OVER!");
            Console.WriteLine($"The winner is {player2}!");
            wins2++;
            DrawGoose();
        }
        else if (hp1 == hp2 && hp1 > 0)
        {
            Console.WriteLine("");
            Console.WriteLine($"{player1}'s HP: {hp1}");
            Console.WriteLine($"{player2}'s HP: {hp2}");
            Console.WriteLine("");
            Console.WriteLine("GAME OVER!");
            Console.WriteLine("You both won. I guess?");
            wins1++;
            wins2++;
        }
        else if (hp2 < 0 && hp1 < 0)
        {
            Console.WriteLine("");
            Console.WriteLine($"{player1}'s HP: {hp1}");
            Console.WriteLine($"{player2}'s HP: {hp2}");
            Console.WriteLine("");
            Console.WriteLine("GAME OVER!");
            Console.WriteLine("You both lost. :(");
            Console.WriteLine("");
            Console.WriteLine("R.I.P.");
        }

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine($"{wins1}/{wins2}");
        Console.WriteLine("");
        Console.WriteLine("Would you like to try again?");
        tryagain = Console.ReadLine().ToLower();


        while (tryagain != "yes" && tryagain != "no")
        {
            Console.WriteLine("Yes or no?");
            tryagain = Console.ReadLine().ToLower();
        }
    }
}




// Metoder
// Static string eftersom den ska skriva ut något i slutet
static string GetName()
{
    string name = Console.ReadLine();

    string moveon = "no";
    while (moveon == "no")
    {
        // player1.Length = en int för antalet bokstäver i stringen player1
        if (name.Length < 3)
        {
            Console.WriteLine("The name cannot be shorter than 3 characters. Try again.");
            Console.Write("Name: ");
            name = Console.ReadLine();
        }
        else if (name.Length > 10)
        {
            Console.WriteLine("The name cannot be longer than 10 characters. Try again.");
            Console.Write("Name: ");
            name = Console.ReadLine();
        }
        else
        {
            moveon = "yes";
        }
    }

    // return för att den ska skriva ut det den får ut av metoden
    return name;
}

static void DrawCat()
{
    Console.WriteLine(@"   |\---/|
   | ,_, |
    \_`_/-..----.
 ___/ `   ' ,""+ \  sk
(__...'   __\    |`.___.';
  (_,...'(_,.`__)/'.....+");
}

static void DrawGoose()
{
    Console.WriteLine(@"              __
             /'{>
         ____) (____
       //'--;   ;--'\\
      ///////\_/\\\\\\\
jgs          m m");
}

static void DrawCatAttack()
{
    Console.WriteLine(@"                      (`.-,')
                    .-'     ;
                _.-'   , `,-
          _ _.-'     .'  /._
        .' `  _.-.  /  ,'._;)
       (       .  )-| (
        )`,_ ,'_,'  \_;)
('_  _,'.'  (___,))
 `-:;.-'");
}

static void DrawGooseAttack()
{
    Console.WriteLine(@"           ___  
       _,-' ______
     .'  .-'  ____7
    /   /   ___7
  _|   /  ___7
>(')\ | ___7     jgs
  \\/     \_______
  '        _======>
  `'----\\`");
}