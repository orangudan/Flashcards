using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Flashcards.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Card_can_be_drawn_from_deck()
        {
            var deck = new Deck(new Card());
            var drawnCard = deck.DrawCard();
            Assert.IsNotNull(drawnCard);
        }

        [Test]
        public void Oldest_card_is_drawn_first()
        {
            var oldestCard = new Card(DateTime.Now.AddDays(-7));
            var otherCard = new Card(DateTime.Now);
            var deck = new Deck(oldestCard, otherCard);
            var drawnCard = deck.DrawCard();
            Assert.AreEqual(oldestCard, drawnCard);
        }

        [Test]
        public void Same_card_is_not_drawn_twice_in_a_row()
        {
            var deck = new Deck(
                new Card(DateTime.Now.AddDays(-7)),
                new Card(DateTime.Now.AddDays(-3))
            );
            var firstCard = deck.DrawCard();
            var secondCard = deck.DrawCard();
            Assert.AreNotEqual(firstCard, secondCard);
        }
    }

    class Deck
    {
        private readonly List<Card> _cards;

        public Deck(params Card[] cards)
        {
            _cards = new List<Card>(cards);
        }

        public Card DrawCard()
        {
            return _cards.OrderBy(card => card.LastDrawn).First();
        }
    }

    class Card
    {
        public DateTime LastDrawn { get; set; }

        public Card(DateTime lastDrawn)
        {
            LastDrawn = lastDrawn;
        }

        public Card()
        {
            LastDrawn = DateTime.Now;
        }
    }
}
