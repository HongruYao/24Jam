using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FiscalYearManager : MonoBehaviour
{
    [Header("Fiscal Year Components")]
    public Slider fiscalYearSlider;
    public TextMeshProUGUI fiscalYearText;

    private float fiscalQuarterValue = 0; 
    private int fiscalYear = 1;

    private void Start()
    {
        fiscalYearSlider.minValue = 0;
        fiscalYearSlider.maxValue = 4;
        fiscalYearSlider.value = fiscalQuarterValue;

        UpdateFiscalYearDisplay();
    }

    public void AdvanceFiscalQuarter()
    {
        fiscalQuarterValue += 0.5f;

        if (fiscalQuarterValue > 4)
        {
            fiscalQuarterValue = 0.5f;
            fiscalYear++;
            UpdateFiscalYearDisplay();
        }

        fiscalYearSlider.value = fiscalQuarterValue;
    }

    private void UpdateFiscalYearDisplay()
    {
        fiscalYearText.text = "FY" + fiscalYear;
    }

    public int GetFiscalYear()
    {
        return fiscalYear;
    }

    public float GetQuarterValue()
    {
        return fiscalQuarterValue;
    }
}
