using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform levelsContainer;
    [SerializeField] private Animator title;

    [Header("Prefabs")]
    [SerializeField] private TextButton uiLevelButton;

    [Header("Parameters")]
    [SerializeField] private float titleDimmRate = 3f;
    void Start()
    {
        GenerateLevelsButtons();
        AnimateUI();
    }

    private void GenerateLevelsButtons()
    {
        LevelData[] levelsData = LevelSelector.Instance.GetLevels();
        for(int i = 0; i < levelsData.Length; i++)
        {
            TextButton button = Instantiate(uiLevelButton, levelsContainer);
            int levelIndex = i;
            button.AddListener(() => LevelSelector.Instance.LoadLevel(levelIndex));
            button.Text = levelsData[i].levelName;
        }
    }
    private void AnimateUI()
    {
        InvokeRepeating("DimmTitle", 0, titleDimmRate);
       
    }
    private void DimmTitle()
    {
        title.SetTrigger("Dimming");
    }
}
