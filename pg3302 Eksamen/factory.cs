using System;
using System.Collections.Generic;
using System.Threading;

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
                        while (!Game.GetWin())
                        {
                            Thread.Sleep(200);
                            Game.OneRound(player);
                        }
                    })
                    {Name = i.ToString()};

                thread.Start();
                i++;
            }
        }

        public static IDealer GenerateDealer()
        {
            return new Dealer();
        }

        public static IPlayer GeneratePlayer(IDealer dealer)
        {
            return new Player(dealer);
        }
        
        public static Game GenerateProgram()
        {
            return new Game();
            ;
        }
    }
}