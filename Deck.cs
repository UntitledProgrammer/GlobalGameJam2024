using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlarmingLadder.GGJ2024
{
    [CreateAssetMenu(fileName = "Deck", menuName = "Jesters Gambit/Deck")] public class Deck : ScriptableObject
    {
        // Class Attributes:
        private readonly int START_OF_DECK = 0;
        private readonly Card DEFAULT_CARD = new Card();

        // Instance Attributes:
        [SerializeField] private Card[] mCards = default;

        // Properties:
        public int NumberOfCards => mCards.Length;

        public bool IsEmpty => mCards.Length <= 0;

        private int RandomCardIndex
        {
            /**
             * Randomly selects the idnex of a card between the first and second to last card.
             * The last card in a deck also always consided to be excluded from random selection to stop repetition.
             */
            get => mCards.Length <= 2 ? START_OF_DECK : Random.Range(START_OF_DECK, mCards.Length - 1);
        }

        // Methods:
        public Card[] ToArray() { return mCards; }

        public Card GetRandom()
        {
            /**
             * Returns a card that has been randomly selected from the deck.
             * The random selection always excludes the last card at the end of the deck
             * to stop the chance of the same card always being produced by random chance.
             */

            // If the deck is empty return a default card value.
            if (IsEmpty) { return DEFAULT_CARD; }

            // Select a random card.
            int randomIndex = RandomCardIndex;
            Card randomCard = mCards[randomIndex];

            // Swap the randomly chosen card with the card at the back of the deck.
            mCards[randomIndex] = mCards[^1];
            mCards[^1] = randomCard;

            return randomCard;
        }

        // Operators:
        public ref readonly Card this[uint pIndex]
        {
            get
            {
                /**
                * Returns a readonly reference to the card at the parametrised position.
                * The value of the parameter: 'int pIndex' must be between 0 - and the value of property: 'NumberOfCards'.
                */

                UnityEngine.Assertions.Assert.IsTrue(pIndex < mCards.Length, "[Deck] Error, Card::[int] indexing parameter was out of range.");
                return ref mCards[pIndex];
            }
        }
    }
}