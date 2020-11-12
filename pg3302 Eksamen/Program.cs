using System;
using System.Collections.Generic;
using System.Threading;

namespace pg3302_Eksamen
{
    public class Program
    {
        private readonly IDealer _dealer;
        private static readonly object Lock = new object();
        private static bool _win;

        public Program()
        {
            _dealer = Factory.GenerateDealer();
        }

        public void Start()
        {
            Console.WriteLine("Hi, and welcome to this card game!");
            var inputPlayer = GetPlayerCount();
            var players = IntiGame(inputPlayer);

            Factory.GenerateThread(players);
        }

        private static int GetPlayerCount()
        {
            while (true)
            {
                Console.WriteLine("How many players? (2-4)");
                var inputPlayer = int.Parse(Console.ReadLine()!);
                if (inputPlayer < 2 || inputPlayer > 4)
                    Console.WriteLine("Error cant be " + inputPlayer + ". Can only be 2-4 players.");
                else
                    return inputPlayer;
            }
        }

        private IEnumerable<IPlayer> IntiGame(int inputPlayer)
        {
            Console.WriteLine(inputPlayer + " players!");

            var player = Factory.GenerateListPlayers();
            for (var i = 0; i < inputPlayer; i++)
            {
                player.Add(Factory.GeneratePlayer(_dealer));
                Console.WriteLine("-------------");
                Console.WriteLine("player: " + (1 + i));
                for (var j = 0; j < 4; j++) player[i].AddNonSpecialCardToHand();
                player[i].ShowHand();
                if (!player[i].SeeIfWins()) continue;
                Console.WriteLine("player " + Thread.CurrentThread.Name + " wins!!!");
                _win = true;
            }

            _dealer.DrawSpecialCard();
            return player;
        }

        public static void OneRound(IPlayer player)
        {
            lock (Lock)
            {
                if (GetWin()) return;
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

        public static bool GetWin()
        {
            return _win;
        }
    }
}