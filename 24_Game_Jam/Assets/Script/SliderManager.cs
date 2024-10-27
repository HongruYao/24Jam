using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [Header("Sliders")]
    public Slider shareholdersSlider;
    public Slider workersSlider;
    public Slider developSlider;
    public Slider designSlider;

    [Header("Fail Panel")]
    public GameObject failPanel; 
    public TextMeshProUGUI failReasonText; 
    public TextMeshProUGUI fiscalYearText; 

    [Header("Warnings")]
    public TextMeshProUGUI shareholdersWarning;
    public TextMeshProUGUI workersWarning;
    public TextMeshProUGUI developWarning;
    public TextMeshProUGUI designWarning;

    private FiscalYearManager fiscalYearManager; 

    private void Start()
    {
        shareholdersSlider.minValue = 0;
        shareholdersSlider.maxValue = 10;
        workersSlider.minValue = 0;
        workersSlider.maxValue = 10;
        developSlider.minValue = 0;
        developSlider.maxValue = 10;
        designSlider.minValue = 0;
        designSlider.maxValue = 10;

        shareholdersSlider.value = 5.0f;
        workersSlider.value = 5.0f;
        developSlider.value = 5.0f;
        designSlider.value = 5.0f;

        shareholdersWarning.gameObject.SetActive(false);
        workersWarning.gameObject.SetActive(false);
        developWarning.gameObject.SetActive(false);
        designWarning.gameObject.SetActive(false);

        fiscalYearManager = FindObjectOfType<FiscalYearManager>();
    }

    private void Update()
    {
        shareholdersWarning.gameObject.SetActive(shareholdersSlider.value > 8.5f || shareholdersSlider.value < 2.5f);
        workersWarning.gameObject.SetActive(workersSlider.value > 8.5f || workersSlider.value < 2.5f);
        developWarning.gameObject.SetActive(developSlider.value > 8.5f || developSlider.value < 2.5f);
        designWarning.gameObject.SetActive(designSlider.value > 8.5f || designSlider.value < 2.5f);

        if (shareholdersSlider.value == shareholdersSlider.minValue)
        {
            StartCoroutine(TriggerFail("The company’s operations are terrible, and the shareholders have decided to stop funding."));
        }
        else if (shareholdersSlider.value == shareholdersSlider.maxValue)
        {
            StartCoroutine(TriggerFail("The market value has reached its peak, drawing the covetous eyes of the shareholders."));
        }
        else if (workersSlider.value == workersSlider.minValue)
        {
            StartCoroutine(TriggerFail("Workers are facing poor conditions and have collectively gone on strike."));
        }
        else if (workersSlider.value == workersSlider.maxValue)
        {
            StartCoroutine(TriggerFail("Workers are living too comfortably, leading to a sharp drop in work efficiency."));
        }
        else if (developSlider.value == developSlider.minValue)
        {
            StartCoroutine(TriggerFail("There is no innovation; the cars are lagging behind the times in terms of performance."));
        }
        else if (developSlider.value == developSlider.maxValue)
        {
            StartCoroutine(TriggerFail("You've developed new technology, rendering cars a thing of the past for humanity."));
        }
        else if (designSlider.value == designSlider.minValue)
        {
            StartCoroutine(TriggerFail("The cars are too unattractive, and no customer is willing to buy them."));
        }
        else if (designSlider.value == designSlider.maxValue)
        {
            StartCoroutine(TriggerFail("The car design is too avant-garde, causing significant obstacles in development."));
        }
    }

    public void AdjustShareholder(float amount) => shareholdersSlider.value = Mathf.Clamp(shareholdersSlider.value + amount, 0, 10);
    public void AdjustWorkers(float amount) => workersSlider.value = Mathf.Clamp(workersSlider.value + amount, 0, 10);
    public void AdjustDevelop(float amount) => developSlider.value = Mathf.Clamp(developSlider.value + amount, 0, 10);
    public void AdjustDesign(float amount) => designSlider.value = Mathf.Clamp(designSlider.value + amount, 0, 10);

    private IEnumerator TriggerFail(string reason)
    {
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(1.5f);

        failPanel.SetActive(true);
        failReasonText.text = reason;

        int currentFiscalYear = fiscalYearManager.GetFiscalYear(); 
        float quarterValue = fiscalYearManager.GetQuarterValue(); 
        string quarterText = DetermineQuarter(quarterValue);

        fiscalYearText.text = $"You are fired around FY{currentFiscalYear}, {quarterText}";
    }

    private string DetermineQuarter(float value)
    {
        if (value == 0.5f || value == 1f)
            return "Q1";
        else if (value == 1.5f || value == 2f)
            return "Q2";
        else if (value == 2.5f || value == 3f)
            return "Q3";
        else if (value == 3.5f || value == 4f)
            return "Q4";
        else
            return "Unknown Quarter";
    }
}
