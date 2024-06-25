using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using OOP_ICT.Models;
using OOP_ICT.Tools;
using OOP_ICT.Interfaces;
using OOP_ICT.Second.Tools;


namespace OOP_ICT.Second.Models;

public class Player : PlayerHand
{
    private string name;
    private double balance;
    protected int bet = 0;
    public int id;
    
    public Player(string name, int balance)
    {
        this.name = name;
        if (balance <= 0)
        {
            throw new SecondException($"Invalid balance - {balance}");
        }
        else
        {
            this.balance = balance;
        }
    }

    public Player(string name)
    {
        this.name = name;
    }

    public void PlaceBet(int betIn)
    {
        balance -= betIn;
        bet = betIn;
    }

    public string GetName()
    {
        return name;
    }

    public void WatchHand()
    {
        foreach (var card in Hand)
        {
            Console.WriteLine(card);
        }
    }

    public List<Card> GetHand()
    {
        return Hand;
    }
    
    public CardValues[] GetValues()
    {
        CardValues[] cards = new CardValues[Hand.Count];
        int i = 0;
        foreach (var card in Hand)
        {
            cards[i] = card.GetValue();
            i++;
        }

        return cards;
    }

    public void GameWin()
    {
        balance += bet * 2;
        bet = 0;
        Hand.Clear();
    }

    public void GameLose()
    {
        bet = 0;
        Hand.Clear();
    }

    public void GameWinBlack()
    {
        balance += bet * 2.5;
        bet = 0;
        Hand.Clear();
    }

    public void GameDraw()
    {
        balance += bet;
        bet = 0;
        Hand.Clear();
    }

    public double GetBalance()
    {
        return balance;
    }

    public string ToStringTest()
    {
        return $"{name} {balance}";
    }

    public void DepositBalance(double money)
    {
        if (money < 0)
        {
            throw new SecondException($"Wrong amount deposit - {money}, deposit should be positive!");
        }
        balance += money;
    }

    public void WithdrawBalance(double money)
    {
        if (money < 0)
        {
            throw new SecondException($"Wrong amount withdraw - {money}, withdraw should be positive!");
        }

        if (balance - money < 0)
        {
            throw new SecondException($"Wrong amount withdraw - {money}, withdraw should be less, than balance - {balance}!");
        }
        balance -= money;
    }
    
}