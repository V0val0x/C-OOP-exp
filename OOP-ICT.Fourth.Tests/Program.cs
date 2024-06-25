using OOP_ICT.Fourth.Models;
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
    private DealerPoker _dealer = new DealerPoker();

    public Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    

    [Fact]
    public void CheckPokerCombo()
    {
        _dealer.AddPlayer("Ivan");
        _dealer.AddMoney(100500, _dealer.GetPlayer(0).GetId());
        Card card1 = new Card(CardValues.Ten, CardSuits.Clubs, 1);
        Card card2 = new Card(CardValues.Jack, CardSuits.Clubs, 2);
        Card card3 = new Card(CardValues.Queen, CardSuits.Clubs, 3);
        Card card4 = new Card(CardValues.King, CardSuits.Clubs, 4);
        Card card5 = new Card(CardValues.Ace, CardSuits.Clubs, 5);
        _dealer.GetPlayer(0).AddCustomCard(card1);
        _dealer.GetPlayer(0).AddCustomCard(card2);
        _dealer.GetPlayer(0).AddCustomCard(card3);
        _dealer.GetPlayer(0).AddCustomCard(card4);
        _dealer.GetPlayer(0).AddCustomCard(card5);
        HandRank rank = HandRank.RoyalFlush;
        _dealer.CheckPlayerCombo(0);
        Assert.Equal(_dealer.GetPlayersCombo(0), rank);
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