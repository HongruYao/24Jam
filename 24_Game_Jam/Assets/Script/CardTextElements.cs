using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardTextElements : MonoBehaviour
{
    // Text fields for each element
    [Header("Text Elements")]
    public TextMeshProUGUI questText;        
    public TextMeshProUGUI nameText;         
    public TextMeshProUGUI leftOptionText;   
    public TextMeshProUGUI rightOptionText;  

    [Header("Content Settings")]
    [TextArea] public string questContent;        
    [TextArea] public string nameContent;         
    [TextArea] public string leftOptionContent;   
    [TextArea] public string rightOptionContent;  

    private void Start()
    {
        if (questText == null)
            questText = GameObject.Find("Quest_Display").GetComponent<TextMeshProUGUI>();

        if (nameText == null)
            nameText = GameObject.Find("Card_Name_Display").GetComponent<TextMeshProUGUI>();

        if (leftOptionText == null)
            leftOptionText = GameObject.Find("Left_Panel/Left_Option_Display").GetComponent<TextMeshProUGUI>();

        if (rightOptionText == null)
            rightOptionText = GameObject.Find("Right_Panel/Right_Option_Display").GetComponent<TextMeshProUGUI>();

        questText.text = questContent;
        nameText.text = nameContent;
        leftOptionText.text = leftOptionContent;
        rightOptionText.text = rightOptionContent;
    }
}
