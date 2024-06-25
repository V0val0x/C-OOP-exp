using OOP_ICT.Models;
using OOP_ICT.Tools;

namespace OOP_ICT.Interfaces;

/// <summary>
/// Interface of dealer implements all player communication with deck, cards, dealer, hand.
/// </summary>
public interface IDealer
{
    void AddPlayerAtTable();
    void InitializeCardDeck();
    void ShuffleDeckAtDealer();
    void InitiateGameStart();

}