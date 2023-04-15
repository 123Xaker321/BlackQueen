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
            Bin = new CardSet();
            ShowState = showState;
            Players = players;
        }
        public Action ShowState { get; set; }
        public CardSet Deck { get; set; }
        //public Player Player { get; set; }
        public CardSet Bin { get; set; }
        

        //properties
        public List<Player> Players = new List<Player>();
        public Player Taker;
        public Player Donor;
        
        //methods
        public void TakeCard(Card card)
        {
            Donor.Hand.Remove(card);
            Taker.Hand.Add(card);
            if(!Taker.Hand.Contains(card))
            {
                throw new Exception("В руці гравця повинна залишитися карта");  
            }
        }
        public void ThrowPairs(Player player) 
        {
            
            for (int i = player.Hand.Count - 1; i >= 0; i--)
            {
                if (player.Hand[i].Equals(SpadesQueen)) continue;
                bool IsPair = false;
                int j;
                for (j = i - 1; j >= 0; j--)
                {
                    if (i == j) continue;
                    if (player.Hand[j].Equals(SpadesQueen)) continue;
                    if(player.Hand[j].Rank == player.Hand[i].Rank)
                    {
                        IsPair = true;                        
                        break;
                    }
                }
                if (IsPair)
                {
                    Bin.Add(player.Hand.Pull(i));
                    Bin.Add(player.Hand.Pull(j));
                    i--;
                }
            }
            player.InGame = player.Hand.Count > 0;
            
        }
        public void NextTurn()
        {
            ThrowPairs(Taker);
            Taker = Donor;
            Donor = NextPlayer(Donor);
            CheckLoser();
            ShowState();
            
        }

        private void CheckLoser()
        {
            int inGameCount = 0;
            Player loser = null;

            
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].InGame)
                {
                    inGameCount++;
                    loser = Players[i];
                }
                
            }
            if (inGameCount != 1)
            {
                loser = null;
            }
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
            Deck.Shuffle();

            int countofcards = (int)Math.Ceiling((double)Deck.Count / Players.Count);


            foreach (Player player in Players)
            {
                player.Hand.Add(Deck.Deal(countofcards));
                ThrowPairs(player);
            }
            Taker = Players[0];
            Donor = NextPlayer(Taker);
            
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
