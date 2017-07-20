using System;

namespace Flashcards.ConsoleApp
{
    public class Card
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