
namespace BlackJackC_;

public class ScoreablePlayerHand : PlayerHand
{
    public int Score { get; private set; }

    public ScoreablePlayerHand(String playerName) : base(playerName)
    {
        Score = 0;
    }

    public override void AddCardToHand(ICard card)
    {
        Cards.Add(card);
        UpdateScore();
        HandCount++; //Fix this, a handcount should be private setter on Playerhand
    }

    private void UpdateScore()
    {
        Score = Cards.Sum(card => (int) card.Value);
    }
}
