using CardLib;
using ConsoleBlackJack;
using GraphicsInfrastructure;
using SpadesQueen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TurnTest
{
    public partial class Form1 : Form
    {
        SpadesQueenGame game;
        GraphicsStore store;
        List<GraphicsCardSet> sets = new List<GraphicsCardSet>();
        Card activeCard;
        public Form1()
        {
            InitializeComponent();
            var players = InitializePlayers();
            game = new SpadesQueenGame(players, ShowState);
            store = new GraphicsStore(game.Deck, this);


            sets.Add(new GraphicsCardSet(players[0].Hand,
                new Rectangle(pPlayer.Location, pPlayer.Size), store));
            sets.Add(new GraphicsCardSet(players[1].Hand,
    new Rectangle(panel1.Location, panel1.Size), store));
            sets.Add(new GraphicsCardSet(players[2].Hand,
    new Rectangle(panel2.Location, panel2.Size), store));


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
                set.Draw(game.Deck != set.CardSet);
            }
        }
    }
}