using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    public class Dealer
    {
        private readonly List<Cards> _stack = new List<Cards>();
        private readonly List<Cards> _discardedCards = new List<Cards>();
        private readonly Random _randomNumber;

        public Dealer()
        {
            _randomNumber = new Random();
            for (var i = 0; i < 52; i++) _stack.Add((Cards) i);
            Console.WriteLine("added card to stack");
        }

        public Cards DrawCard()
        {
            if (_stack.Count <= 4) ReShuffleDiscardedCards();
            while (true)
            {
                var cardNumber = _randomNumber.Next(1, 52);
                if (!_stack.Contains((Cards) cardNumber)) continue;
                _stack.Remove((Cards) cardNumber);
                if (SpecialCards.EqualJoker((Cards) cardNumber)) cardNumber = 100;
                return (Cards) cardNumber;
            }
        }

        public void DrawSpecialCard()
        {
            //Bomb = _specialCards[0]
            //Vulture = _specialCards[1]
            //Quarantine = _specialCards[2]
            //Joker = _specialCards[3]
            for (var i = 0; i < 4; i++)
            {
                while (true)
                {
                    var cardNumber = _randomNumber.Next(1, 52);
                    if (!_stack.Contains((Cards) cardNumber) ||
                        SpecialCards.GetSpecialCards().Contains((Cards) cardNumber)) continue;
                    SpecialCards.SetCard((Cards) cardNumber);
                    Console.WriteLine("special cards: " + (Cards) cardNumber);
                    break;
                }
            }
        }

        private void ReShuffleDiscardedCards()
        {
            foreach (var card in _discardedCards) _stack.Add(card);
            _discardedCards.Clear();
        }

        public void DiscardCard(Cards card)
        {
            _discardedCards.Add(card);
        }

        public Cards DrawNonSpecialCard()
        {
            if (_stack.Count <= 4) ReShuffleDiscardedCards();
            while (true)
            {
                var cardNumber = _randomNumber.Next(1, 52);
                if (!_stack.Contains((Cards) cardNumber) ||
                    SpecialCards.GetSpecialCards().Contains((Cards) cardNumber)) continue;
                _stack.Remove((Cards) cardNumber);
                return (Cards) cardNumber;
            }
        }
    }
}