using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    public class Dealer : IDealer
    {
        private readonly List<Cards> _stack =  new List<Cards>();
        private readonly List<Cards> _discardedCards =  new List<Cards>();
        private readonly Random _randomNumber;

        public Dealer()
        {
            _randomNumber = new Random();
            for (var i = 0; i < 52; i++) _stack.Add((Cards) i);
            Console.WriteLine("added card to stack");
        }

        private Cards GetCard()
        {
            while (true)
            {
                var i = _randomNumber.Next(1, 52);
                if (!_stack.Contains((Cards) i)) continue;
                return (Cards) i;
            }
        }

        public Cards DrawCard()
        {
            if (_stack.Count <= 4) ReShuffleDiscardedCards();
            var card = GetCard();
            _stack.Remove(card);
            return card;
        }

        public void DrawSpecialCards()
        {
            //Bomb = _specialCards[0]
            //Vulture = _specialCards[1]
            //SetQuarantine = _specialCards[2]
            //Joker = _specialCards[3]
            for (var i = 0; i < 4; i++)
            {
                while (true)
                {
                    var card = GetCard();
                    if (SpecialCards.GetSpecialCards().Contains(card)) continue;
                    SpecialCards.SetCard(card);
                    Console.WriteLine($"special{i + 1} cards: {card}");
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
                var card = GetCard();
                if (SpecialCards.GetSpecialCards().Contains(card)) continue;
                _stack.Remove(card);
                return card;
            }
        }
    }
}