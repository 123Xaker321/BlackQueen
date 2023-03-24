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
        public SpadesQueenGame(Action showState)
        {
            Deck = new CardSet();
            Deck.Full();
            Player = new Player();
            Table = new CardSet();
            ShowState = showState;
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
        public void ThrowPairs(Card card1, Card card2) 
        {
            //буде використовуватися тільки під час того, як Taker бере карту.
            //після того як взяв, скидує пару.
            Taker.Hand.Remove(card1);
            Taker.Hand.Remove(card2);
        }
        public void NextTurn(int NextTakerIndex, int NextDonorIndex) 
        {
            Taker = Players[NextTakerIndex];
            Donor = Players[NextDonorIndex];
        }
        public void Start()
        {
            Players.Add(new Player("Player1"));
            Players.Add(new Player("Player2"));
            Players.Add(new Player("You"));
            //Deck.Remove(Deck.FirstOrDefault(CardSuit.Diamond, CardRank.Queen));
            Player.Hand.Add(Deck.Deal((Deck.Count - 1) / Players.Count));
            ShowState();
        }
        public void Turn(Card card)
        {
            ShowState();
        }



    }
}
