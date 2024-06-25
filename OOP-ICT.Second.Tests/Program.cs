using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using Xunit;
using Xunit.Abstractions;

namespace OOP_ICT.Second.Tests;

public class Tests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private DealerOnTable _dealer = new DealerOnTable();

    public Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }


    [Fact]
    public void CheckPlayers()
    {
        _dealer.AddPlayer("Vova", 100);
        _dealer.AddPlayer("Anton", 500);
        _dealer.AddPlayer("Petya", 10);
        _dealer.DeletePlayerByName("Vova");
        var check = "Anton 500Petya 10";
        Assert.Equal(_dealer.PlayersTest(), check);
    } 
    
    [Fact]
    public void CheckBalanceWork()
    {
        _dealer.AddPlayer("Anton", 500);
        _dealer.AddPlayer("Anton", 500);
        _dealer.TestWin();
        _testOutputHelper.WriteLine(_dealer.PlayersTest());
        Assert.NotEqual(_dealer.GetPlayerTest(0), _dealer.GetPlayerTest(1));
    }   

    [Fact]
    public void CheckCardsCount()
    {
        _dealer.AddPlayer("Anton", 500);
        Card card = new Card(CardValues.Ace, CardSuits.Clubs , 1);
        Card card1 = new Card(CardValues.Ace, CardSuits.Diamonds, 2);
        _dealer.AddCustomCardTest(card);
        _dealer.AddCustomCardTest(card1);
        Card card2 = new Card(CardValues.King, CardSuits.Clubs , 3);
        Card card3 = new Card(CardValues.Queen, CardSuits.Diamonds, 4);
        _dealer.AddDealerCustomCard(card2);
        _dealer.AddDealerCustomCard(card3);
        int diff = -7;
        Assert.Equal(_dealer.CalculateDiffTest(), diff);
    }  
    
    [Fact]
    public void CheckCardsCount2()
    {
        _dealer.AddPlayer("Anton", 500);
        Card card = new Card(CardValues.Ace, CardSuits.Clubs , 1);
        Card card1 = new Card(CardValues.Ace, CardSuits.Diamonds, 2);
        _dealer.AddCustomCardTest(card);
        _dealer.AddCustomCardTest(card1);
        Card card2 = new Card(CardValues.King, CardSuits.Clubs , 3);
        Card card3 = new Card(CardValues.Three, CardSuits.Diamonds, 4);
        _dealer.AddDealerCustomCard(card2);
        _dealer.AddDealerCustomCard(card3);
        int diff = 0;
        Assert.Equal(_dealer.CalculateDiffTest(), diff);
    }
    
    [Fact]
    public void CheckGame1()
    {
        _dealer.AddPlayer("Anton", 500);
        Card card = new Card(CardValues.Ace, CardSuits.Clubs , 1);
        Card card1 = new Card(CardValues.Eight, CardSuits.Diamonds, 2);
        _dealer.AddCustomCardTest(card);
        _dealer.AddCustomCardTest(card1);
        Card card2 = new Card(CardValues.King, CardSuits.Clubs , 3);
        Card card3 = new Card(CardValues.Three, CardSuits.Diamonds, 4);
        _dealer.AddDealerCustomCard(card2);
        _dealer.AddDealerCustomCard(card3);
        _dealer.StartGame();
        Assert.Equal(510, _dealer.GetPlayerTest(0).GetBalance());
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