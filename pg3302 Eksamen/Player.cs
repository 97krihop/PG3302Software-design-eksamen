using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    internal class Player : IPlayer
    {
        private readonly Dealer _dealer;
        private readonly List<Cards> _hand;
        private bool _quarantine;

        public Player(Dealer dealer)
        {
            _dealer = dealer;
            _hand = new List<Cards>();
            _quarantine = false;
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
                if (card.ToString().Equals("Joker"))
                {
                    heart++;
                    spade++;
                    diamond++;
                    club++;
                }

                if (card.ToString().StartsWith("Heart")) heart++;
                if (card.ToString().StartsWith("Spade")) spade++;
                if (card.ToString().StartsWith("Diamond")) diamond++;
                if (card.ToString().StartsWith("Club")) club++;
            }

            if (heart >= 4) return true;
            if (spade >= 4) return true;
            if (diamond >= 4) return true;
            return club >= 4;
        }


        public void Quarantine()
        {
            _quarantine = true;
        }

        public bool AddCardToHand(IPlayer player)
        {
            if (_quarantine)
            {
                Console.WriteLine("you are in quarantine");
                _quarantine = false;
                return false;
            }
            // ReSharper disable once RedundantIfElseBlock
            else
            {
                var card = _dealer.DrawCard();
                var go = _dealer.SeeIfSpecialCard(player, card);
                if (!go)
                {
                    _hand.Add(card);
                }

                return true;
            }
        }

        public void AddNonSpecialCardToHand()
        {
            if (!_quarantine)
            {
                _hand.Add(_dealer.DrawNonSpecialCard());
            }
            else
            {
                Console.WriteLine("you are in quarantine");
                _quarantine = false;
            }
        }

        public void RemoveCardFromHand()
        {
            var card = _hand[0];
            _hand.Remove(card);
            _dealer.DiscardCard(card);
        }

        public void RemoveAllCardFromHand()
        {
            foreach (var card in _hand)
            {
                _dealer.DiscardCard(card);
            }

            _hand.Clear();
        }
    }
}