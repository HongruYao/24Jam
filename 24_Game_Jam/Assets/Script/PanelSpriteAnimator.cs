using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSpriteAnimator : MonoBehaviour
{
    [Header("Left Panel Images")]
    public Image leftImageA;
    public Image leftImageB;

    [Header("Right Panel Images")]
    public Image rightImageC;
    public Image rightImageD;

    private void Start()
    {
        StartCoroutine(AnimateLeftPanel());
        StartCoroutine(AnimateRightPanel());
    }

    private IEnumerator AnimateLeftPanel()
    {
        while (true)
        {
            leftImageA.gameObject.SetActive(true);
            leftImageB.gameObject.SetActive(false);
            yield return new WaitForSeconds(1.0f);

            leftImageA.gameObject.SetActive(false);
            leftImageB.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
        }
    }

    private IEnumerator AnimateRightPanel()
    {
        while (true)
        {
            rightImageC.gameObject.SetActive(true);
            rightImageD.gameObject.SetActive(false);
            yield return new WaitForSeconds(1.0f);

            rightImageC.gameObject.SetActive(false);
            rightImageD.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
