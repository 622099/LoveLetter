using System;

namespace LoveLetter
{

    public class Card
    {
        public bool inDeck = true;
        public string name;
        public int whoHas;

    }


    class Program
    {

        static void playGuard(Card[] qCards)
        {
            string targetCard = "unassigned";
            Console.WriteLine("Who do you want to use Guard on?");
            int playerSelection = int.Parse(Console.ReadLine());

            for (int j = 0; j < 15; j++)
            {
                if (qCards[j].whoHas == playerSelection)
                {
                    targetCard = qCards[j].name;
                }
            }

            Console.WriteLine("And what do you think their card is?");
            string targetSelection = Console.ReadLine();
            if (targetSelection == targetCard)
            {
                Console.Clear();
                Console.WriteLine("Correct!! " + playerSelection + " is out!");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Incorrect");
                Console.ReadLine();
            }
        }


        static void Main(string[] args)
        {
            int cardsInDeck = 16;
            int numPlayers = 1;
            Console.WriteLine("Welcome to Love Letter");
            while (numPlayers != 2 && numPlayers != 3 && numPlayers != 4)
            {

                Console.WriteLine("How many Players are there? Enter a number between 2-4");
                try
                {
                    numPlayers = int.Parse(Console.ReadLine());
                    if (numPlayers < 2 || numPlayers > 4)
                    {
                        Console.WriteLine("Enter a number between 2-4");
                    }
                }
                catch
                {
                    Console.WriteLine("Enter a number between 2-4");
                }

            }
            string[] playerNames = new string[numPlayers];
            for (int i = 0; i < numPlayers; i++)
            {
                Console.WriteLine("What is the name of Player" + (i + 1) + "?");
                playerNames[i] = Console.ReadLine();
            }


            T[] InitializeArray<T>(int length) where T : new()
            {
                T[] array = new T[length];
                for (int i = 0; i < length; ++i)
                {
                    array[i] = new T();
                }

                return array;
            }

            Card[] cards = InitializeArray<Card>(16);
            cards[0].name = "Guard1";
            cards[1].name = "Guard2";
            cards[2].name = "Guard3";
            cards[3].name = "Guard4";
            cards[4].name = "Guard5";
            cards[5].name = "Priest1";
            cards[6].name = "Priest2";
            cards[7].name = "Baron1";
            cards[8].name = "Baron2";
            cards[9].name = "Handmaid1";
            cards[10].name = "Handmaid2";
            cards[11].name = "Prince1";
            cards[12].name = "Prince2";
            cards[13].name = "King";
            cards[14].name = "Courtess";
            cards[15].name = "Princess";


            for (int i = 0; i < numPlayers + 1; i++) //asigning inital cards
            {
            Retry:
                Random rand = new Random();
                int randInt = rand.Next(0, 15);
                if (cards[randInt].inDeck == false)
                {
                    goto Retry;
                }
                else
                {
                    cards[randInt].inDeck = false;
                    cards[randInt].whoHas = i;
                }
            }

            for (int i = 0; i < 16; i++)
            {
                if (cards[i].inDeck == true)
                {
                    cards[i].whoHas = numPlayers + 1;
                }
            }
            bool gameOver = false;
            while (gameOver == false)
            {

                for (int i = 0; i < numPlayers; i++)
                {
                    string selection = "select";
                    string selection2 = "select2";
                    int playerCard1 = 20;
                    int playerCard2 = 20;
                    Console.Clear();
                    Console.WriteLine(playerNames[i] + "'s Turn:");
                    for (int j = 0; j < 16; j++)
                    {
                        if (cards[j].whoHas == i)
                        {
                            Console.WriteLine("Your drawn card is " + cards[j].name);

                        }
                    }
                    Console.WriteLine("Press enter to draw another card:");
                    Console.ReadLine();
                Retry:
                    Random rand = new Random();
                    int randInt = rand.Next(0, 15);
                    if (cards[randInt].inDeck == false)
                    {
                        goto Retry;
                    }
                    else
                    {
                        cards[randInt].inDeck = false;
                        cards[randInt].whoHas = i;
                    }
                    for (int j = 0; j < 16; j++)
                    {

                        if (cards[j].whoHas == i)
                        {
                            Console.WriteLine("Your drawn card is " + cards[j].name);
                            if (playerCard1 > 15)
                            {
                                playerCard1 = j;
                            }
                            else
                            {
                                playerCard2 = j;
                            }

                        }
                    }
                    while (selection != "a" && selection != "b")
                    {
                        Console.WriteLine("Which card would you like to play?");
                        Console.WriteLine("Press A to play " + cards[playerCard1].name);
                        Console.WriteLine("Press B to play " + cards[playerCard2].name);
                        selection = Console.ReadLine();
                    }

                    if (playerCard1 <= 4)
                    {
                        playGuard(cards);
                    }
                    else if (playerCard1 == 5 || playerCard1 == 6)
                    {
                        Console.WriteLine("Who's cards do you want to look at?");
                        int playerSelection = int.Parse(Console.ReadLine());
                        for (int j = 0; j < 15; j++)
                        {
                            if (cards[j].whoHas == playerSelection)
                            {
                                Console.WriteLine("Player" + playerSelection + " has " + cards[j].name);
                            }
                        }

                    }
                    else if (playerCard1 == 7 || playerCard1 == 8)
                    {
                        Console.WriteLine("Who would you like to target?");
                        int playerSelection = int.Parse(Console.ReadLine());
                        int value;
                        for (int j = 0; j < 15; j++)
                        {
                            if (cards[j].whoHas == playerSelection)
                            {
                                value = j;
                            }
                            else
                            {
                                value = 1;
                            }
                            if (value > playerCard1)
                            {
                                Console.WriteLine("Player " + playerSelection + " is out.");
                            }
                            else
                            {
                                Console.WriteLine("No Effect");
                            }
                        }
                    }
                    else if (playerCard1 == 11 || playerCard1 == 12)
                    {
                        Console.WriteLine("Who would you like to choose?");
                        int playerSelection = int.Parse(Console.ReadLine());


                        for (i = 0; i < 15; i++)
                        {
                            if (cards[i].whoHas == playerSelection)
                            {
                                cards[i].whoHas = 4;
                            }

                        }
                    Again:
                        Random randPrince = new Random();
                        int randIntPrince = rand.Next(0, 15);
                        if (cards[randIntPrince].inDeck == false)
                        {
                            goto Again;
                        }
                        else
                        {
                            cards[randIntPrince].inDeck = false;
                            cards[randIntPrince].whoHas = playerSelection;
                        }

                        Console.ReadLine();


                    }

                }

















            }
        }
    }
}
