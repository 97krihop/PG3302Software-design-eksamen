namespace pg3302_Eksamen
{
    public interface IDealer
    {
        Cards DrawCard();
        void DrawSpecialCards();
        void DiscardCard(Cards card);
        Cards DrawNonSpecialCard();
    }
}