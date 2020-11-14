using System;
using System.Collections.Generic;
using System.Threading;
using pg3302_Eksamen.players.Interface;

namespace pg3302_Eksamen.Cards
{
    public static class SpecialCards
    {
        private static readonly List<Card> SpecialCard = new List<Card>();

        public static bool EqualJoker(Card card)
        {
            return SpecialCard[3].Equals(card);
        }

        public static bool EqualBomb(Card card)
        {
            return SpecialCard[2].Equals(card);
        }

        public static void SetCard(Card card)
        {
            SpecialCard.Add(card);
        }

        public static List<Card> GetSpecialCards()
        {
            return SpecialCard;
        }

        public static bool SeeIfSpecialCard(IPlayer player, Card card)
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
                    player.AddNonSpecialCardToHand(4);
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