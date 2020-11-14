using System;
using System.Collections.Generic;
using System.Threading;

namespace pg3302_Eksamen
{
    public static class SpecialCards
    {
        private static readonly List<Cards> SpecialCard = new List<Cards>();

        public static bool EqualJoker(Cards card) => SpecialCard[3].Equals(card);

        public static bool EqualBomb(Cards card) => SpecialCard[2].Equals(card);

        public static void SetCard(Cards card) => SpecialCard.Add(card);

        public static List<Cards> GetSpecialCards() => SpecialCard;

        public static bool SeeIfSpecialCard(IPlayer player, Cards card)
        {
            var number = 0;
            for (var i = 0; i < SpecialCard.Count - 1; i++)
                if (card.Equals(SpecialCard[i]))
                    number = i + 1;
            var message = $"player {Thread.CurrentThread.Name}";
            switch (number)
            {
                case 1:
                    Console.WriteLine("-------------");
                    Console.WriteLine($"{message} drew Quarantine");
                    player.SetQuarantine();
                    break;
                case 2:
                    Console.WriteLine("-------------");
                    Console.WriteLine($"{message} drew Vulture");
                    player.AddNonSpecialCardToHand(1);
                    break;
                case 3:
                    Console.WriteLine("-------------");
                    Console.WriteLine($"{message} drew Bomb");
                    player.RemoveAllCardFromHand();
                    for (var i = 0; i < 4; i++) player.AddCardToHand(player);
                    return false;
                case 4:
                    Console.WriteLine("-------------");
                    Console.WriteLine($"{message} drew Joker");
                    break;
            }

            return true;
        }
    }
}