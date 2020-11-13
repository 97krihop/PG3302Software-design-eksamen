namespace pg3302_Eksamen
{
    public interface IPlayer
    {
        void ShowHand();
        bool SeeIfWins();
        void Quarantine();
        bool AddCardToHand(IPlayer player);
        void AddNonSpecialCardToHand(int amount);
        void RemoveCardFromHand();
        void RemoveAllCardFromHand();
    }
}