namespace BlackJackC_;

public interface ICard
{
    CardSuit Suit { get; }

    String Rank { get; }

    CardValue Value { get; }

}
