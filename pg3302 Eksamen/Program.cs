namespace pg3302_Eksamen
{
    public static class Program
    {
        private static void Main()
        {
            var game = Factory.GenerateGame();
            game.Start();
        }
    }
}