using CardLib;
using ConsoleBlackJack;
using GraphicsInfrastructure;
using SpadesQueen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TurnTest
{
    public partial class Form1 : Form
    {
        List<Panel> Panels = new List<Panel>();
        SpadesQueenGame game;
        GraphicsStore store;
        List<GraphicsCardSet> sets = new List<GraphicsCardSet>();
        Card activeCard;
        int gap = 10;


        public Form1()
        {
            InitializeComponent();
            Panels.Add(pPlayer1);
            Panels.Add(pPlayer2);
            Panels.Add(pPlayer3);
            var players = InitializePlayers();
            game = new SpadesQueenGame(players, ShowState);
            store = new GraphicsStore(game.Deck, this);

            for (int i = 0; i < players.Count; i++)
            {
                
                sets.Add(new GraphicsCardSet(players[i].Hand,
                new Rectangle(new Point(Panels[i].Location.X + gap / 2, Panels[i].Location.Y + gap / 2), 
                new Size(Panels[i].Width - gap, Panels[i].Height - gap)), store));
            }
            sets.Add(new GraphicsCardSet(game.Bin, new Rectangle(0, 0, 10, 10), store));
            


            BindEvents();
            game.Start();
            Update();
        }

        private List<Player> InitializePlayers()
        {
            //
            var players = new List<Player>()
            {
                new Player("Bob"),
                new Player("Steve"),
                new Player("Jack"),
            };

            return players;
        }

        private void BindEvents()
        {
            foreach (var card in game.Deck)
            {
                var pb = store.GetPictureBox(card);
                pb.MouseDown += SelectCard;
                pb.MouseMove += CardMoving;
                pb.MouseUp += Turn;
            }
        }

        private void Turn(object sender, MouseEventArgs e)
        {
            if (activeCard == null) return;
            if (e.Button != MouseButtons.Left) return;
            Rectangle r1 = new Rectangle(pActive.Location, pActive.Size);
            foreach (var set in sets)
            {
                Rectangle r2 = set.Frame;
                if (r1.IntersectsWith(r2))
                    game.Turn(activeCard);
            }

            activeCard = null;
            pActive.Hide();
        }

        private void CardMoving(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (activeCard == null) return;
            pActive.Location = new Point(Cursor.Position.X - this.Location.X - pActive.Width,
                Cursor.Position.Y - this.Location.Y - pActive.Height);
            pActive.BringToFront();
        }

        private void SelectCard(object sender, MouseEventArgs e)
        {
            var pb = sender as PictureBox;
            if (pb == null) return;

            activeCard = store.GetCard(pb);
            pActive.Location = new Point(Cursor.Position.X - this.Location.X - pActive.Width,
                Cursor.Position.Y - this.Location.Y - pActive.Height);
            pActive.Image = pb.Image;
            pActive.Show();
        }

        private void ShowState()
        {
            foreach (var set in sets)
            {
                set.Draw(game.Taker.Hand == set.CardSet);
               
             
              
                    MarkPlayer(set, game.Donor.Hand == set.CardSet);

            }
        }

        private void MarkPlayer(GraphicsCardSet set, bool active)
        {
            int index = sets.IndexOf(set);
            if (index == -1 || index >= Panels.Count) return;
            
            Panels[index].BackColor = active ? Color.LightGreen : BackColor;
        }

        private void pPlayer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}