using CardLib;
using ConsoleBlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpadesQueen
{
    class SpadesQueenGame
    {
        private Card SpadesQueen = new Card(CardRank.Queen, CardSuit.Spade);
        public SpadesQueenGame(List<Player> players, Action showState)
        {
            Deck = new CardSet();
            Deck.Full();
            Table = new CardSet();
            ShowState = showState;
            Players = players;
        }
        public Action ShowState { get; set; }
        public CardSet Deck { get; set; }
        public Player Player { get; set; }
        public CardSet Table { get; set; }
        

        //properties
        public List<Player> Players = new List<Player>();
        public Player Taker = new Player();
        public Player Donor = new Player();
        
        //methods
        public void TakeCard(Card card)
        {
            Donor.Hand.Remove(card);
            Taker.Hand.Add(card);
        }
        public void ThrowPairs(Player player) 
        {
            //буде використовуватися тільки під час того, як Taker бере карту.
            //після того як взяв, скидує пару.
            for (int i = player.Hand.Count - 1; i >= 0; i--)
            {
                if (player.Hand[i].Equals(SpadesQueen)) continue;
                bool IsPair = false;
                for (int j = player.Hand.Count - 1; j >= 0; j--)
                {
                    if (i == j) continue;
                    if (player.Hand[j].Equals(SpadesQueen)) continue;
                    if(player.Hand[j].Rank == player.Hand[i].Rank)
                    {
                        IsPair = true;
                        player.Hand.Remove(j);
                        break;
                    }
                }
                if (IsPair) player.Hand.Remove(i);
            }
            player.InGame = player.Hand.Count > 0;
            
        }
        public void NextTurn()
        {
            ThrowPairs(Taker);
            Taker = Donor;
            Donor = NextPlayer(Donor);
            CheckWinner();
            ShowState();
            
        }

        private void CheckWinner()
        {
            //Якщо 1 гравець у грі, він програв
        }

        private Player NextPlayer(Player player)
        {
            int i = Players.IndexOf(player);
            Player candidate;
            if (i == Players.Count - 1) candidate = Players[0];
            else candidate = Players[i + 1];
            return candidate.InGame ? candidate : NextPlayer(candidate);
        }

        public void Start()
        {
            //Зробити дію в циклах
            //Deck.Remove(Deck.FirstOrDefault(CardSuit.Diamond, CardRank.Queen));
            Player.Hand.Add(Deck.Deal((Deck.Count - 1) / Players.Count));
            ThrowPairs(Player);
            ShowState();
        }
        public void Turn(Card card)
        {
            if (!Donor.Hand.Contains(card)) return;
            TakeCard(card);
            NextTurn();
        }



    }
}
