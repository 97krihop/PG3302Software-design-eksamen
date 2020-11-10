using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    internal class Player
    {
        private readonly List<Cards> _hand;
        private readonly Random _cardNumber;

        public Player()
        {
            _hand = new List<Cards>();
            _cardNumber = new Random();
        }

        public void showHand()
        {
            foreach (var card in _hand)
            {
                Console.WriteLine(card.ToString());
            }
        }
        public void draw()
        {
            _hand.Add((Cards) _cardNumber.Next(0, 52));
        }
    }
}