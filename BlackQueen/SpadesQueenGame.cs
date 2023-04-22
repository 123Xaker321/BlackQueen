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
        public Player Loser { get; private set; } = null;
        

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
            
            
        }
        public void NextTurn()
        {
            ThrowPairs(Taker);
            CheckLoser();

            Taker = Donor.InGame? Donor: NextPlayer(Donor);
            Donor = NextPlayer(Donor);
            
                
                ShowState();
            
        }

        private void CheckLoser()
        {
            
            


            int playersInGame = Players.Count(player => player.InGame);
            Loser = playersInGame > 1 ? null : Players.First(player => player.InGame);

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
            Random rnd = new Random();
            if (!Donor.Hand.Contains(card)) return;
            if (Loser != null) return;
            
            TakeCard(card);
            NextTurn();
            if (Taker != Players[0]) 
                Turn(Donor.Hand[rnd.Next(Donor.Hand.Count)]);
        }



    }
}
