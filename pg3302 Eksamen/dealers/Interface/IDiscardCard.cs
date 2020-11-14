using pg3302_Eksamen.Cards;

namespace pg3302_Eksamen.dealers.Interface
{
    public interface IDiscardCard
    {
        void DiscardCard(Card card);
        Card DrawNonSpecialCard();
    }
}