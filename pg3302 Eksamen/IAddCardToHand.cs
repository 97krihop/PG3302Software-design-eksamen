namespace pg3302_Eksamen
{
    public interface IAddCardToHand
    {
        bool AddCardToHand(IPlayer player);
        void AddNonSpecialCardToHand(int amount);
    }
}