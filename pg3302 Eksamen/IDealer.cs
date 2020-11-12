namespace pg3302_Eksamen
{
    public interface IDealer
    {
        Cards DrawCard();
        void DrawSpecialCard();
        void DiscardCard(Cards card);
        Cards DrawNonSpecialCard();
    }
}