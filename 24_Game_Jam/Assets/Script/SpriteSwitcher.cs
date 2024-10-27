using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite originalSprite; 
    public Sprite extraSprite;    

    private SpriteRenderer spriteRenderer; 

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(SwitchSpriteRandomly());
    }

    private IEnumerator SwitchSpriteRandomly()
    {
        while (true)
        {
            float randomInterval = Random.Range(2f, 5f);

            yield return new WaitForSeconds(randomInterval);

            spriteRenderer.sprite = (spriteRenderer.sprite == originalSprite) ? extraSprite : originalSprite;
        }
    }
}
