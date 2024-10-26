using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardTextElements : MonoBehaviour
{
    // Text fields for each element
    [Header("Text Elements")]
    public TextMeshProUGUI questText;        // Reference for Quest text element
    public TextMeshProUGUI nameText;         // Reference for Name text element
    public TextMeshProUGUI leftOptionText;   // Reference for Left Option text element
    public TextMeshProUGUI rightOptionText;  // Reference for Right Option text element

    [Header("Content Settings")]
    [TextArea] public string questContent;        // Editable quest content in the inspector
    [TextArea] public string nameContent;         // Editable name content in the inspector
    [TextArea] public string leftOptionContent;   // Editable left option content in the inspector
    [TextArea] public string rightOptionContent;  // Editable right option content in the inspector

    private void Start()
    {
        // Find and assign the TextMeshProUGUI components if they are not assigned
        if (questText == null)
            questText = GameObject.Find("Quest_Display").GetComponent<TextMeshProUGUI>();

        if (nameText == null)
            nameText = GameObject.Find("Card_Name_Display").GetComponent<TextMeshProUGUI>();

        if (leftOptionText == null)
            leftOptionText = GameObject.Find("Left_Panel/Left_Option_Display").GetComponent<TextMeshProUGUI>();

        if (rightOptionText == null)
            rightOptionText = GameObject.Find("Right_Panel/Right_Option_Display").GetComponent<TextMeshProUGUI>();

        // Set the initial text for each element from inspector input
        questText.text = questContent;
        nameText.text = nameContent;
        leftOptionText.text = leftOptionContent;
        rightOptionText.text = rightOptionContent;
    }
}
