using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    internal class Dealer
    {
        private readonly List<Cards> _stack;
        private readonly List<Cards> _specialCards;
        private readonly List<Cards> _discardedCards;
        private readonly Random _randomNumber;

        public Dealer()
        {
            _specialCards = new List<Cards>();

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
                var cardNumber = _randomNumber.Next(1, 52);
                if (!_stack.Contains((Cards) cardNumber)) continue;
                _stack.Remove((Cards) cardNumber);
                if (_specialCards[3].Equals((Cards) cardNumber))
                    cardNumber = 100;
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
                    if (!_stack.Contains((Cards) cardNumber) || _specialCards.Contains((Cards) cardNumber)) continue;
                    _specialCards.Add((Cards) cardNumber);
                    Console.WriteLine("special cards: " + (Cards) cardNumber);
                    break;
                }
            }
        }

        public bool SeeIfSpecialCard(IPlayer player, Cards card)
        {
            var number = 0;
            for (var i = 0; i < _specialCards.Count - 1; i++)
                if (card.Equals(_specialCards[i]))
                    number = i + 1;

            switch (number)
            {
                case 1:
                    Console.WriteLine("you drew Quarantine");
                    player.Quarantine();
                    return false;
                case 2:
                    Console.WriteLine("you drew vulture");
                    player.AddNonSpecialCardToHand();
                    return false;
                case 3:
                    Console.WriteLine("you drew bomb");
                    player.RemoveAllCardFromHand();
                    for (var i = 0; i < 4; i++) player.AddCardToHand(player);
                    return true;
            }
            return false;
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
                if (!_stack.Contains((Cards) cardNumber) || _specialCards.Contains((Cards) cardNumber)) continue;
                _stack.Remove((Cards) cardNumber);
                return (Cards) cardNumber;
            }
        }
    }
}