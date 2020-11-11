using System;

namespace pg3302_Eksamen
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hi, and welcome to this card game!");

            while (true)
            {
                Console.WriteLine("How many players? (2-4)");
                var inputPlayer = int.Parse(Console.ReadLine()!);
                if (inputPlayer < 2 || inputPlayer > 4)
                {
                    Console.WriteLine("Error cant be " + inputPlayer + ". Can only be 2-4 palyers.");
                }
                else
                {
                    Console.WriteLine(inputPlayer + " players!");
                    var dealer = new Dealer();
                    var player = new Player[inputPlayer];
                    for (var i = 0; i < inputPlayer; i++)
                    {
                        player[i] = new Player();
                        Console.WriteLine("-------------");
                        Console.WriteLine("player: " + (i + 1));
                        player[i].AddCardToHand(dealer.DrawCard());
                        player[i].AddCardToHand(dealer.DrawCard());
                        player[i].AddCardToHand(dealer.DrawCard());
                        player[i].AddCardToHand(dealer.DrawCard());
                        player[i].ShowHand();
                    }

                    var win = false;
                    while (!win)
                    {
                        for (var i = 0; i < inputPlayer; i++)
                        {
                            Console.WriteLine("-------------");
                            Console.WriteLine("player: " + (i + 1));
                            player[i].AddCardToHand(dealer.DrawCard());
                            dealer.DiscardCard(player[i].RemoveCardToHand());
                            player[i].ShowHand();
                            win = player[i].SeeIfWins();
                            if (win)
                            {
                                Console.WriteLine("player" + i + " wins!!!");
                            }
                        }
                    }

                    break;
                }
            }
        }
    }
}