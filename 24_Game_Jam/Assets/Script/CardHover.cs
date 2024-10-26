using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHover : MonoBehaviour
{
    public Animator animator;
    public GameObject namePanel;
    public Collider2D leftZone;
    public Collider2D rightZone;
    public CanvasGroup leftPanel; // Reference to CanvasGroup for transparency control
    public CanvasGroup rightPanel; // Reference to CanvasGroup for transparency control
    public CardEffects cardEffects; // Reference to the CardEffects script on the card prefab

    private bool isLeftHovered = false;
    private bool isRightHovered = false;

    private void Start()
    {
        // Automatically find and assign objects by name if they are not already assigned
        if (namePanel == null)
            namePanel = GameObject.Find("Player_Name_Panel");

        if (leftZone == null)
            leftZone = GameObject.Find("Sensing_Zone_Left").GetComponent<Collider2D>();

        if (rightZone == null)
            rightZone = GameObject.Find("Sensing_Zone_Right").GetComponent<Collider2D>();

        if (leftPanel == null)
            leftPanel = GameObject.Find("Left_Panel").GetComponent<CanvasGroup>();

        if (rightPanel == null)
            rightPanel = GameObject.Find("Right_Panel").GetComponent<CanvasGroup>();

        // Set initial transparency
        SetPanelTransparency(leftPanel, 0);
        SetPanelTransparency(rightPanel, 0);
    }

    private void Update()
    {
        // Skip animation triggering if the name panel is active
        if (namePanel != null && namePanel.activeSelf)
        {
            // Make both panels transparent if the name panel is active
            SetPanelTransparency(leftPanel, 0);
            SetPanelTransparency(rightPanel, 0);
            return;
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (leftZone.OverlapPoint(mousePosition))
        {
            if (!isLeftHovered)
            {
                animator.SetTrigger("Left");
                isLeftHovered = true;
                isRightHovered = false;
                SetPanelTransparency(leftPanel, 1);
                SetPanelTransparency(rightPanel, 0);
            }

            // Check for left mouse click to trigger Drop_Left animation and apply effects
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Drop_Left");
                cardEffects.ApplyLeftOptionEffects(); // Call method to apply left option effects
            }
        }
        else if (rightZone.OverlapPoint(mousePosition))
        {
            if (!isRightHovered)
            {
                animator.SetTrigger("Right");
                isRightHovered = true;
                isLeftHovered = false;
                SetPanelTransparency(rightPanel, 1);
                SetPanelTransparency(leftPanel, 0);
            }

            // Check for left mouse click to trigger Drop_Right animation and apply effects
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Drop_Right");
                cardEffects.ApplyRightOptionEffects(); // Call method to apply right option effects
            }
        }
        else
        {
            if (isLeftHovered || isRightHovered)
            {
                animator.SetTrigger("Return");
                isLeftHovered = false;
                isRightHovered = false;
                SetPanelTransparency(leftPanel, 0);
                SetPanelTransparency(rightPanel, 0);
            }
        }
    }

    // Helper method to set panel transparency
    private void SetPanelTransparency(CanvasGroup panel, float alpha)
    {
        panel.alpha = alpha;
        panel.blocksRaycasts = alpha > 0; // Only block raycasts if visible
    }
}
