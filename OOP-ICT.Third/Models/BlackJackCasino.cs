using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using OOP_ICT.Models;
using OOP_ICT.Tools;
using OOP_ICT.Interfaces;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Third.Models;

public class BlackJackCasino
{
    private const int DealerMax = 17, HandMax = 21;

    public static void CountWinLose(Player hand, Dealer Dealer)
    {
        if (CardSum(Dealer) > HandMax)
        {
            if (CountBlackJack(hand))
            {
                hand.GameWinBlack();
            }
            else
            {
                hand.GameWin();
            }
        }
        else
        {
            if (CardSum(hand) > CardSum(Dealer) &&
                CardSum(hand) <= HandMax)
            {
                if (CountBlackJack(hand))
                {
                    hand.GameWinBlack();
                }
                else
                    hand.GameWin();
            }
            else if (CardSum(hand) == CardSum(Dealer) &&
                     CardSum(hand) <= HandMax)
            {
                hand.GameDraw();
            }
            else
            {
                hand.GameLose();
            }
        }
    }

    public static bool CountBlackJack(PlayerHand hand)
    {
        if (hand.IsBlackJack())
        {
            return true;
        }
        return false;
    }

    private static int CardSum(Player hand)
    {
        return CardCalculator.CalculateSum(hand.GetValues());
    }
    
    private static int CardSum(Dealer hand)
    {
        return CardCalculator.CalculateSum(hand.GetValues());
    }
}