using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Image[] images; // Drag your 3 images here in the inspector
    public AudioSource[] soundEffects; // Drag your 4 sound effects here in the inspector
    public Button revealButton; // Drag your button here in the inspector

    private int currentImageIndex = 0;

    void Start()
    {
        // Hide all images initially by setting their alpha to 0
        foreach (Image img in images)
        {
            Color imgColor = img.color;
            imgColor.a = 0;
            img.color = imgColor;
        }

        // Begin the reveal of the first image
        StartCoroutine(RevealImage(images[0], soundEffects[0]));

        // Add button listener for image reveal on click
        revealButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (currentImageIndex < images.Length - 1)
        {
            currentImageIndex++;
            StartCoroutine(RevealImage(images[currentImageIndex], soundEffects[currentImageIndex]));
        }
        else
        {
            // If all images have been revealed, play final sound effect and load the main scene
            StartCoroutine(PlayFinalSoundAndLoadScene());
        }
    }

    IEnumerator RevealImage(Image img, AudioSource sound)
    {
        sound.Play();
        float duration = 2f;
        float elapsedTime = 0f;
        Color color = img.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, elapsedTime / duration);
            img.color = color;
            yield return null;
        }
        color.a = 1;
        img.color = color;
    }

    IEnumerator PlayFinalSoundAndLoadScene()
    {
        soundEffects[3].Play();
        yield return new WaitForSeconds(soundEffects[3].clip.length);
        SceneManager.LoadScene("Main_Scene");
    }
}
