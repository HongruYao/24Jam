using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBackDisplay : MonoBehaviour
{
    [Header("Card Back Sprites")]
    public Sprite designerBack;
    public Sprite workerBack;
    public Sprite researcherBack;
    public Sprite shareholderBack;

    [Header("Card Back Display")]
    public SpriteRenderer cardBackRenderer; // Reference to the SpriteRenderer for displaying the card back

    // Method to update the card back based on the card type
    public void UpdateCardBack(GameObject nextCard)
    {
        // Check the type of the next card and update the sprite accordingly
        if (nextCard.name.Contains("Desinger")) // assuming card name contains its type
        {
            cardBackRenderer.sprite = designerBack;
        }
        else if (nextCard.name.Contains("GeneralStaff"))
        {
            cardBackRenderer.sprite = workerBack;
        }
        else if (nextCard.name.Contains("Researcher"))
        {
            cardBackRenderer.sprite = researcherBack;
        }
        else if (nextCard.name.Contains("Shareholder"))
        {
            cardBackRenderer.sprite = shareholderBack;
        }
        else
        {
            Debug.LogWarning("Card type not recognized for card back update.");
        }
    }
}
