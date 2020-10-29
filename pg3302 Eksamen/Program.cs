using System;

namespace pg3302_Eksamen
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hi, and welcome to this card game!");

			while (true)
			{
				Console.WriteLine("How many players? (2-4)");
				var inputPlayer = int.Parse(Console.ReadLine()!);
				if (inputPlayer < 2 || inputPlayer > 4)
				{
					Console.WriteLine("Error cant be " + inputPlayer + ". Can only be 2-4 palyers.");
				}
				else
				{
					Console.WriteLine(inputPlayer + " players!");
					break;
				}
			}
		}
	}
}
