using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models;

public class PlayerPoker : PlayerHand
{
    private ComboEvaluator combo = new ComboEvaluator();
    private string _name;
    private int _bankAccountId;
    private HandRank _handRank;
    private bool _inGame = true;

    public PlayerPoker(string name)
    {
        _name = name;
    }

    public PlayerPoker(string name, int id)
    {
        _name = name;
        _bankAccountId = id;
    }

    public void CreatePlayer(string name, int id)
    {
        _name = name;
        _bankAccountId = id;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetId()
    {
        return _bankAccountId;
    }

    public void AddCustomCard(Card card)
    {
        Hand.Add(card);
    }
    
    public void DeleteCustomCard(int id)
    {
        Hand.RemoveAt(id);
    }

    public void DropGame()
    {
        _inGame = false;
        Hand.Clear();
    }

    public bool IsIn()
    {
        return _inGame;
    }

    public void ComboEvaluate()
    {
        _handRank = combo.EvaluateHand(Hand);
    }

    public HandRank GetHandRank()
    {
        return _handRank;
    }

    public void EndGame()
    {
        Hand.Clear();
        _handRank = HandRank.HighCard;
    }

}

