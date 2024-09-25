using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public int round = 1;
    private Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
        UpdateRoundUI(); // Initialize the UI
    }

    public void UpdateRound(int newRound)
    {
        round = newRound;
        UpdateRoundUI();
    }

    private void UpdateRoundUI()
    {
        uiText.text = "Round: " + round.ToString("#,0");
    }
}
