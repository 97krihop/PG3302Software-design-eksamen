namespace pg3302_Eksamen
{
    public interface IPlayer
    {
        public void ShowHand();

        public bool SeeIfWins();

        public bool AddCardToHand(IPlayer player);
        public void AddNonSpecialCardToHand();

        public void RemoveCardFromHand();
        public void RemoveAllCardFromHand();
        public void Quarantine();
    }
}