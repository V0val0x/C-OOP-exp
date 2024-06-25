using OOP_ICT.Tools;

namespace OOP_ICT.Models;

/// <summary>
/// Class PlayerHand implements hand for each player in game, including dealer. 
/// </summary>
public class PlayerHand
{
    protected readonly List<Card> Hand = new List<Card>();

    /// <summary>
    /// Method AddCard adding card, given by a dealer, to the hand.
    /// </summary>
    /// <param name="card"></param>
    public void AddCard(Card card)
    {
        if (ReferenceEquals(card, null))
        {
            throw new FirstException($"Invalid card data - {card}");
        }
        Hand.Add(card);
    }
    
    /// <summary>
    /// Method CleanHand emptying hand of a player.
    /// </summary>
    public void CleanHand()
    {
        Hand.Clear();
    }

    public List<Card> GetHand()
    {
        return Hand;
    }

    public bool IsBlackJack()
    {
        return Hand.Count == 2 && (Hand[0].GetValue() == CardValues.Ace && (Hand[1].GetValue() == CardValues.King ||
                                                                            Hand[1].GetValue() ==  CardValues.Queen ||  Hand[1].GetValue() ==  CardValues.Jack)) || (Hand[1].GetValue() == CardValues.Ace && (Hand[0].GetValue() == CardValues.King ||
            Hand[0].GetValue() ==  CardValues.Queen ||  Hand[0].GetValue() ==  CardValues.Jack));
    }

    public void DeleteCardAt(int index)
    {
        Hand.RemoveAt(index);
    }

}