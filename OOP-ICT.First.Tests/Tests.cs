using Xunit;
using Xunit.Sdk;
using System.Collections.Generic;
using System.Linq;
using OOP_ICT.Models;
using OOP_ICT.Tools;
using OOP_ICT.Interfaces;

namespace OOP_ICT.Dealer.Tests;

public class Tests
{
    private CardDeck _testedDeck = new CardDeck();

    [Fact]
    public void CheckFirstCards()
    {
        _testedDeck.FillDeck();
        var fCard = new Card(CardValues.Ace, CardSuits.Hearts, 1);
        var firstCard = _testedDeck.GetFirstCard();
        Assert.Equal(fCard, firstCard);
    }   

    [Fact]
    public void CheckLastCards()
    {
        _testedDeck.FillDeck();
        var lCard = new Card(CardValues.Two, CardSuits.Spades, 52);
        var lastCard = _testedDeck.GetLastCard();
        Assert.Equal(lCard, lastCard);
    }  

    [Fact]
    public void CheckShuffledDeck()
    {
        _testedDeck.FillDeck();
        var lCard = _testedDeck.GetLastCard();
        _testedDeck = _testedDeck.ShuffleDeck();
        var lastCard = _testedDeck.GetLastCard();
        Assert.NotEqual(lCard, lastCard);
    }  

    [Fact]
    public void CheckDeleteWork()
    {
        _testedDeck.FillDeck();
        var lCard = _testedDeck.GetLastCard();
        _testedDeck.DeleteLastCard();
        var lastCard = _testedDeck.GetLastCard();
        Assert.NotEqual(lCard, lastCard);
    }  

    [Fact]
    public void CheckHandsOnStart()
    {
        var dealer = new Models.Dealer();
        dealer.AddPlayerAtTable();
        dealer.InitializeCardDeck();
        dealer.ShuffleDeckAtDealer();
        dealer.InitiateGameStart();
        Assert.NotEqual(dealer.GetDealerHandTest(), dealer.GetPlayerHandTest(1));
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