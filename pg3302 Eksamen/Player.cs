using System;
using System.Collections.Generic;
using System.Linq;

namespace pg3302_Eksamen
{
    public class Player : IPlayer
    {
        private readonly Dealer _dealer;
        private readonly List<Cards> _hand = new List<Cards>();
        private bool _quarantine;

        public Player(Dealer dealer)
        {
            _dealer = dealer;
        }

        public void ShowHand()
        {
            foreach (var card in _hand) Console.WriteLine(card.ToString());
        }

        private Dictionary<string, int> Calc(bool countJoker)
        {
            var suite = new Dictionary<string, int> {{"Heart", 0}, {"Spade", 0}, {"Diamond", 0}, {"Club", 0}};

            foreach (var card in _hand)
            {
                if (card.ToString().Equals("Joker") && countJoker)
                {
                    suite["Heart"]++;
                    suite["Spade"]++;
                    suite["Diamond"]++;
                    suite["Club"]++;
                }

                if (card.ToString().StartsWith("Heart")) suite["Heart"]++;
                if (card.ToString().StartsWith("Spade")) suite["Spade"]++;
                if (card.ToString().StartsWith("Diamond")) suite["Diamond"]++;
                if (card.ToString().StartsWith("Club")) suite["Club"]++;
            }

            return suite;
        }


        public bool SeeIfWins()
        {
            var suite = Calc(true);
            if (suite["Heart"] >= 4) return true;
            if (suite["Spade"] >= 4) return true;
            if (suite["Diamond"] >= 4) return true;
            return suite["Club"] >= 4;
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

            var card = _dealer.DrawCard();
            var go = SpecialCards.SeeIfSpecialCard(player, card);
            if (!go) _hand.Add(card);
            return true;
        }

        public void AddNonSpecialCardToHand()
        {
            if (!_quarantine) _hand.Add(_dealer.DrawNonSpecialCard());
            else
            {
                Console.WriteLine("you are in quarantine");
                _quarantine = false;
            }
        }

        public void RemoveCardFromHand()
        {
            var dictionary = Calc(false);
            var lowest = 100;
            var cardSuite = "";

            foreach (var (key, value) in dictionary)
            {
                if (value >= lowest || value == 0) continue;
                lowest = value;
                cardSuite = key;
            }

            Cards? remove = null;

            foreach (var card in _hand.Where(card => card.ToString().StartsWith(cardSuite)))
                remove = card;


            if (remove == null) return;
            _hand.Remove((Cards) remove);
            _dealer.DiscardCard((Cards) remove);
        }

        public void RemoveAllCardFromHand()
        {
            foreach (var card in _hand) _dealer.DiscardCard(card);
            _hand.Clear();
        }
    }
}