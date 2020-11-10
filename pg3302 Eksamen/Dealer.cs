using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    internal class Dealer
    {
        private static List<Cards> _stack;
        private static Random _randomNumber;

        public Dealer()
        {
            _randomNumber = new Random();
            _stack = new List<Cards>();
            for (var i = 0; i < 52; i++)
            {
                _stack.Add((Cards) i);
            }

            Console.Write("added card to stack \n");
        }
        
        public  Cards DrawCard()
        {
            while (true)
            {
                
                var cardNumber = _randomNumber.Next(0, 52);
                if (!_stack.Contains((Cards) cardNumber)) continue;
                _stack.Remove((Cards) cardNumber);
                return (Cards) cardNumber;
            }
        }
    }
}