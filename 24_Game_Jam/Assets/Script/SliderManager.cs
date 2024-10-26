using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [Header("Sliders")]
    public Slider shareholdersSlider;
    public Slider workersSlider;
    public Slider developSlider;
    public Slider designSlider;

    private void Start()
    {
        // Set the min and max values for each slider
        shareholdersSlider.minValue = 0;
        shareholdersSlider.maxValue = 5;
        workersSlider.minValue = 0;
        workersSlider.maxValue = 5;
        developSlider.minValue = 0;
        developSlider.maxValue = 5;
        designSlider.minValue = 0;
        designSlider.maxValue = 5;

        // Set initial value to 2.5
        shareholdersSlider.value = 2.5f;
        workersSlider.value = 2.5f;
        developSlider.value = 2.5f;
        designSlider.value = 2.5f;
    }

    // Methods to adjust slider values, called by the card prefab script
    public void AdjustShareholders(float amount) => shareholdersSlider.value = Mathf.Clamp(shareholdersSlider.value + amount, 0, 5);
    public void AdjustWorkers(float amount) => workersSlider.value = Mathf.Clamp(workersSlider.value + amount, 0, 5);
    public void AdjustDevelop(float amount) => developSlider.value = Mathf.Clamp(developSlider.value + amount, 0, 5);
    public void AdjustDesign(float amount) => designSlider.value = Mathf.Clamp(designSlider.value + amount, 0, 5);
}
