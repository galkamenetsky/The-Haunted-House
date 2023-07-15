using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private LevelData[] levels;

    private int currentLevel;

    public static LevelSelector Instance
    {
        get => instance;
        private set { }
    }
    private static LevelSelector instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);

    }
    public LevelData[] GetLevels() => levels;
    public LevelData GetCurrentLevel => levels[currentLevel];
    public void LoadLevel(int level)
    {
        currentLevel = level;
        SceneManager.LoadScene(1);
    }
    
}
