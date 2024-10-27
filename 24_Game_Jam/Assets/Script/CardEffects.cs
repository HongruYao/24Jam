using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
    public SliderManager sliderManager; // Reference to the SliderManager in the scene

    [Header("Left Option Effects")]
    public float leftShareholdersEffect;
    public float leftWorkersEffect;
    public float leftDevelopEffect;
    public float leftDesignEffect;

    [Header("Right Option Effects")]
    public float rightShareholdersEffect;
    public float rightWorkersEffect;
    public float rightDevelopEffect;
    public float rightDesignEffect;

    private void Start()
    {
        // Automatically find the SliderManager in the scene if it's not assigned
        if (sliderManager == null)
        {
            sliderManager = FindObjectOfType<SliderManager>();
            if (sliderManager == null)
            {
                Debug.LogError("SliderManager not found in the scene.");
            }
        }
    }

    // Triggered when Drop_Left is chosen
    public void ApplyLeftOptionEffects()
    {
        sliderManager.AdjustShareholder(leftShareholdersEffect);
        sliderManager.AdjustWorkers(leftWorkersEffect);
        sliderManager.AdjustDevelop(leftDevelopEffect);
        sliderManager.AdjustDesign(leftDesignEffect);
    }

    // Triggered when Drop_Right is chosen
    public void ApplyRightOptionEffects()
    {
        sliderManager.AdjustShareholder(rightShareholdersEffect);
        sliderManager.AdjustWorkers(rightWorkersEffect);
        sliderManager.AdjustDevelop(rightDevelopEffect);
        sliderManager.AdjustDesign(rightDesignEffect);
    }
}
