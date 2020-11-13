namespace pg3302_Eksamen
{
    public interface IDiscardCard
    {
        void DiscardCard(Cards card);
        Cards DrawNonSpecialCard();
    }
}