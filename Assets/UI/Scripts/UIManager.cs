using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IKeyCollectObserver
{
    [Header("References")]
    [Header("Top Bar")]
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text keyText;
    [SerializeField] private Slider lifeRemains;
    [Header("Level Ends")]
    [SerializeField] private GameObject levelEndsWindow;
    [SerializeField] private TMP_Text levelOverMsg;
    [SerializeField] private string levelWinText;
    [SerializeField] private string levelLostText;
    [SerializeField] private Color winColor;
    [SerializeField] private Color lostColor;
    [SerializeField] private Button backToMainMenuButton;
    [SerializeField] private Button restartLevelButton;


    public event Action BackToMenu;
    public event Action RestartLevel;
    private void Start()
    {
        backToMainMenuButton.onClick.AddListener(() => BackToMenu?.Invoke());
        restartLevelButton.onClick.AddListener(() => RestartLevel?.Invoke());
    }
    public void SetCoinsCount(int coins)
    {
        coinsText.text = coins.ToString();
    }

    public void OnKeyCollected(Key key) => keyText.text = "1";

    public void SetLifeRemains(int life)
    {
        lifeRemains.value = life;
    }

    private void LoadLostMenu()
    {
        levelOverMsg.text = levelLostText;
        levelOverMsg.color = lostColor;
        levelEndsWindow.SetActive(true);
    }

    private void LoadWinMenu()
    {
        levelOverMsg.text = levelWinText;
        levelOverMsg.color = winColor;
        levelEndsWindow.SetActive(true);
    }
    public void LoadWindow(bool win)
    {
        if (win)
            LoadWinMenu();
        else
            LoadLostMenu();
    }

   
}
