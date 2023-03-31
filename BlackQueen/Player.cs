using CardLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBlackJack
{
    public class Player
    {
        public Player(string name) : this(name, new CardSet()) { }
        public Player() : this("Noname") { }
        public Player(string name, CardSet hand) : this(name, hand, 0) { }
        public Player(string name, CardSet hand, int winpoints)
        {
            Name = name;
            Hand = hand;
            WinPoints = winpoints;
        }
        public string Name { get; set; }
        public CardSet Hand { get; set; }
        public int WinPoints{ get; set; }
        public bool InGame { get; set; }
        
    }
}
