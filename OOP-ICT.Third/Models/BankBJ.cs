using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using OOP_ICT.Models;
using OOP_ICT.Tools;
using OOP_ICT.Interfaces;
using OOP_ICT.Second.Models;
using OOP_ICT.Second.Tools;

namespace OOP_ICT.Third.Models;

public class BankBj : Bank
{
    private DealerOnTable _ddealer = new DealerOnTable();

    public void AddPlayer(string name)
    {
        _ddealer.AddPlayer(name);
    }

    public override void AddMoney(double money, int id)
    {
        _ddealer.GetPlayerTest(id).DepositBalance(money);
    }

    public override void WithdrawMoney(double money, int id)
    {
        _ddealer.GetPlayerTest(id).WithdrawBalance(money);
    }

    public override void PlaceBet(int bet, int id)
    {
        if (_ddealer.GetPlayerTest(id).GetBalance() - bet < 0)
        {
            throw new SecondException($"Not enough balance - {_ddealer.GetPlayerTest(id).GetBalance()}, when bet is - {bet}");
        }
        _ddealer.GetPlayerTest(id).PlaceBet(bet);
    }

    public Player GetPlayer(int id)
    {
        return _ddealer.GetPlayerTest(id);
    }

    public DealerOnTable GetDealer()
    {
        return _ddealer;
    }

    public void AddPlayerCustomCard(Card card, int id)
    {
        _ddealer.AddCustomCardTest(card, id);
    }

    public void AddDealerCustomCard(Card card)
    {
        _ddealer.AddDealerCustomCard(card);
    }

    public double GetPlayerBalance(int id)
    {
        return _ddealer.GetPlayerTest(id).GetBalance();
    }

    public void Game()
    {
        BlackJackCasino.CountWinLose(_ddealer.GetPlayerTest(0), _ddealer.GetDealerTest());
    }

}