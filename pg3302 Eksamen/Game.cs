using System;
using System.Collections.Generic;
using pg3302_Eksamen.Cards;
using pg3302_Eksamen.dealers;
using pg3302_Eksamen.dealers.Interface;
using pg3302_Eksamen.players.Interface;

namespace pg3302_Eksamen
{
    public class Game
    {
        private static readonly object Lock = new object();
        private static bool _win;
        private readonly IDealer _dealer;

        public Game()
        {
            _dealer = Dealer.GetInstance();
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
                try
                {
                    var inputPlayer = int.Parse(Console.ReadLine()!);
                    if (inputPlayer < 2 || inputPlayer > 4)
                    {
                        Console.WriteLine($"Error cant be {inputPlayer}. Can only be 2-4 players.");
                    }
                    else
                    {
                        Console.WriteLine($"{inputPlayer} players!");
                        return inputPlayer;
                    }
                }
                catch
                {
                    Console.WriteLine("error cant parse input. Try again");
                }
            }
        }

        private IEnumerable<IPlayer> IntiGame(int inputPlayer)
        {
            var player = new List<IPlayer>();
            for (var i = 0; i < inputPlayer; i++)
            {
                player.Add(Factory.GeneratePlayer());
                StandardMessage.PlayerMassage(i + 1);
                player[i].AddNonSpecialCardToHand(4);
                player[i].ShowHand();
            }

            Console.WriteLine("-------------");
            new SpecialCards();
            return player;
        }

        public static void OneRound(IPlayer player)
        {
            lock (Lock)
            {
                if (GetWin()) return;
                var canGo = player.AddCardToHand(player);
                if (canGo) player.RemoveCardFromHand();
                player.ShowHand();

                if (!player.SeeIfWins()) return;
                _win = true;
                StandardMessage.WinMassage();
                Console.ReadLine();
            }
        }

        public static bool GetWin()
        {
            return _win;
        }
    }
}