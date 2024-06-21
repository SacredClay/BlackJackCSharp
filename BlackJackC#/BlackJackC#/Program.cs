namespace BlackJackC_;

public class Program
{
    static void Main(string[] args)
    {
        //PlayingCard card = new PlayingCard(CardSuit.Clubs, "9", CardValue.Nine);

        //Console.WriteLine(card);

        //DeckOfCards decky = new DeckOfCards();

        //Console.WriteLine(decky);

        //PlayerHand hand = new PlayerHand("Justin");

        //for (int i = 0; i < 10; i++)
        //{
        //    hand.AddCardToHand(decky.dealCard());
        //}

        //Console.WriteLine(hand);

        //Console.WriteLine(decky);

        BlackJack bj = new(4);

        bj.StartGame();
    }
}
