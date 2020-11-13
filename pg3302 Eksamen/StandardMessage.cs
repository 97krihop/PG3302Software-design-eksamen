using System;
using System.Collections.Generic;
using System.Threading;

namespace pg3302_Eksamen
{
    public static class StandardMessage
    {
        public static void PlayerMassage()
        {
            Console.WriteLine("-------------");
            Console.WriteLine($"player: {Thread.CurrentThread.Name}");
        }

        public static void PlayerMassage(int i)
        {
            Console.WriteLine("-------------");
            Console.WriteLine($"player: {i}");
        }

        public static void StartMassage()
        {
            Console.WriteLine("Hi, and welcome to this card game!");
        }        
        public static void DrawMassage(Cards card)
        {
            Console.WriteLine($"BasePlayer {Thread.CurrentThread.Name}: drew {card.ToString().Replace("_"," of ")}");
        }

        public static void HandMassage(IEnumerable<Cards> cards)
        {
            foreach (var card in cards) 
                Console.WriteLine(card.ToString());
        }

        public static void WinMassage()
        {
            Console.WriteLine("-------------");
            Console.WriteLine($"player {Thread.CurrentThread.Name} wins!!!");
            Console.WriteLine("<><><><><><><>");
            Console.WriteLine("-------------");
            Console.WriteLine("   ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░▒▒▒▒░░░░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒░▒▒▒▒▒▒░░░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒░░░░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒░░░░░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒░░░░░░░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒░▒▒▒░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒░░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒░░░░░▓▓");
            Console.WriteLine("   ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░░░▓▓");
            Console.WriteLine("   ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.WriteLine("       ▒          ▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("      ▒               ▒▒▒▒▒▒▒▒");
            Console.WriteLine("     ▒                ▒▒▒▒▒▒▒▒");
            Console.WriteLine("    ▒           ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("   ▒");
            Console.WriteLine("  ▒      ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.WriteLine(" ▒      ▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓");
            Console.WriteLine("▒▒▒▒   ▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓");
            Console.WriteLine("▒▒▒▒  ▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓");
            Console.WriteLine("▒▒▒  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            // https://text-symbols.com/ascii-art/
        }
    }
}