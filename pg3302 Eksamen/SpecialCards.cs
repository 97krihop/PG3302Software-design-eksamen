using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    public static class SpecialCards
    {
        private static readonly List<Cards> SpecialCard = Factory.GenerateListCards();

        public static bool EqualJoker(Cards card)
        {
            return SpecialCard[3].Equals(card);
        }

        public static void SetCard(Cards card)
        {
            SpecialCard.Add(card);
        }

        public static List<Cards> GetSpecialCards()
        {
            return SpecialCard;
        }

        public static bool SeeIfSpecialCard(IPlayer player, Cards card)
        {
            var number = 0;
            for (var i = 0; i < SpecialCard.Count - 1; i++)
                if (card.Equals(SpecialCard[i]))
                    number = i + 1;

            switch (number)
            {
                case 1:
                    Console.WriteLine("you drew Quarantine");
                    player.Quarantine();
                    return true;
                case 2:
                    Console.WriteLine("you drew vulture");
                    player.AddNonSpecialCardToHand();
                    return true;
                case 3:
                    Console.WriteLine("you drew bomb");
                    player.RemoveAllCardFromHand();
                    for (var i = 0; i < 4; i++) player.AddCardToHand(player);
                    return false;
            }

            return true;
        }
    }
}