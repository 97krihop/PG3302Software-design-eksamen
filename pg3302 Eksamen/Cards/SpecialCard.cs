using System;
using System.Collections.Generic;
using System.Threading;
using pg3302_Eksamen.Dealers;
using pg3302_Eksamen.players.Interface;

namespace pg3302_Eksamen.Cards
{
    public class SpecialCard
    {
        private static readonly List<Card> SpecialCards = new List<Card>();
        //Bomb = _specialCards[0]
        //Vulture = _specialCards[1]
        //SetQuarantine = _specialCards[2]
        //Joker = _specialCards[3]

        public SpecialCard()
        {
            while (SpecialCards.Count <= 4)
                SpecialCards.Add(Dealer.GetInstance().DrawSpecialCards());
        }

        public static bool EqualJoker(Card card)
        {
            return SpecialCards[3].Equals(card);
        }

        public static bool EqualBomb(Card card)
        {
            return SpecialCards[2].Equals(card);
        }

        public static List<Card> GetSpecialCards()
        {
            return SpecialCards;
        }

        public static bool SeeIfSpecialCard(IPlayer player, Card card)
        {
            var number = 0;
            for (var i = 0; i < SpecialCards.Count - 1; i++)
                if (card.Equals(SpecialCards[i]))
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