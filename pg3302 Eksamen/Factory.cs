using System;
using System.Collections.Generic;
using System.Threading;
using pg3302_Eksamen.Cards;
using pg3302_Eksamen.Players;
using pg3302_Eksamen.players.Interface;

namespace pg3302_Eksamen
{
    public static class Factory
    {
        public static void GenerateThread(IEnumerable<IPlayer> players)
        {
            var i = 1;
            foreach (var player in players)
            {
                Console.WriteLine("-------------");
                Console.WriteLine($"player: {i} Starts now");
                var thread = new Thread(() =>
                    {
                        Play(player);
                    })
                    {Name = i.ToString()};

                thread.Start();
                i++;
            }
        }

        private static void Play(IPlayer player)
        {
            while (!Game.GetWin())
            {
                Thread.Sleep(200);
                Game.OneRound(player);
            }
        }   
        public static IPlayer GeneratePlayer()
        {
            return new Player();
        }
        public static SpecialCard GenerateSpecialCards()
        {
            return new SpecialCard();
        }

        public static Game GenerateGame()
        {
            return new Game();
        }
    }
}