using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    internal class Player
    {
        private readonly Dealer _dealer;
        private readonly int _id;
        private readonly List<Cards> _hand;

        public Player(Dealer dealer, int id)
        {
            _dealer = dealer;
            _id = id;
            _hand = new List<Cards>();
        }

        public int GetId()
        {
            return _id;
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

        public void AddCardToHand()
        {
            _hand.Add(_dealer.DrawCard());
        }

        public void RemoveCardToHand()
        {
            var card = _hand[0];
            _hand.Remove(card);
            _dealer.DiscardCard(card);
        }
    }
}