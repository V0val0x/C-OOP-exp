using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models;

public class ComboEvaluator
{
    public HandRank EvaluateHand(List<Card> hand)
    {
        if (IsRoyalFlush(hand))
        {
            return HandRank.RoyalFlush;
        }
        if (IsStraightFlush(hand))
        {
            return HandRank.StraightFlush;
        }
        if (IsFourOfAKind(hand))
        {
            return HandRank.FourOfAKind;
        }
        if (IsFullHouse(hand))
        {
            return HandRank.FullHouse;
        }
        if (IsFlush(hand))
        {
            return HandRank.Flush;
        }
        if (IsStraight(hand))
        {
            return HandRank.Straight;
        }
        if (IsThreeOfAKind(hand))
        {
            return HandRank.ThreeOfAKind;
        }
        if (IsTwoPairs(hand))
        {
            return HandRank.TwoPairs;
        }
        if (IsOnePair(hand))
        {
            return HandRank.OnePair;
        }
        
        return HandRank.HighCard;
    }

    private bool IsRoyalFlush(List<Card> hand)
    {
        return IsStraightFlush(hand) && hand.Any(card => card.GetValue() == CardValues.Ace);
    }

    private bool IsStraightFlush(List<Card> hand)
    {
        return IsFlush(hand) && IsStraight(hand);
    }

    private bool IsFourOfAKind(List<Card> hand)
    {
        Dictionary<CardValues, int> valueCounts = GetValueCounts(hand);
        return valueCounts.Any(pair => pair.Value == 4);
    }

    private bool IsFullHouse(List<Card> hand)
    {
        Dictionary<CardValues, int> valueCounts = GetValueCounts(hand);
        return valueCounts.Any(pair => pair.Value == 3) && valueCounts.Any(pair => pair.Value == 2);
    }

    private bool IsFlush(List<Card> hand)
    {
        CardSuits suit = hand[0].GetSuit();
        return hand.All(card => card.GetSuit() == suit);
    }

    private bool IsStraight(List<Card> hand)
    {
        List<int> values = hand.Select(card => (int)card.GetValue()).ToList();
        values.Sort();

        for (int i = 1; i < values.Count; i++)
        {
            if (values[i] - values[i - 1] != 1)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsThreeOfAKind(List<Card> hand)
    {
        Dictionary<CardValues, int> valueCounts = GetValueCounts(hand);
        return valueCounts.Any(pair => pair.Value == 3);
    }

    private bool IsTwoPairs(List<Card> hand)
    {
        Dictionary<CardValues, int> valueCounts = GetValueCounts(hand);
        int pairCount = valueCounts.Count(pair => pair.Value == 2);
        return pairCount == 2;
    }

    private bool IsOnePair(List<Card> hand)
    {
        Dictionary<CardValues, int> valueCounts = GetValueCounts(hand);
        return valueCounts.Any(pair => pair.Value == 2);
    }

    private Dictionary<CardValues, int> GetValueCounts(List<Card> hand)
    {
        Dictionary<CardValues, int> valueCounts = new Dictionary<CardValues, int>();

        foreach (Card card in hand)
        {
            if (valueCounts.ContainsKey(card.GetValue()))
            {
                valueCounts[card.GetValue()]++;
            }
            else
            {
                valueCounts[card.GetValue()] = 1;
            }
        }

        return valueCounts;
    }
}