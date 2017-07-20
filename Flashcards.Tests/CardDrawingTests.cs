using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Flashcards.Tests
{
    [TestFixture]
    public class CardDrawingTests
    {
        private Card _initiallyOldestCard;
        private Card _otherCard;
        private Deck _deck;

        [SetUp]
        public void Set_up_deck()
        {
            _initiallyOldestCard = new Card(DateTime.Now.AddDays(-7));
            _otherCard = new Card(DateTime.Now.AddDays(-3));
            _deck = new Deck(_initiallyOldestCard, _otherCard);;
        }

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
            var drawnCard = _deck.DrawCard();
            Assert.AreEqual(_initiallyOldestCard, drawnCard);
        }

        [Test]
        public void Same_card_is_not_drawn_twice_in_a_row()
        {
            var firstCard = _deck.DrawCard();
            var secondCard = _deck.DrawCard();
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
            var drawnCard = _cards.OrderBy(card => card.LastDrawn).First();
            drawnCard.LastDrawn = DateTime.Now;
            return drawnCard;
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
