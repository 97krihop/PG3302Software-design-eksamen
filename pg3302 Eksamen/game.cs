using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    public class Game
    {
        private readonly IDealer _dealer;
        private static readonly object Lock = new object();
        private static bool _win;

        public Game()
        {
            _dealer = Factory.GenerateDealer();
        }

        public void Start()
        {
            StandardMessage.StartMassage();
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
                {
                    Console.WriteLine(inputPlayer + " players!");
                    return inputPlayer;
                }
            }
        }

        private IEnumerable<IPlayer> IntiGame(int inputPlayer)
        {
            var player = Factory.GenerateListPlayers();
            for (var i = 0; i < inputPlayer; i++)
            {
                player.Add(Factory.GeneratePlayer(_dealer));
                StandardMessage.PlayerMassage(i + 1);
                player[i].AddNonSpecialCardToHand(4);
                player[i].ShowHand();
            }

            Console.WriteLine("-------------");
            _dealer.DrawSpecialCards();
            return player;
        }

        public static void OneRound(IPlayer player)
        {
            lock (Lock)
            {
                if (GetWin()) return;
                StandardMessage.PlayerMassage();
                var canGo = player.AddCardToHand(player);
                if (canGo)
                    player.RemoveCardFromHand();
                player.ShowHand();


                if (!player.SeeIfWins()) return;
                _win = true;
                StandardMessage.WinMassage();
            }
        }

        public static bool GetWin()
        {
            return _win;
        }
    }
}