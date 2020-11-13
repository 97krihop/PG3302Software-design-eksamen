using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pg3302_Eksamen
{
    public class Player : IPlayer
    {
        private readonly IDealer _dealer;
        private readonly List<Cards> _hand;
        private bool _quarantine;

        public Player(IDealer dealer)
        {
            _dealer = dealer;
            _hand = Factory.GenerateListCards();
        }

        public void ShowHand()
        {
           StandardMessage.HandMassage(_hand);
        }

        private Dictionary<string, int> CalcPoints(bool countWithJoker)
        {
            var suite = Factory.GenerateDictionary();
            suite.Add("Heart", 0);
            suite.Add("Spade", 0);
            suite.Add("Diamond", 0);
            suite.Add("Club", 0);

            foreach (var card in _hand)
            {
                if (SpecialCards.EqualJoker(card) && countWithJoker)
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
            var suite = CalcPoints(true);
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
            if (SpecialCards.SeeIfSpecialCard(player, card)) _hand.Add(card);
            return true;
        }

        public void AddNonSpecialCardToHand(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                if (_quarantine)
                {
                    Console.WriteLine("you are in quarantine");
                    _quarantine = false;
                    return;
                }

                _hand.Add(_dealer.DrawNonSpecialCard());
            }
        }

        public void RemoveCardFromHand()
        {
            var remove = CalculateCard(CalcPoints(false));
            if (remove == null) throw new NullReferenceException();
            _hand.Remove((Cards) remove);
            _dealer.DiscardCard((Cards) remove);
        }

        

        private Cards? CalculateCard(Dictionary<string, int> suite)
        {
            var lowest = 100;
            var cardSuite = "";
            foreach (var (key, value) in suite)
            {
                if (value >= lowest || value == 0) continue;
                lowest = value;
                cardSuite = key;
            }

            Cards? result = null;
            foreach (var card in _hand.Where(card => 
                card.ToString().StartsWith(cardSuite) && 
                !SpecialCards.EqualJoker(card)))
                result = card;
            return result;
        }

        public void RemoveAllCardFromHand()
        {
            foreach (var card in _hand) _dealer.DiscardCard(card);
            _hand.Clear();
        }
    }
}