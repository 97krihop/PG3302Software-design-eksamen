namespace pg3302_Eksamen
{
    public interface IPlayer
    {
        void ShowHand();
        bool SeeIfWins();
        void Quarantine();
        bool AddCardToHand(IPlayer player);
        void AddNonSpecialCardToHand();
        void RemoveCardFromHand();
        void RemoveAllCardFromHand();
    }
}