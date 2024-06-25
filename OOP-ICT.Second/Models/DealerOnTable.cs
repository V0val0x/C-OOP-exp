using System.Collections.Generic;
using System.Linq;
using OOP_ICT.Models;
using OOP_ICT.Tools;
using OOP_ICT.Interfaces;
using OOP_ICT.Second.Interface;
using OOP_ICT.Second.Tools;

namespace OOP_ICT.Second.Models;

public class DealerOnTable : IGame
{
    protected List<Player> PlayersOnTable = new List<Player>();
    protected Dealer Dealer = new Dealer();
    protected Card HiddenCard = null!;
    private const int DealerMax = 17, HandMax = 21;
    public void AddPlayer(string name, int balance)
    {
        Player player = new Player(name, balance);
        PlayersOnTable.Add(player);
    }

    public void AddPlayer(string name)
    {
        Player player = new Player(name);
        PlayersOnTable.Add(player);
    }

    public void DeletePlayerByName(string name)
    {
        foreach (var player in PlayersOnTable.Where(player => player.GetName() == name))
        {
            PlayersOnTable.Remove(player);
            break;
        }
    }

    public void StartGame()
    {
        Dealer.InitializeCardDeck();
        Dealer.ShuffleDeckAtDealer();
        foreach (var player in PlayersOnTable)
        {
            player.PlaceBet(10);
        }
        //GameStart();
        //DealersTurn();
        GameEnd();
        
    }
    
    /// <summary>
    /// Method GameStart starts game
    /// by playing default amount of cards.
    /// </summary>
    protected void GameStart()
    {
        foreach (var t in PlayersOnTable)
        {
            t.AddCard(Dealer.GetLastCard());
            Dealer.DeleteLastCard();
        }
        Dealer.AddCardToDealer();
        foreach (var t in PlayersOnTable)
        {
            t.AddCard(Dealer.GetLastCard());
            Dealer.DeleteLastCard();
        }
        HiddenCard = Dealer.GetLastCard();
        Dealer.DeleteLastCard();
    }

    public void GameEnd()
    {
        if(CardCalculator.CalculateSum(Dealer.GetValues()) > HandMax)
        {
            foreach (var player in PlayersOnTable)
            {
                player.GameWin();
            }
        }
        else
        {
            foreach (var player in PlayersOnTable)
            {
                if (CardCalculator.CalculateSum(player.GetValues()) > CardCalculator.CalculateSum(Dealer.GetValues()) &&
                    CardCalculator.CalculateSum(player.GetValues()) <= HandMax)
                {
                    player.GameWin();
                }
                else if (CardCalculator.CalculateSum(player.GetValues()) ==
                         CardCalculator.CalculateSum(Dealer.GetValues()) &&
                         CardCalculator.CalculateSum(player.GetValues()) <= HandMax)
                {
                    player.GameDraw();
                }
                else
                {
                    player.GameLose();
                }
            }
        }
        Dealer.CleanHand();
        ClearTable();
    }
    

    public void DealersTurn()
    {
        Dealer.AddCardToDealer(HiddenCard);
        while(CardCalculator.CalculateSum(Dealer.GetValues()) < DealerMax)
        {
            Dealer.AddCardToDealer(Dealer.GetLastCard());
            Console.WriteLine(Dealer.GetLastCard());
            Dealer.DeleteLastCard();
        }
    }


    public void ClearTable()
    {
        Dealer.ClearTable();
    }

    public string PlayersTest()
    {
        var res = PlayersOnTable.Aggregate("", (current, player) => current + player.ToStringTest());
        return res;
    }

    //Test segment

    public void TestWin()
    {
        PlayersOnTable[0].PlaceBet(50);
        PlayersOnTable[0].GameWin();
    }

    public Player GetPlayerTest(int ind)
    {
        return PlayersOnTable[ind];
    }

    public Dealer GetDealerTest()
    {
        return Dealer;
    }

    public void AddCustomCardTest(Card card, int id)
    {
        PlayersOnTable[id].AddCard(card);
    }
    
    public void AddCustomCardTest(Card card)
    {
        PlayersOnTable[0].AddCard(card);
    }

    public void AddDealerCustomCard(Card card)
    {
        Dealer.AddCardToDealer(card);
    }

    public int CalculateDiffTest()
    {
        return CardCalculator.CalculateSum(PlayersOnTable[0].GetValues()) - CardCalculator.CalculateSum(Dealer.GetValues());
    }
    
}