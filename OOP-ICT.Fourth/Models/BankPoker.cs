using OOP_ICT.Second.Tools;
using OOP_ICT.Third.Models;

namespace OOP_ICT.Fourth.Models
{
    public class BankPoker : Bank
    {
        private int _uniqueId = 1;
        private Dictionary<int, double> _bankByAmount = new ();

        public int CreateAccount()
        {
            _bankByAmount.Add(_uniqueId, 0);
            var temp = _uniqueId;
            _uniqueId++;
            return temp;
        }

        public int CreateAccount(double money)
        {
            _bankByAmount.Add(_uniqueId, money);
            var temp = _uniqueId;
            _uniqueId++;
            return temp;
        }

        public override void AddMoney(double money, int id)
        {
            if (money < 0)
            {
                throw new SecondException($"Wrong amount deposit - {money}, deposit should be positive!");
            }
            _bankByAmount[id] += money;
        }

        public override void WithdrawMoney(double money, int id)
        {
            if (money < 0)
            {
                throw new SecondException($"Wrong amount withdraw - {money}, withdraw should be positive!");
            }

            if (_bankByAmount[id] - money < 0)
            {
                throw new SecondException($"Wrong amount withdraw - {money}, withdraw should be less, than balance - {_bankByAmount[id]}!");
            }
            _bankByAmount[id] -= money;
        }

        public override void PlaceBet(int bet, int id)
        {
            if (_bankByAmount[id] - bet < 0)
            {
                throw new SecondException($"Not enough balance - {_bankByAmount[id]}, when bet is - {bet}");
            }
            _bankByAmount[id] -= bet;
        }

        public double GetBalance(int id)
        {
            return _bankByAmount[id];
        }

        public void GetWin(int money, int id)
        {
            _bankByAmount[id] += money;
        }
    }
}