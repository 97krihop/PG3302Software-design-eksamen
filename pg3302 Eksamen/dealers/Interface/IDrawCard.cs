using pg3302_Eksamen.Cards;

namespace pg3302_Eksamen.dealers.Interface
{
    public interface IDrawCard
    {
        Card DrawCard();
        Card DrawSpecialCards();
    }
}