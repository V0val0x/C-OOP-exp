using OOP_ICT.Interfaces;

namespace OOP_ICT.Models;

/// <summary>
/// Class Dealer contains data about deck on table and data about each player hand, including dealers hand.
/// </summary>
public class Dealer : IDealer
{
    protected CardDeck _tableDeck = new CardDeck();
    protected readonly PlayerHand _dealerHand = new PlayerHand();
    private readonly List<PlayerHand> _players = new List<PlayerHand>();
    

    /// <summary>
    /// Method AddPlayerAtTable adds player to the current table.
    /// </summary>
    public void AddPlayerAtTable()
    {
        var newHand = new PlayerHand();
        _players.Add(newHand);
    }
    
    /// <summary>
    /// Method InitializeCardDeck makes deck for a table via CardDeck default builder
    /// </summary>
        public void InitializeCardDeck()
    {
        _tableDeck.FillDeck();
    }

    /// <summary>
    /// Method ShuffleDeckAtDealer marks deck as unpacked and shuffling it in random order.
    /// </summary>
    public void ShuffleDeckAtDealer()
    {
        _tableDeck = _tableDeck.ShuffleDeck();
    }

    /// <summary>
    /// Method InitiateGameStart starts game (currently BlackJack and only for 1 player)
    /// by playing default amount of cards.
    /// </summary>
    public void InitiateGameStart()
    {
        for (var i = 0; i < _players.Count; i++)
        {
            _players[i].AddCard(_tableDeck.GetLastCard());
            _tableDeck.DeleteLastCard();
        }
        _dealerHand.AddCard(_tableDeck.GetLastCard());
        _tableDeck.DeleteLastCard();
        for (var i = 0; i < _players.Count; i++)
        {
            _players[i].AddCard(_tableDeck.GetLastCard());
            _tableDeck.DeleteLastCard();
        }
        _dealerHand.AddCard(_tableDeck.GetLastCard());
        _tableDeck.DeleteLastCard();
    }

    public PlayerHand GetDealerHandTest()
    {
        return _dealerHand;
    }

    public PlayerHand GetPlayerHandTest(int id)
    {
        return _players[id - 1];
    }

    public CardDeck GetDeck()
    {
        return _tableDeck;
    }

    public void AddCardToDealer()
    {
        _dealerHand.AddCard(_tableDeck.GetLastCard());
        _tableDeck.DeleteLastCard();
    }

    public void AddCardToDealer(Card card)
    {
        _dealerHand.AddCard(card);
    }

    public void DeleteLastCard()
    {
        _tableDeck.DeleteLastCard();
    }

    public Card GetLastCard()
    {
        return _tableDeck.GetLastCard() ?? null;
    }
    
    public CardValues[] GetValues()
    {
        CardValues[] cards = new CardValues[_dealerHand.GetHand().Count];
        int i = 0;
        foreach (var card in _dealerHand.GetHand())
        {
            cards[i] = card.GetValue();
            i++;
        }

        return cards;
    }
    
    public void CleanHand()
    {
        _dealerHand.GetHand().Clear();
    }

    public void ClearTable()
    {
        while (_tableDeck.GetLastCard() != null)
        {
            _tableDeck.DeleteLastCard();
        }
    }
    
}
