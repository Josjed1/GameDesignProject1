using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        startButton.gameObject.SetActive(false);
    }

    public void ShowStartButton()
    {
        startButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startButton.gameObject.SetActive(false);
    }
}
