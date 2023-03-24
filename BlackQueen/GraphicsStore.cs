using CardLib;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BlackQueen.Properties;

namespace GraphicsInfrastructure
{
    public class GraphicsStore
    {

        private static Dictionary<string, Image> cardImages = new Dictionary<string, Image>();
        private Dictionary<Card, PictureBox> pictureBoxes = new Dictionary<Card, PictureBox>();
        private Dictionary<PictureBox, Card> cards = new Dictionary<PictureBox, Card>();

        public Control Parent { get; set; }
        public static Image FaceDownImage { get; private set; }
        static GraphicsStore()
        {
            //FaceDownImage = Image.FromFile($"{Application.StartupPath}\\images\\pattern.png");

            //foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
            //{
            //    foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            //    {
            //        string rankString = (int)rank <= 10 ? $"{(int)rank}" : $"{rank}";
            //        cardImages[new Card(rank, suit).ToString()] =  Resources.
            //        Image.FromFile($"{Application.StartupPath}\\images\\{rankString}_of_{suit}s.png");
            //    }
            //}

            FaceDownImage = Resources._12;
            cardImages[new Card(CardRank.Two, CardSuit.Heart).ToString()] = Resources.Hearts_two;
            cardImages[new Card(CardRank.Two, CardSuit.Diamond).ToString()] = Resources.Diamonds_two;
            cardImages[new Card(CardRank.Two, CardSuit.Club).ToString()] = Resources.Clubs_two;
            cardImages[new Card(CardRank.Two, CardSuit.Spade).ToString()] = Resources.Spades_two;
            cardImages[new Card(CardRank.Three, CardSuit.Heart).ToString()] = Resources.Hearts_three;
            cardImages[new Card(CardRank.Three, CardSuit.Diamond).ToString()] = Resources.Diamonds_three;
            cardImages[new Card(CardRank.Three, CardSuit.Club).ToString()] = Resources.Clubs_three;
            cardImages[new Card(CardRank.Three, CardSuit.Spade).ToString()] = Resources.Spades_three;
            cardImages[new Card(CardRank.Four, CardSuit.Heart).ToString()] = Resources.Hearts_four;
            cardImages[new Card(CardRank.Four, CardSuit.Diamond).ToString()] = Resources.Diamonds_four;
            cardImages[new Card(CardRank.Four, CardSuit.Club).ToString()] = Resources.Clubs_four;
            cardImages[new Card(CardRank.Four, CardSuit.Spade).ToString()] = Resources.Spades_four;
            cardImages[new Card(CardRank.Five, CardSuit.Heart).ToString()] = Resources.Hearts_five;
            cardImages[new Card(CardRank.Five, CardSuit.Diamond).ToString()] = Resources.Diamonds_five;
            cardImages[new Card(CardRank.Five, CardSuit.Club).ToString()] = Resources.Clubs_five;
            cardImages[new Card(CardRank.Five, CardSuit.Spade).ToString()] = Resources.Spades_five;
            cardImages[new Card(CardRank.Six, CardSuit.Heart).ToString()] = Resources.Hearts_six;
            cardImages[new Card(CardRank.Six, CardSuit.Diamond).ToString()] = Resources.Diamonds_six;
            cardImages[new Card(CardRank.Six, CardSuit.Club).ToString()] = Resources.Clubs_six;
            cardImages[new Card(CardRank.Six, CardSuit.Spade).ToString()] = Resources.Spades_six;
            cardImages[new Card(CardRank.Seven, CardSuit.Heart).ToString()] = Resources.Hearts_seven;
            cardImages[new Card(CardRank.Seven, CardSuit.Diamond).ToString()] = Resources.Diamonds_seven;
            cardImages[new Card(CardRank.Seven, CardSuit.Club).ToString()] = Resources.Clubs_seven;
            cardImages[new Card(CardRank.Seven, CardSuit.Spade).ToString()] = Resources.Spades_seven;
            cardImages[new Card(CardRank.Eight, CardSuit.Heart).ToString()] = Resources.Hearts_eight;
            cardImages[new Card(CardRank.Eight, CardSuit.Diamond).ToString()] = Resources.Diamonds_eight;
            cardImages[new Card(CardRank.Eight, CardSuit.Club).ToString()] = Resources.Clubs_eight;
            cardImages[new Card(CardRank.Eight, CardSuit.Spade).ToString()] = Resources.Spades_eight;
            cardImages[new Card(CardRank.Nine, CardSuit.Heart).ToString()] = Resources.Hearts_nine;
            cardImages[new Card(CardRank.Nine, CardSuit.Diamond).ToString()] = Resources.Diamonds_nine;
            cardImages[new Card(CardRank.Nine, CardSuit.Club).ToString()] = Resources.Clubs_nine;
            cardImages[new Card(CardRank.Nine, CardSuit.Spade).ToString()] = Resources.Spades_nine;
            cardImages[new Card(CardRank.Ten, CardSuit.Heart).ToString()] = Resources.Hearts_ten;
            cardImages[new Card(CardRank.Ten, CardSuit.Diamond).ToString()] = Resources.Diamonds_ten;
            cardImages[new Card(CardRank.Ten, CardSuit.Club).ToString()] = Resources.Clubs_ten;
            cardImages[new Card(CardRank.Ten, CardSuit.Spade).ToString()] = Resources.Spades_ten;
            cardImages[new Card(CardRank.Jack, CardSuit.Heart).ToString()] = Resources.Hearts_jack;
            cardImages[new Card(CardRank.Jack, CardSuit.Diamond).ToString()] = Resources.Diamonds_jack;
            cardImages[new Card(CardRank.Jack, CardSuit.Club).ToString()] = Resources.Clubs_jack;
            cardImages[new Card(CardRank.Jack, CardSuit.Spade).ToString()] = Resources.Spades_jack;
            cardImages[new Card(CardRank.Queen, CardSuit.Heart).ToString()] = Resources.Hearts_queen;
            cardImages[new Card(CardRank.Queen, CardSuit.Diamond).ToString()] = Resources.Diamonds_queen;
            cardImages[new Card(CardRank.Queen, CardSuit.Club).ToString()] = Resources.Clubs_queen;
            cardImages[new Card(CardRank.Queen, CardSuit.Spade).ToString()] = Resources.Spades_queen;
            cardImages[new Card(CardRank.King, CardSuit.Heart).ToString()] = Resources.Hearts_king;
            cardImages[new Card(CardRank.King, CardSuit.Diamond).ToString()] = Resources.Diamonds_king;
            cardImages[new Card(CardRank.King, CardSuit.Club).ToString()] = Resources.Clubs_king;
            cardImages[new Card(CardRank.King, CardSuit.Spade).ToString()] = Resources.Spades_king;
            cardImages[new Card(CardRank.Ace, CardSuit.Heart).ToString()] = Resources.Hearts_ace;
            cardImages[new Card(CardRank.Ace, CardSuit.Diamond).ToString()] = Resources.Diamonds_ace;
            cardImages[new Card(CardRank.Ace, CardSuit.Club).ToString()] = Resources.Clubs_ace;
            cardImages[new Card(CardRank.Ace, CardSuit.Spade).ToString()] = Resources.Spades_ace;


        }

        public GraphicsStore(CardSet deck, Control parent)
        {
            parent.SuspendLayout();
            foreach (var card in deck)
            {
                var pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxes[card] = pb;
                cards[pb] = card;
                parent.Controls.Add(pb);
            }
            Parent = parent;
            parent.ResumeLayout();
        }

        public PictureBox GetPictureBox(Card card, bool opened = true)
        {
            var pb = pictureBoxes[card];
            pb.Image = opened ? cardImages[$"{card}"] : FaceDownImage;
            return pb;
        }

        public Card GetCard(PictureBox pb)
        {
            return cards[pb];
        }
    }
}