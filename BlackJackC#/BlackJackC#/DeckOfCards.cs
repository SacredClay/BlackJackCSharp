using System.Text;

namespace BlackJackC_;

public class DeckOfCards : IDeck
{
    private List<PlayingCard> deck = new List<PlayingCard>();

    public int Count {  get; private set; }

    public DeckOfCards()
    {
        initialize();
    }

    public void initialize()
    {
        deck.Clear();
        foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
        {
            foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
            {
                if (value >= CardValue.Two && value <= CardValue.Ace)
                {
                    string rank = value.ToString(); // Convert enum value to string (e.g., "Ace", "King", ...)
                    PlayingCard card = new PlayingCard(suit, rank, value);
                    addCardToDeck(card);
                }
            }
        }
    }

    private void addCardToDeck(PlayingCard card)
    {
        deck.Add(card);
        Count++;
        //Console.WriteLine($"Added card: {card} count is at {this.Count}");
    }

    public PlayingCard dealCard()
    {
        if (deck.Count == 0)
        {
            throw new InvalidOperationException("UH OH, OUR DECK IS EMPTY!");
        }

        Random random = new Random();
        int index = random.Next(deck.Count);
        PlayingCard card = deck.ElementAt(index);
        deck.RemoveAt(index);
        this.Count--;
        return card;
    }

    public override String ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"This deck has {this.Count} cards!\n");

        foreach (PlayingCard card in deck)
        {
           sb.Append(card.ToString() + "\n");
        }

       return sb.ToString();
    }
}
