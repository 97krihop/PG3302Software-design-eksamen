using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    internal class Dealer
    {
        private readonly List<Cards> _stack;
        private readonly List<Cards> _discardedCards;
        private readonly Random _randomNumber;

        public Dealer()
        {
            _stack = new List<Cards>();
            _discardedCards = new List<Cards>();
            _randomNumber = new Random();
            for (var i = 0; i < 52; i++)
            {
                _stack.Add((Cards) i);
            }

            Console.WriteLine("added card to stack");
        }

        public Cards DrawCard()
        {
            if (_stack.Count <= 4) ReShuffleDiscardedCards();
            while (true)
            {
                var cardNumber = _randomNumber.Next(0, 52);
                if (!_stack.Contains((Cards) cardNumber)) continue;
                _stack.Remove((Cards) cardNumber);
                return (Cards) cardNumber;
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
    }
}