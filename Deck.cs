using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlarmingLadder.GGJ2024
{
    [CreateAssetMenu(fileName = "Deck", menuName = "Jester's Gambit/Deck")] public class Deck : ScriptableObject
    {
        // Class Attributes:
        private static readonly int START_OF_DECK = 0;

        // Instance Attributes:
        [SerializeField] private Sprite[] mCards;

        // Properties:
        public Sprite ActiveCard => IsEmpty? default : mCards[^1];

        public int NumberOfCards => mCards.Length;

        public bool IsEmpty => mCards.Length <= 0;

        // Methods:
        public Sprite[] ToArray() { return mCards; }

        public void Shuffle()
        {
            /**
             * Returns a card that has been randomly selected from the deck.
             * The random selection always excludes the last card at the end of the deck
             * to stop the chance of the same card always being produced by random chance.
             */

            // If the deck is empty return a default card value.
            if (IsEmpty) { return; }

            // Select a random card.
            int randomIndex = mCards.Length <= 2 ? START_OF_DECK : Random.Range(START_OF_DECK, mCards.Length - 1);
            Sprite randomCard = mCards[randomIndex];

            // Swap the randomly chosen card with the card at the back of the deck.
            mCards[randomIndex] = mCards[^1];
            mCards[^1] = randomCard;
        }
    }
}