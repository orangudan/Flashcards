using System;
using NUnit.Framework;

namespace Flashcards.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Card_can_be_drawn_from_deck()
        {
            var deck = new Deck();
            var drawnCard = deck.DrawCard();
            Assert.IsNotNull(drawnCard);
        }
    }

    class Deck
    {
        public Card DrawCard()
        {
            return new Card();
        }
    }

    class Card
    {
    }
}
