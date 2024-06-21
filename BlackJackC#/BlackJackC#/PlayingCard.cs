using BlackJackC_;

public class PlayingCard : ICard
{
    public CardSuit Suit { get; private set; }

    public String Rank { get; private set; }

    public CardValue Value { get; private set; }

    public PlayingCard(CardSuit suit, String rank, CardValue value)
    {
        this.Suit = suit;
        this.Rank = rank;
        this.Value = value;
    }

    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}
