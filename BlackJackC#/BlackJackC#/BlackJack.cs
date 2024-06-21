using System.Collections.ObjectModel;

namespace BlackJackC_;

public class BlackJack : IGame
{
    public DeckOfCards Deck { get; private set; }
    
    public LinkedList<PlayerHand> Players { get; set; }

    public PlayerHand TurnPlayer { get; private set; }

    private const int BLACKJACK_LIMIT = 21;

    private const int BLACKJACK_MUST_PLAY = 16;

    private const int FACE_CARDS = 10;

    public BlackJack(int amountOfPlayers) 
    {
        if (amountOfPlayers < 0)
        {
            throw new InvalidOperationException("Must enter at least 1 player");
        }

        Players = new LinkedList<PlayerHand>();

        for (int i = 0; i < amountOfPlayers; i++)
        {
            Players.AddLast(new PlayerHand($"Player {i}"));
        }

        TurnPlayer = Players.First();
    }

    public void StartGame()
    {
        Deck = new DeckOfCards();

        Console.Write("Starting hands:\n");

        //Fix this, it should be 1 card to all players first
        foreach (PlayerHand hand in Players)
        {
            hand.AddCardToHand(Deck.dealCard());
            hand.AddCardToHand(Deck.dealCard());

            Console.WriteLine(hand);
        }

        PlayGame();
    }

    public void PlayGame()
    {
        List<PlayerHand> winners = null;

        Dictionary<PlayerHand,int> scores = new Dictionary<PlayerHand,int>();

            foreach (PlayerHand player in Players)
            {
                while (calculateHand(player) <= BLACKJACK_MUST_PLAY )
                {
                    player.AddCardToHand(Deck.dealCard());
                    Console.WriteLine(player);
                }
                scores.Add(player, calculateHand(player));
            }

            scores = scores.Where(x => x.Value <= BLACKJACK_LIMIT).ToDictionary();

            if (scores.Count < 0)
            {
                throw new InvalidOperationException("UH OH NO WINNER!");
            }

        int maxScore = scores.Max(pair => pair.Value);

        winners = scores.Where(pair => pair.Value == maxScore).Select(pair => pair.Key).ToList();

        if (winners.Count > 1)
        {
            Console.WriteLine($"THE WINNERS WITH A SCORE OF {maxScore} ARE: ");
            foreach (PlayerHand player in winners)
            {
                Console.WriteLine(player.PlayerName);
            }
        }

        else
        {
            Console.WriteLine($"THE WINNER IS {winners.Single().PlayerName} WITH A HAND VALUE OF {calculateHand(winners.Single())}");

        }

    }

    private int calculateHand(PlayerHand hand)
    {
        if (hand == null || hand.HandCount == 0)
        {
            return 0;
        }

        int total = 0;
        int aceCount = 0;

        foreach(PlayingCard playingCard in hand.Cards)
        {
            if (playingCard.Value == CardValue.King || playingCard.Value == CardValue.Queen || playingCard.Value == CardValue.Jack)
            {
                total += FACE_CARDS;
            }

            else if (playingCard.Value == CardValue.Ace)
            {
                aceCount++;
                total += 11;
            }    

            else
            {
                total += (int) playingCard.Value;
            }
        }

        if (hand.HandCount == 2 && aceCount == 2)
        {
            return BLACKJACK_LIMIT;
        }

        if (total > 21)
        {
            total -= (aceCount * 10);
        }

        return total;
    }

}
