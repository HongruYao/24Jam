using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameEntryPanel : MonoBehaviour
{
    public GameObject namePanel;  
    public TMP_InputField nameInputField;  
    public Button confirmButton; 
    public Button clearButton;

    public TextMeshProUGUI playerNameDisplay;

    private void Start()
    {
        
        namePanel.SetActive(true);

        
        confirmButton.onClick.AddListener(OnConfirmButtonClicked);
        clearButton.onClick.AddListener(OnClearButtonClicked);

        
        nameInputField.characterLimit = 10;
        nameInputField.onValueChanged.AddListener(ValidateInput);
    }

    
    private void ValidateInput(string input)
    {
        
        nameInputField.text = System.Text.RegularExpressions.Regex.Replace(input, "[^a-zA-Z]", "");
    }

    
    private void OnConfirmButtonClicked()
    {
        if (!string.IsNullOrEmpty(nameInputField.text))
        {
            
            namePanel.SetActive(false);

            playerNameDisplay.text = "Boss " + nameInputField.text + ", What should we do?"; 

            Debug.Log("Player Name: " + nameInputField.text);
            
        }
    }

    
    private void OnClearButtonClicked()
    {
        
        nameInputField.text = "";
    }
}
