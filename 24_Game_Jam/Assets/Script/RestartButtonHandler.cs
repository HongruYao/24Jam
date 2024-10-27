using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonHandler : MonoBehaviour
{
    public void OnRestartButtonClick()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Menu_Scene");
    }
}
