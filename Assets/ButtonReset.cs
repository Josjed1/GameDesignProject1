using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonReset : MonoBehaviour
{
    public Button resetButton;

    void Start()
    {
        resetButton.onClick.AddListener(ResetGame);
        resetButton.gameObject.SetActive(false);

    }

    public void ShowResetButton()
    {
        Time.timeScale = 0;
        resetButton.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("_Scene_0");
    }
}
