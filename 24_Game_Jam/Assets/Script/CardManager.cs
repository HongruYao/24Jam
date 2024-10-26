using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [Header("Card Settings")]
    public List<GameObject> cardPrefabs; // List to hold the card prefabs added in the Inspector
    private Queue<GameObject> cardQueue; // Queue to manage card display order

    [Header("Spawn Point")]
    public Transform cardSpawnPoint; // The spawn point for the cards

    private GameObject currentCard; // Reference to the current card being displayed

    private void Start()
    {
        // Initialize the card queue and shuffle the cards
        cardQueue = new Queue<GameObject>();
        ShuffleAndQueueCards();
        DisplayNextCard();
    }

    // Shuffle the cards and queue them
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

    // Display the next card from the queue
    private void DisplayNextCard()
    {
        if (cardQueue.Count > 0)
        {
            // Instantiate the next card at the specified spawn point and set it as the current card
            GameObject cardPrefab = cardQueue.Dequeue();
            currentCard = Instantiate(cardPrefab, cardSpawnPoint.position, Quaternion.identity);
            currentCard.GetComponent<CardEffects>().sliderManager = FindObjectOfType<SliderManager>();

            // Start a coroutine to wait for the card to finish its animation
            StartCoroutine(WaitForCardToFinish());
        }
    }

    // Coroutine to wait for the card to finish playing its animation
    private IEnumerator WaitForCardToFinish()
    {
        Animator animator = currentCard.GetComponent<Animator>();

        // Wait for either Drop_Left or Drop_Right animation to finish
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_Drop_Left") &&
               !animator.GetCurrentAnimatorStateInfo(0).IsName("Card_Drop_Right"))
        {
            yield return null;
        }

        // Wait until the animation is completely finished
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        // Destroy the current card and add it back to the card queue
        Destroy(currentCard);
        cardQueue.Enqueue(currentCard);

        // Display the next card
        DisplayNextCard();
    }
}
