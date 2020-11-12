using System;
using System.Threading;

namespace pg3302_Eksamen
{
    internal class Program
    {
        private Dealer _dealer;
        private static readonly object Lock = new object();
        private bool _win;

        public void Start()
        {
            Console.WriteLine("Hi, and welcome to this card game!");

            var inputPlayer = GetPlayerCount();
            var players = IntiGame(inputPlayer);

            _win = false;
            foreach (var player in players)
            {
                var thread = new Thread(() => { Play(player); });
                thread.Start();
            }
        }

        private void Play(Player player)
        {
            while (!_win)
            {
                _win = OneRound(player);
                Thread.Sleep(200);
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
                player[i] = new Player(_dealer, i + 1);
                Console.WriteLine("-------------");
                Console.WriteLine("player: " + player[i].GetId());
                player[i].AddCardToHand();
                player[i].AddCardToHand();
                player[i].AddCardToHand();
                player[i].AddCardToHand();
                player[i].ShowHand();
            }
            return player;
        }

        private static bool OneRound(Player player)
        {
            lock (Lock)
            {
                Console.WriteLine("-------------");
                Console.WriteLine("player: " + player.GetId());
                player.AddCardToHand();
                player.RemoveCardToHand();
                player.ShowHand();
            }
            var winning = player.SeeIfWins();
            if (winning)
                Console.WriteLine("player " + player.GetId() + " wins!!!");
            return winning;
        }
    }
}