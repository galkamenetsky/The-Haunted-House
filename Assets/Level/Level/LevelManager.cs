using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IEnterDoorObserver, IGameOverObserver
{
    [SerializeField] private UIManager UIManager;
   
    private void Start()
    {
        UIManager.BackToMenu += LoadMainMenu;
        UIManager.RestartLevel += ReloadLevel;
    }
    public void OnLevelLost()
    {
        LevelOver(false);
    }

    public void OnEnterDoor(Door door)
    {
        LevelOver(true);
    }

    private void ReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
    private void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    private void LevelOver(bool isWin)
    {
        UIManager.LoadWindow(isWin);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
}
