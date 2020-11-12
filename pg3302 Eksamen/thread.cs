using System.Collections.Generic;

namespace pg3302_Eksamen
{
    public static class Thread
    {
        public static void GenerateThread(IEnumerable<Player> players)
        {
            var i = 1;
            foreach (var player in players)
            {
                var thread = new System.Threading.Thread(() => { Play(player); }) {Name = i.ToString()};
                thread.Start();
                i++;
            }
        }

        private static void Play(IPlayer player)
        {
            while (!Program.GetWin())
            {
                Program.OneRound(player);
                System.Threading.Thread.Sleep(200);
            }
        }
    }
}