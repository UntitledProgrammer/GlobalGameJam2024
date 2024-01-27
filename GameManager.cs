using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlarmingLadder.GGJ2024
{
    public struct Hands
    {
        /**
         * Hands (I couldn't think up a good name... *shrugs*) represents a single round/play.
         * For each round the jester must utilise the challenge, body, and voice.
         */

        // Instance Attributes:
        private Card[] mCards;

        // Properties:
        public readonly ref Card ChallengeCard => ref mCards[(int)CardType.CHALLENGE];
        public readonly ref Card BodyCard => ref mCards[(int)CardType.BODY];
        public readonly ref Card VoiceCard => ref mCards[(int)CardType.VOICE];

        // Constructor:
        public Hands(Card pVoiceCard, Card pBodyCard, Card pChallengeCard)
        {
            // Initialise the array to contain an element for each type of card.
            mCards = new Card[(int)CardType.LENGTH];

            // Set the cards in the correct position.
            mCards[(int)CardType.CHALLENGE] = pChallengeCard;
            mCards[(int)CardType.BODY] = pBodyCard;
            mCards[(int)CardType.VOICE] = pVoiceCard;
        }
    }

    [RequireComponent(typeof(UnityEngine.UI.Image))] public class GameManager : Jacobs.Concepts.MonoSingleton<GameManager>
    {
        // Instance Attributes:
        [SerializeField] private Deck mVoiceDeck;
        [SerializeField] private Deck mBodyDeck;
        [SerializeField] private Deck mChallengeDeck;
        private UnityEngine.UI.Image mImage;
        private Hands mCurrentHands;

        // Methods:
        private Hands GetHands()
        {
            return new Hands(mVoiceDeck.GetRandom(), mBodyDeck.GetRandom(), mChallengeDeck.GetRandom());
        }

        private void Start()
        {
            // Initialise attributes:
            mImage = GetComponent<UnityEngine.UI.Image>();

#if UNITY_EDITOR
            // Validate the each card deck.
            UnityEngine.Assertions.Assert.IsNotNull(mBodyDeck, "[Warning] GameManager: The body card deck is null.");
            UnityEngine.Assertions.Assert.IsNotNull(mVoiceDeck, "[Warning] GameManager: The voice card deck is null.");
            UnityEngine.Assertions.Assert.IsNotNull(mChallengeDeck, "[Warning] GameManager: The challenge card deck is null.");

            // Validate the image component.
            UnityEngine.Assertions.Assert.IsNotNull(mImage, "[Error] GameManager: The GameObject is missing an Image component.");
#endif
        }

        public void SetActive(bool pIsActive)
        {
            /**
             * Set's the active state for the 'Image' rendering component.
             * When 'pIsActive' is false, the Image component is disabled. Therefore, no card is rendered to screen.
             * When 'pIsActive' is true, the image component is enabled, and the card is rendered to screen.
             */

            // To reduce error, the method will exit before accessing the 'Image' component if it is null.
            if(mImage == null) { Debug.LogError("[GameManager] The 'Image' component was null."); return; }

            mImage.enabled = pIsActive;
        }

        public void GetCard()
        {
            /**
             * A card at random is pulled from the deck of cards and displayed on screen using the 'Image' component.
             */
           // if(mDeck == null || mImage == null) { return; }

            //mCurrentCard = mDeck.GetRandom();
            //mImage.sprite = mCurrentCard.Sprite;
        }
    }
}