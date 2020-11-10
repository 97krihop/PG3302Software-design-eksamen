using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    internal class Player
    {
        private readonly List<Cards> _hand;

        public Player()
        {
            _hand = new List<Cards>();
        }

        public void ShowHand()
        {
            foreach (var card in _hand)
            {
                Console.WriteLine(card.ToString());
            }
        }
        public void AddCardToHand(Cards drawCard)
        {
            _hand.Add(drawCard);    
        }
    }
}