using System.Collections.Generic;
using System.Linq;
using pg3302_Eksamen.Cards;

namespace pg3302_Eksamen.players
{
    public class Player : BasePlayer
    {
        private Dictionary<string, int> CalcPoints(bool countWithJoker)
        {
            var suite = new Dictionary<string, int> {{"Heart", 0}, {"Spade", 0}, {"Diamond", 0}, {"Club", 0}};

            foreach (var card in Hand)
                if (SpecialCards.EqualJoker(card))
                {
                    if (!countWithJoker) continue;
                    suite["Heart"]++;
                    suite["Spade"]++;
                    suite["Diamond"]++;
                    suite["Club"]++;
                }
                else
                {
                    if (card.ToString().StartsWith("Heart")) suite["Heart"]++;
                    if (card.ToString().StartsWith("Spade")) suite["Spade"]++;
                    if (card.ToString().StartsWith("Diamond")) suite["Diamond"]++;
                    if (card.ToString().StartsWith("Club")) suite["Club"]++;
                }

            return suite;
        }

        public override bool SeeIfWins()
        {
            var suite = CalcPoints(true);
            if (suite["Heart"] >= 4) return true;
            if (suite["Spade"] >= 4) return true;
            if (suite["Diamond"] >= 4) return true;
            return suite["Club"] >= 4;
        }

        public override void SetQuarantine()
        {
            Quarantine = true;
        }
        
        public override void RemoveCardFromHand()
        {
            var card = CalculateCard(CalcPoints(false));
            Hand.Remove(card);
            _Dealer.DiscardCard(card);
        }

        private Card CalculateCard(Dictionary<string, int> suite)
        {
            var lowest = 100;
            var cardSuite = "";
            foreach (var (key, value) in suite)
            {
                if (value >= lowest || value == 0) continue;
                lowest = value;
                cardSuite = key;
            }

            Card? result = null;
            foreach (var card in Hand.Where(card =>
                card.ToString().StartsWith(cardSuite) && !SpecialCards.EqualJoker(card)))
                result = card;
            result ??= Hand[0];
            return (Card) result;
        }
    }
}