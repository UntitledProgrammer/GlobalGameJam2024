using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlarmingLadder.GGJ2024
{
    [RequireComponent(typeof(UnityEngine.UI.Image))] public class GameManager : Jacobs.Concepts.MonoSingleton<GameManager>
    {
        // Instance Attributes:
        [SerializeField] private Deck mDeck;
        private UnityEngine.UI.Image mImage;
        private Card mCurrentCard;

        // Methods:
        private void Start()
        {
            // Initialise attributes:
            mImage = GetComponent<UnityEngine.UI.Image>();

            // For debugging.
            UnityEngine.Assertions.Assert.IsNotNull(mDeck, "[Warning] GameManager: The card deck is null.");
            UnityEngine.Assertions.Assert.IsNotNull(mImage, "[Error] GameManager: The GameObject is missing an Image component.");

#if UNITY_EDITOR
            // Validate the deck by checking whether the number of cards initialised is greater than zero.
            if(!mDeck.IsEmpty) { return; }
            Debug.LogWarning("[GameManager] The deck of cards instance is empty.");
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
            if(mDeck == null || mImage == null) { return; }

            mCurrentCard = mDeck.GetRandom();
            mImage.sprite = mCurrentCard.Sprite;
        }
    }
}