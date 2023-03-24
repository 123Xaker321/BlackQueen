using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CardLib
{
	public class CardSet : IEnumerable<Card>
	{
		private static readonly Random random = new Random();
		private List<Card> cards = new List<Card>();
		public Card LastCard { get => cards[cards.Count - 1]; }
		public int Count{get => cards.Count; }
		public CardSet()
		{

		}
		public CardSet(params Card[] cards)
		{
			this.cards = new List<Card>(cards);
		}
		public CardSet(List<Card> cards)
		{
			this.cards = cards;
		}
		public Card this[int i]
		{
			get => cards[i];
			set => cards[i] = value;
		}
		public void Shuffle()
		{
            for (int i = 0; i < Count; i++)
            {
				int randNum = random.Next(Count);
				Card temp = cards[i];
				cards[i] = cards[randNum];
				cards[randNum] = temp;
            }
		}
		public Card Pull(Card equalsCard)
		{
			Card foundCard = cards.FirstOrDefault(c => c.Equals(equalsCard));
			if (foundCard != null) Remove(foundCard);
			return foundCard;
		}

		public Card Pull(int index = 0)
		{
			if (index < 0 || index >= Count)
				throw new ArgumentOutOfRangeException("The index of card was out of range");
			Card card = cards[index];
			Remove(index);
			return card;
		}
		public CardSet Deal(int CountOfCards)
		{
			if (CountOfCards < 1)
				throw new Exception("Count of cards to deal must be greater then zero");

            if (CountOfCards > Count)
            {
                CountOfCards = Count;
            }

            CardSet set = new CardSet();
            for (int i = 0; i < CountOfCards; i++)
            {
				set.Add(Pull());
            }
			return set;
		}
		public void Sort(CardSet cardSet)
		{
			cards.Sort((card1, card2) => card1.Rank.CompareTo(card2.Rank) == 0 ?

			card1.Suit.CompareTo(card2.Suit) :
			card1.Rank.CompareTo(card2.Rank));

		}
		
		public void Add(CardSet cardSet)
		{
            foreach (var card in cardSet)
            {
				cards.Add(card);
            }
		}
		public void Add(params Card[] cards)
		{
			this.cards.AddRange(cards);
		}
		public void Add(List<Card> cards)
		{
			Add(cards.ToArray());
		}
		public void Remove(Card card)
		{
			cards.Remove(card);
		}
		public void Remove(int index)
		{
			if (index < 0 || index >= Count)
				throw new ArgumentOutOfRangeException("Incorrect index");
			Remove(cards[index]);
		}
		public void RemoveRange(int startIndex, int length)
		{
            for (int i = startIndex; i < startIndex + length; i++)
            {
				Remove(cards[i]);
            }
		}
		public void CutTo(int CountOfCards)
        {
			while (Count > CountOfCards)
				Remove(0);
        }
		public void Clear()
		{
			CutTo(0);
		}
		public void Full()
		{
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
            {
                foreach  (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {
					Add(new Card(rank, suit));            
                }
            }
		}
		public IEnumerator<Card> GetEnumerator() => cards.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => cards.GetEnumerator();
	}
}
