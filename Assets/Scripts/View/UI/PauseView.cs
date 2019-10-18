using UnityEngine;
using UnityEngine.UI;
using System;
using strange.extensions.mediation.impl;

public class PauseView : View
{
    public event Action RestartButton;
    public event Action CloseButton;

    [SerializeField] GameObject PausePanel;
    [SerializeField] Text enemiesKilledText;

    public void Show(int enemiesKilled)
    {
        enemiesKilledText.text = "Enemies killed: " + enemiesKilled;
        PausePanel.SetActive(true);
    }

    public void Hide()
    {
        PausePanel.SetActive(false);
    }

    public void OnCloseButton() {
        if (CloseButton != null) {
            CloseButton();
        }
        Hide();
    }

    public void OnRestartButton()
    {
        if (RestartButton != null)
        {
            RestartButton();
        }
    }
}
