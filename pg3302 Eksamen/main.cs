namespace pg3302_Eksamen
{
    public static class MainCardGame
    {
        private static void Main()
        {
            var program = Factory.GenerateProgram();
            program.Start();
        }
    }
}