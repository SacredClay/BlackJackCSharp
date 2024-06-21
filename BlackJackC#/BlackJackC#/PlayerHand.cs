using System.Text;

namespace BlackJackC_;

public class PlayerHand : IPlayerHand
{
    public List<ICard> Cards { get; private set; }

    public String PlayerName { get; private set; }

    public int HandCount { get; set; }

    public PlayerHand(String playerName)
    {
        Cards = [];
        this.PlayerName = playerName;
    }

    public virtual void AddCardToHand(ICard card)
    {
        Cards.Add(card);
        HandCount++;
    }

    public bool RemoveCardFromHand(ICard card)
    {
        if (Cards.Remove(card))
        {
            HandCount--;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{this.PlayerName}'s hand contains:\n");

        foreach (ICard card in Cards) 
        {
            sb.Append(card.ToString() + "\n");
        }

        return sb.ToString();
    }
}
