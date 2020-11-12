using System;
using System.Collections.Generic;
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
            var i = 1;
            foreach (var player in players)
            {
                var thread = new Thread(() => { Play(player); }) {Name = i.ToString()};
                thread.Start();
                i++;
            }
        }

        private void Play(IPlayer player)
        {
            while (!_win)
            {
                OneRound(player);
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

        private IEnumerable<Player> IntiGame(int inputPlayer)
        {
            Console.WriteLine(inputPlayer + " players!");
            _dealer = new Dealer();
            var player = new Player[inputPlayer];
            for (var i = 0; i < inputPlayer; i++)
            {
                player[i] = new Player(_dealer);
                Console.WriteLine("-------------");
                Console.WriteLine("player: " + (1 + i));
                for (var j = 0; j < 4; j++)
                {
                    player[i].AddNonSpecialCardToHand();
                }

                player[i].ShowHand();
                if (!player[i].SeeIfWins()) continue;
                Console.WriteLine("player " + Thread.CurrentThread.Name + " wins!!!");
                _win = true;
            }

            _dealer.DrawSpecialCard();
            return player;
        }

        private void OneRound(IPlayer player)
        {
            lock (Lock)
            {
                if (_win) return;
                Console.WriteLine("-------------");
                Console.WriteLine("player: " + Thread.CurrentThread.Name);
                var canGo = player.AddCardToHand(player);
                if (canGo)
                {
                    player.RemoveCardFromHand();
                    player.ShowHand();
                }

                if (!player.SeeIfWins()) return;
                Console.WriteLine("player " + Thread.CurrentThread.Name + " wins!!!");
                _win = true;
            }
        }
    }
}