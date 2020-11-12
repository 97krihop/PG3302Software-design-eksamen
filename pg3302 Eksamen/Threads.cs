using System.Collections.Generic;
using System.Threading;


namespace pg3302_Eksamen
{
    public static class Threads
    {
        public static void GenerateThread(IEnumerable<Player> players)
        {
            var i = 1;
            foreach (var player in players)
            {
                var thread = new Thread(() => { Play(player); }) {Name = i.ToString()};
                thread.Start();
                i++;
                
            }
        }

        private static void Play(IPlayer player)
        {
            while (!Program.GetWin())
            {
                Program.OneRound(player);
                Thread.Sleep(200);
            }
        }
    }
}