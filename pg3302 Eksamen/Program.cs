using System;

namespace pg3302_Eksamen
{
    internal class Program
    {
        private Dealer _dealer;
        private Player[] _player;

        public void Start()
        {
            Console.WriteLine("Hi, and welcome to this card game!");

            var inputPlayer = GetPlayerCount();

            _player = IntiGame(inputPlayer);

            var win = false;
            while (!win)
            {
                for (var i = 0; i < inputPlayer; i++)
                {
                    Console.WriteLine("-------------");
                    Console.WriteLine("player: " + (i + 1));
                    _player[i].AddCardToHand(_dealer.DrawCard());
                    _dealer.DiscardCard(_player[i].RemoveCardToHand());
                    _player[i].ShowHand();
                    win = _player[i].SeeIfWins();
                    if (win)
                    {
                        Console.WriteLine("player " + (i + 1) + " wins!!!");
                    }
                }
            }
        }


        private static int GetPlayerCount()
        {
            while (true)
            {
                Console.WriteLine("How many players? (2-4)");
                var inputPlayer = int.Parse(Console.ReadLine()!);
                if (inputPlayer < 2 || inputPlayer > 4)
                    Console.WriteLine("Error cant be " + inputPlayer + ". Can only be 2-4 palyers.");
                else
                    return inputPlayer;
            }
        }


        private Player[] IntiGame(int inputPlayer)
        {
            Console.WriteLine(inputPlayer + " players!");
            _dealer = new Dealer();
            var player = new Player[inputPlayer];
            for (var i = 0; i < inputPlayer; i++)
            {
                player[i] = new Player();
                Console.WriteLine("-------------");
                Console.WriteLine("player: " + (i + 1));
                player[i].AddCardToHand(_dealer.DrawCard());
                player[i].AddCardToHand(_dealer.DrawCard());
                player[i].AddCardToHand(_dealer.DrawCard());
                player[i].AddCardToHand(_dealer.DrawCard());
                player[i].ShowHand();
            }

            return player;
        }
    }
}