using System;
using NUnit.Framework;
using Flashcards.ConsoleApp;

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
}
