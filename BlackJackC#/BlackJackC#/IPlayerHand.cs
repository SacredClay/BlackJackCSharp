namespace BlackJackC_;

public interface IPlayerHand
{
    public List<ICard> Cards { get; }

    public String PlayerName { get;}

    public int HandCount { get;}

    public void AddCardToHand(ICard card);

    public bool RemoveCardFromHand(ICard card);
}
