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
                var thread = new Thread(() =>
                    {
                        while (!Program.GetWin())
                        {
                            Program.OneRound(player);
                            Thread.Sleep(200);
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

        public static List<IPlayer> GenerateListPlayers()
        {
            return new List<IPlayer>();
        }

        public static List<Cards> GenerateListCards()
        {
            return new List<Cards>();
        }        
        public static Dictionary<string, int> GenerateDictionary()
        {
            return new Dictionary<string, int>();
        }        
        public static Program GenerateProgram()
        {
            return new Program();;
        }
    }
}