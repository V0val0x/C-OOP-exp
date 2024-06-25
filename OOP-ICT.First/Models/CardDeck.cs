namespace OOP_ICT.Models;

/// <summary>
///  Creating class deck, which contains 52 cards of each suit in order from aces up to the number two.
/// Creating default builder for class Deck to put cards in deck in the right order.
/// </summary>
public class CardDeck
{
    private readonly List<Card> _cards = new List<Card>();

    public void FillDeck()
    {
        var k = 1;
        for (var i = CardValues.Ace; i <= CardValues.Two; i++)
        {
            for (var j = CardSuits.Hearts; j <= CardSuits.Spades; j++)
            {
                var card = new Card(i, j, k);
                _cards.Add(card);
                k++;
            }
        }
    }

    /// <summary>
    /// ShuffleDeck - shuffling deck in random order.
    /// </summary>
    /// <returns></returns>
    public CardDeck ShuffleDeck()
    {
        var random = new Random();
        var newShuffledDeck = new CardDeck();
        var deckCount = _cards.Count;
        for(var i = 0; i < deckCount; i++)
        {
            var randomElementInDeck = random.Next(0, _cards.Count);
            newShuffledDeck.Add(_cards[randomElementInDeck]);
            _cards.Remove(_cards[randomElementInDeck]);
        }
        return newShuffledDeck;
    }

    /// <summary>
    /// Add - adding card to deck.
    /// </summary>
    /// <param name="card"></param>
    private void Add(Card card)
    {
        _cards.Add(card);
    }
    
    /// <summary>
    /// GetLastCard - return last card in deck.
    /// </summary>
    /// <returns></returns>
    public Card GetLastCard()
    {
        if (_cards.Count == 0)
        {
            return null;
        }
        var lastCard = _cards.Last();
        _cards.Remove(lastCard);
        return lastCard;
    }

    /// <summary>
    /// GetFirstCard - return first card in deck.
    /// </summary>
    /// <returns></returns>
    public Card GetFirstCard()
    {
        if (_cards.Count == 0)
        {
            return null;
        }
        var firstCard = _cards.First();
        _cards.Remove(firstCard);
        return firstCard;
    }

    /// <summary>
    /// DeleteLastCard - delete last card in deck.
    /// </summary>
    public void DeleteLastCard()
    {
        if (_cards.Count > 0)
        {
            _cards.RemoveAt(_cards.Count - 1);
        }
    }
}