using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [Header("Card Settings")]
    public List<GameObject> cardPrefabs;
    private Queue<GameObject> cardQueue;

    [Header("Spawn Point")]
    public Transform cardSpawnPoint;

    [Header("Card Back Display")]
    public CardBackDisplay cardBackDisplay; // Reference to CardBackDisplay script

    private GameObject currentCard;

    public FiscalYearManager fiscalYearManager;

    private void Start()
    {
        cardQueue = new Queue<GameObject>();
        ShuffleAndQueueCards();
        UpdateCardBackDisplay(); // Update card back for the first card in the queue
        DisplayNextCard();
    }

    private void ShuffleAndQueueCards()
    {
        List<GameObject> shuffledCards = new List<GameObject>(cardPrefabs);
        for (int i = 0; i < shuffledCards.Count; i++)
        {
            GameObject temp = shuffledCards[i];
            int randomIndex = Random.Range(i, shuffledCards.Count);
            shuffledCards[i] = shuffledCards[randomIndex];
            shuffledCards[randomIndex] = temp;
        }

        foreach (var card in shuffledCards)
        {
            cardQueue.Enqueue(card);
        }
    }

    private void DisplayNextCard()
    {
        fiscalYearManager.AdvanceFiscalQuarter();

        if (cardQueue.Count == 1)
        {
            GameObject lastCard = cardQueue.Dequeue();
            ShuffleAndQueueCards();
            cardQueue.Enqueue(lastCard);
        }

        if (cardQueue.Count > 0)
        {
            GameObject cardPrefab = cardQueue.Dequeue();
            currentCard = Instantiate(cardPrefab, cardSpawnPoint.position, Quaternion.identity);
            currentCard.GetComponent<CardEffects>().sliderManager = FindObjectOfType<SliderManager>();

            // Update the card back for the upcoming card in the queue
            UpdateCardBackDisplay();

            StartCoroutine(WaitForCardToFinish());
        }
    }

    private void UpdateCardBackDisplay()
    {
        if (cardQueue.Count > 0)
        {
            GameObject nextCard = cardQueue.Peek(); // Look at the next card without removing it
            cardBackDisplay.UpdateCardBack(nextCard); // Update the card back based on next card
        }
    }

    private IEnumerator WaitForCardToFinish()
    {
        Animator animator = currentCard.GetComponent<Animator>();

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_Drop_Left") &&
               !animator.GetCurrentAnimatorStateInfo(0).IsName("Card_Drop_Right"))
        {
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        GameObject cardPrefab = cardPrefabs.Find(prefab => prefab.name == currentCard.name.Replace("(Clone)", ""));
        Destroy(currentCard);
        cardQueue.Enqueue(cardPrefab);
        DisplayNextCard();
    }
}
