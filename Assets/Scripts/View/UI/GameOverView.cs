using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameOverView : View
{
    public event Action RestartButton;

    [SerializeField] GameObject GameOverPanel;
    [SerializeField] Text enemiesKilledText;

    public void Show(int enemiesKilled) {
        enemiesKilledText.text = "Enemies killed: " + enemiesKilled;
        GameOverPanel.SetActive(true);
    }

    public void Hide() {
        GameOverPanel.SetActive(false);
    }

    public void OnRestartButton() {
        if (RestartButton != null) {
            RestartButton();
        }
    }
}
