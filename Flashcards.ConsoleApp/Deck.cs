using System;
using System.Collections.Generic;
using System.Linq;

namespace Flashcards.ConsoleApp
{
    public class Deck
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
}