namespace pg3302_Eksamen
{
    public interface IPayer
    {
        public void ShowHand();

        public bool SeeIfWins();
        
        public void AddCardToHand();
        
        public void RemoveCardFromHand();
    }
}