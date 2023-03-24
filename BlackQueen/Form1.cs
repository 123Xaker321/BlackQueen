using CardLib;
using GraphicsInfrastructure;
using SpadesQueen;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TurnTest
{
    public partial class Form1 : Form
    {
        SpadesQueenGame game;
        GraphicsStore store;
        GraphicsCardSet table;
        List<GraphicsCardSet> sets = new List<GraphicsCardSet>();
        Card activeCard;
        public Form1()
        {
            InitializeComponent();
            
            game = new SpadesQueenGame(ShowState);
            store = new GraphicsStore(game.Deck, this);
            sets.Add(new GraphicsCardSet(game.Deck,
                new Rectangle(pDeck.Location, pDeck.Size), store));
            sets.Add(new GraphicsCardSet(game.Player.Hand,
                new Rectangle(pPlayer.Location, pPlayer.Size), store));
            table = new GraphicsCardSet(game.Table,
                new Rectangle(pTable.Location, pTable.Size), store);
            sets.Add(table);
            BindEvents();
            game.Start();
            Update();
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
            Rectangle r2 = table.Frame;
            if (r1.IntersectsWith(r2))
                game.Turn(activeCard);
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