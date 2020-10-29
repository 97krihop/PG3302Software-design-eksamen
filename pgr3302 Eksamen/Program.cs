using System;

namespace pgr3302_Eksamen
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hi, and welcome to this card game! \nHow many players? (2-4)");
			string inputString = Console.ReadLine();
			int inputPlayer = int.Parse(inputString);

			Console.WriteLine(inputPlayer +" players!");
		}
	}
}
