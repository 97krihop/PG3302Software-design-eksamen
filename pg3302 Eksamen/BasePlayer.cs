using System;
using System.Collections.Generic;

namespace pg3302_Eksamen
{
    public abstract class BasePlayer : IPlayer
    {
        //vi har bare 1 underclass men vi viser til at vi vet hvordan en abstract classe skal se ut 
        protected IDealer Dealer;
        protected readonly List<Cards> Hand;
        protected bool Quarantine;

        protected BasePlayer(IDealer dealer)
        {
            Dealer = dealer;
            Hand = new List<Cards>();
        }

        public void ShowHand() => StandardMessage.HandMassage(Hand);


        public abstract bool SeeIfWins();
        public abstract void SetQuarantine();

        public bool AddCardToHand(IPlayer player)
        {
            if (Quarantine)
            {
                Console.WriteLine("you are in quarantine");
                Quarantine = false;
                return false;
            }

            var card = Dealer.DrawCard();
            if (SpecialCards.SeeIfSpecialCard(player, card)) Hand.Add(card);
            StandardMessage.DrawMassage(card);
            return !SpecialCards.EqualBomb(card);
        }

        public void AddNonSpecialCardToHand(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                if (Quarantine)
                {
                    Console.WriteLine("you are in quarantine");
                    Quarantine = false;
                    return;
                }

                var card = Dealer.DrawNonSpecialCard();
                Hand.Add(card);
                StandardMessage.DrawMassage(card);
            }
        }

        public abstract void RemoveCardFromHand();

        public void RemoveAllCardFromHand()
        {
            foreach (var card in Hand) Dealer.DiscardCard(card);
            Hand.Clear();
        }
    }
}