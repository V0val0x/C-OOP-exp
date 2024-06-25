using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using OOP_ICT.Second.Tools;
using OOP_ICT.Third.Models;
using Xunit;
using Xunit.Abstractions;

namespace OOP_ICT.Third.Tests;

public class Tests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private BankBj _bank = new BankBj();

    public Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }


    [Fact]
    public void CheckBankDeposit()
    {
        _bank.AddPlayer("Vova");
        _bank.AddMoney(150, 0);
        double check = 150.0;
        Assert.Equal(_bank.GetPlayerBalance(0), check);
    } 

    [Fact]
    public void CheckBankBet()
    {
        _bank.AddPlayer("Vova");
        _bank.AddMoney(150, 0);
        try
        {
            _bank.PlaceBet(200, 0);
            Assert.Fail();
        }
        catch (SecondException) { }
    } 

    [Fact]
    public void CheckBankWithdraw()
    {
        _bank.AddPlayer("Vova");
        _bank.AddMoney(150, 0);
        _bank.WithdrawMoney(60, 0);
        double check = 90.0;
        Assert.Equal(_bank.GetPlayerBalance(0), check);
    }

    [Fact]
    public void CheckCasinoLose()
    {
        _bank.AddPlayer("Vova");
        _bank.AddMoney(150, 0);
        _bank.PlaceBet(50, 0);
        Card card1 = new Card(CardValues.Ace, CardSuits.Clubs, 1);
        Card card2 = new Card(CardValues.Ace, CardSuits.Diamonds, 2);
        _bank.AddPlayerCustomCard(card1, 0);
        _bank.AddPlayerCustomCard(card2, 0);
        Card card3 = new Card(CardValues.Ace, CardSuits.Clubs, 3);
        Card card4 = new Card(CardValues.King, CardSuits.Diamonds, 4);
        _bank.AddDealerCustomCard(card3);
        _bank.AddDealerCustomCard(card4);
        _bank.Game();
        double check = 100.0;
        Assert.Equal(_bank.GetPlayerBalance(0), check);
    }

    [Fact]
    public void CheckCasinoWin()
    {
        _bank.AddPlayer("Vova");
        _bank.AddMoney(150, 0);
        _bank.PlaceBet(50, 0);
        Card card1 = new Card(CardValues.Jack, CardSuits.Hearts, 4);
        Card card2 = new Card(CardValues.Queen, CardSuits.Diamonds, 2);
        _bank.AddPlayerCustomCard(card1, 0);
        _bank.AddPlayerCustomCard(card2, 0);
        Card card3 = new Card(CardValues.Ace, CardSuits.Spades, 3);
        Card card4 = new Card(CardValues.Ace, CardSuits.Clubs, 1);
        _bank.AddDealerCustomCard(card3);
        _bank.AddDealerCustomCard(card4);
        _bank.Game();
        double check = 200.0;
        Assert.Equal(_bank.GetPlayerBalance(0), check);
    }

    [Fact]
    public void CheckCasinoBJ()
    {
        _bank.AddPlayer("Vova");
        _bank.AddMoney(150, 0);
        _bank.PlaceBet(100, 0);
        Card card1 = new Card(CardValues.Ace, CardSuits.Hearts, 4);
        Card card2 = new Card(CardValues.Queen, CardSuits.Diamonds, 2);
        _bank.AddPlayerCustomCard(card1, 0);
        _bank.AddPlayerCustomCard(card2, 0);
        Card card3 = new Card(CardValues.Ace, CardSuits.Spades, 3);
        Card card4 = new Card(CardValues.Ace, CardSuits.Clubs, 1);
        _bank.AddDealerCustomCard(card3);
        _bank.AddDealerCustomCard(card4);
        _bank.Game();
        double check = 300.0;
        Assert.Equal(_bank.GetPlayerBalance(0), check);
    }



    [Fact]
    public void CheckTestIsWorking_CorrectBuild()
    {
        Assert.True(true);
    }

    [Fact]
    public void CollectionsAreEquals_True()
    {
        var firstCollection = new List<int>(){1,2,3};
        var secondCollection = new List<int>(){1,2,3};
        Assert.Equal(firstCollection, secondCollection);
    }

    [Fact]
    public void ValueContainsInCollection_True()
    {
        var value = 2;
        var collection = new List<int>(){1,2,3};
        Assert.Contains(value, collection);
    }

    [Fact]
    public void CheckForNullException_AssertNullRef()
    {
        var collection = new List<string>() { "я", "люблю", "ооп" };
        Assert.Throws<InvalidOperationException>(() => collection.First(x => x == null));
    }
}