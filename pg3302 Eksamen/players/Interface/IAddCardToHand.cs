namespace pg3302_Eksamen.players.Interface
{
    public interface IAddCardToHand
    {
        bool AddCardToHand(IPlayer player);
        void AddNonSpecialCardToHand(int amount);
    }
}