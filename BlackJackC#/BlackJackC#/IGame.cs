namespace BlackJackC_;

public interface IGame
{
    //Figure out why I can't just make this a LinkedList of IPlayerhands
    public LinkedList<PlayerHand> Players { get; }

    //Same here
    //public IDeck Deck { get; }

    public void StartGame();

    public void PlayGame();
}
