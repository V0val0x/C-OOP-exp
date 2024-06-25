using System.Collections;
using OOP_ICT.Tools;

namespace OOP_ICT.Models;

/// <summary>
///  Creating class card with its own value, suit and id, unique for each card in deck.
/// Creating builder for class Card with class validation, overrode ToString and GetHash methods.
/// </summary>
public class Card
{
    //public Card()
    private readonly int _id;
    private readonly CardValues _value;
    private readonly CardSuits _suit;
    public Card(CardValues value, CardSuits suit, int id)
    {
        if (id < 1)
        {
            throw new FirstException($"Invalid id, id - {id}");
        }
        _value = value;
        _suit = suit;
        _id = id;
    }
 
    public override string ToString()
    {
        return $"{_value} {_suit}";
    }
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Card other = (Card)obj;
        return _suit == other._suit && _value == other._value && _id == other._id;
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + _suit.GetHashCode();
            hash = hash * 23 + _value.GetHashCode();
            hash = hash * 23 + _id.GetHashCode();
            return hash;
        }
    }

    public CardValues GetValue()
    {
        return _value;
    }
    
    public CardSuits GetSuit()
    {
        return _suit;
    }
    
}