using OOP_ICT.Fourth.Tools;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models
{
    public class DealerPoker
    {
        private BankPoker _bank = new BankPoker();
        private CardDeck _deck = new CardDeck();
        private List<PlayerPoker> _players = new List<PlayerPoker>();
        private List<PlayerPoker> _winners = new List<PlayerPoker>();
        private HandRank HighestRank = HandRank.HighCard;
        private int pot = 0;
        private int lastbet = 0;

        public void AddPlayer(string name)
        {
            var player = new PlayerPoker(name, _bank.CreateAccount());
            _players.Add(player);
        }

        public void AddPlayer(string name, double money)
        {
            var player = new PlayerPoker(name, _bank.CreateAccount(money));
            _players.Add(player);
        }

        public void StartGame()
        {
            _deck.FillDeck();
            _deck.ShuffleDeck();
            DealInitialCards();
            Bidding();
            CardMovement();
            Bidding();
            ShowDown();
            PayWinners();
            pot = 0;
            lastbet = 0;
            HighestRank = HandRank.HighCard;
            _winners.Clear();
            foreach (var player in _players)
            {
                player.EndGame();
            }
        }

        private void DealInitialCards()
        {
            for (var i = 0; i < 5; i++)
            {
                foreach (var player in _players)
                {
                    var card = _deck.GetLastCard();
                    player.AddCard(card);
                    _deck.DeleteLastCard();
                }
            }
        }

        private void Bidding()
        {
            foreach (var player in _players)
            {
                //Instead of making the console in/out rules are written here:
                //1-Bet
                //2-Rise
                //3-Check
                //4-Call
                //5-Fold
                var move = Convert.ToInt32(Console.ReadLine());
                if (player.IsIn())
                {
                    switch (move)
                    {
                        case 1 when pot == 0:
                        {
                            var bet = Convert.ToInt32(Console.ReadLine());
                            pot = bet;
                            lastbet = bet;
                            _bank.PlaceBet(bet, player.GetId());
                            break;
                        }
                        case 1:
                            throw new FourthException($"First bet was already made");
                        case 2:
                        {
                            var bet = Convert.ToInt32(Console.ReadLine());
                            if (bet <= lastbet)
                            {
                                throw new FourthException(
                                    $"Last bet was {lastbet}, you need to place a higher bet, than{bet}.");
                            }

                            lastbet = bet;
                            pot += bet;
                            _bank.PlaceBet(bet, player.GetId());
                            break;
                        }
                        case 3 when pot == 0:
                            player.DropGame();
                            break;
                        case 3:
                            throw new FourthException($"Unable to check, bets are made, you can only fold.");
                        case 4 when lastbet == 0:
                            throw new FourthException($"No bet made so far.");
                        case 4:
                            _bank.PlaceBet(lastbet, player.GetId());
                            pot += lastbet;
                            break;
                        case 5 when _players.Count > 1:
                            player.DropGame();
                            break;
                        default:
                            throw new FourthException($"Unknown command {move}, please write the correct move.");
                    }
                }
            }
        }

        private void CardMovement()
        { 
            foreach (var player in _players)
            {
                if (!player.IsIn()) continue;
                var cardtoDraw = Convert.ToInt32(Console.ReadLine());
                for (var i = 0; i < cardtoDraw; i++)
                {
                    var CardIndex = Convert.ToInt32(Console.ReadLine());
                    player.DeleteCardAt(CardIndex);
                }
            }
        }

        private void ShowDown()
        {
            if (_players.Count == 1)
            {
                _bank.AddMoney(pot, _players[0].GetId());
                pot = 0;
                _players[0].CleanHand();
            }
            else
            {
                CountCombo();
                FindHighestCombo();
                foreach (var player in _players)
                {
                    if (player.GetHandRank() == HighestRank)
                    {
                        _winners.Add(player);
                    }
                }
            }
        }

        private void CountCombo()
        {
            foreach (var player in _players.Where(player => player.IsIn()))
            {
                player.ComboEvaluate();
            }
        }

        private void FindHighestCombo()
        {
            foreach (var player in _players)
            {
                if (player.GetHandRank() > HighestRank)
                {
                    HighestRank = player.GetHandRank();
                }
            }
        }

        private void PayWinners()
        {
            foreach (var player in _winners)
            {
                if (_winners != null) _bank.AddMoney(pot / _winners.Count, player.GetId());
            }
        }

        public void AddMoney(int money, int id)
        {
            _bank.AddMoney(money, id);
        }

        public PlayerPoker GetPlayer(int id)
        {
            return _players[id];
        }
        
        public void CheckPlayerCombo(int id)
        {
            _players[id].ComboEvaluate();
        }
        
        public HandRank GetPlayersCombo(int id)
        {
            return _players[id].GetHandRank();
        }
    }
}