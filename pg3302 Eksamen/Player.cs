using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    internal class Player
    {
        private readonly List<Cards> _hand;

        public Player()
        {
            _hand = new List<Cards>();
        }

        public void ShowHand()
        {
            foreach (var card in _hand)
            {
                Console.WriteLine(card.ToString());
            }
        }

        public bool SeeIfWins()
        {
            var heart = 0;
            var spade = 0;
            var diamond = 0;
            var club = 0;

            foreach (var card in _hand)
            {
                if (card.ToString().StartsWith("Heart")) heart++;
                if (card.ToString().StartsWith("Spade")) spade++;
                if (card.ToString().StartsWith("Diamond")) diamond++;
                if (card.ToString().StartsWith("Club")) club++;
            }

            if (heart >= 4) return true;
            if (spade >= 4) return true;
            if (diamond >= 4) return true;
            if (club >= 4) return true;
            return false;
        }

        public void AddCardToHand(Cards drawCard)
        {
            _hand.Add(drawCard);
        }

        public Cards RemoveCardToHand()
        {
            var card = _hand[0];
            _hand.Remove(card);
            return card;
        }
    }
}