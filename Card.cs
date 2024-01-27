using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlarmingLadder.GGJ2024
{
    [System.Serializable] public enum CardType
    {
        VOICE = 0,
        BODY = 1,
        CHALLENGE = 2,
        LENGTH = 3
    }

    [System.Serializable] public struct Card
    {
        // Instance Attributes:
        [SerializeField] private Sprite mSprite;
        [SerializeField] private CardType mCardType;

        // Properties:
        public readonly Sprite Sprite => mSprite;
        public readonly CardType Type => mCardType;

        // Constructor:
        public Card(Sprite pSprite, CardType pCardType)
        {
            mSprite = pSprite;
            mCardType = pCardType;
        }
    }
}