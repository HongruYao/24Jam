using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHover : MonoBehaviour
{
    public Animator animator;
    public GameObject namePanel;
    public Collider2D leftZone;
    public Collider2D rightZone;
    public CanvasGroup leftPanel; 
    public CanvasGroup rightPanel; 
    public CardEffects cardEffects; 

    private bool isLeftHovered = false;
    private bool isRightHovered = false;

    public AudioSource leftSound;
    public AudioSource rightSound;

    private void Start()
    {
        
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
      
        SetPanelTransparency(leftPanel, 0);
        SetPanelTransparency(rightPanel, 0);
    }

    private void Update()
    {     
        if (namePanel != null && namePanel.activeSelf)
        {
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

            if (Input.GetMouseButtonDown(0))
            {
                leftSound.Play();
                animator.SetTrigger("Drop_Left");
                cardEffects.ApplyLeftOptionEffects(); 
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

            if (Input.GetMouseButtonDown(0))
            {
                rightSound.Play();
                animator.SetTrigger("Drop_Right");
                cardEffects.ApplyRightOptionEffects(); 
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
    private void SetPanelTransparency(CanvasGroup panel, float alpha)
    {
        panel.alpha = alpha;
        panel.blocksRaycasts = alpha > 0; 
    }
}
