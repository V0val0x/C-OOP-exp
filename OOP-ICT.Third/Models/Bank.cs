using System.Collections.Generic;
using System.Linq;
using OOP_ICT.Models;
using OOP_ICT.Tools;
using OOP_ICT.Interfaces;
using OOP_ICT.Second.Models;
using OOP_ICT.Second.Tools;

namespace OOP_ICT.Third.Models;

public abstract class Bank
{
    public abstract void AddMoney(double money, int id);

    public abstract void WithdrawMoney(double money, int id);

    public abstract void PlaceBet(int bet, int id);
}
