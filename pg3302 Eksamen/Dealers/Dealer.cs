using System;
using System.Collections.Generic;
using pg3302_Eksamen.Cards;
using pg3302_Eksamen.dealers.Interface;

namespace pg3302_Eksamen.Dealers
{
    public class Dealer : IDealer
    {
        private static readonly IDealer Instance = new Dealer();
        private readonly List<Card> _discardedCards = new List<Card>();
        private readonly Random _randomNumber;
        private readonly List<Card> _stack = new List<Card>();

        private Dealer()
        {
            _randomNumber = new Random();
            for (var i = 0; i < 52; i++) _stack.Add((Card) i);
            Console.WriteLine("added card to stack");
        }

        public Card DrawCard()
        {
            if (_stack.Count <= 4) ReShuffleDiscardedCards();
            var card = GetCard();
            _stack.Remove(card);
            return card;
        }

        public Card DrawNonSpecialCard()
        {
            if (_stack.Count <= 4) ReShuffleDiscardedCards();
            while (true)
            {
                var card = GetCard();
                if (SpecialCard.GetSpecialCards().Contains(card)) continue;
                _stack.Remove(card);
                return card;
            }
        }

        public Card DrawSpecialCards()
        {
            while (true)
            {
                var card = GetCard();
                if (SpecialCard.GetSpecialCards().Contains(card)) continue;
                return card;
            }
        }

        public void DiscardCard(Card card)
        {
            _discardedCards.Add(card);
        }

        public static IDealer GetInstance()
        {
            return Instance;
        }

        private Card GetCard()
        {
            while (true)
            {
                var i = _randomNumber.Next(1, 52);
                if (!_stack.Contains((Card) i)) continue;
                return (Card) i;
            }
        }

        private void ReShuffleDiscardedCards()
        {
            foreach (var card in _discardedCards) _stack.Add(card);
            _discardedCards.Clear();
        }
    }
}