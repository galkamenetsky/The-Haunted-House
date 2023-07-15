using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class LevelGeneratorMenu : EditorWindow
{
    private static readonly string path = "Assets/Levels/";
    private static string levelName = "Level #";

    [MenuItem("Level Generator/Generate Level")]
    public static void Init()
    {
        LevelGeneratorMenu window = (LevelGeneratorMenu)EditorWindow.GetWindow(typeof(LevelGeneratorMenu));
        window.Show();
    }
    public static void GenerateLevel()
    {
        LevelData levelData = LevelData.CreateInstance<LevelData>();

        levelData.levelName = levelName;
        //Read Platforms
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        int platformsCount = platforms.Length;

        levelData.PlatformsInfo = new PlatformItem[platformsCount];
        for (int i = 0; i < platformsCount; i++)
        {
            levelData.PlatformsInfo[i] = new PlatformItem(platforms[i].transform.position, platforms[i].transform.rotation, platforms[i].transform.localScale);
        }

        //Read Coins
        Coin[] coins = GameObject.FindObjectsOfType<Coin>();
        int coinsCount = coins.Length;

        levelData.CoinsInfo = new LevelItem[coinsCount];
        for (int i = 0; i < coinsCount; i++)
        {
            levelData.CoinsInfo[i] = new LevelItem(coins[i].transform.position, coins[i].transform.rotation);
        }

        //Read Traps
        GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");
        int trapsCount = traps.Length;

        levelData.TrapsInfo = new LevelItem[trapsCount];
        for (int i = 0; i < trapsCount; i++)
        {
            levelData.TrapsInfo[i] = new LevelItem(traps[i].transform.position, traps[i].transform.rotation);
        }

        //Read Door
        Door[] door = FindObjectsOfType<Door>();
        if (door.Length != 1)
            throw new System.Exception("Must have 1 door in a level");
        levelData.DoorInfo = new LevelItem(door[0].transform.position, door[0].transform.rotation);

        //Read Key
        Key[] key = FindObjectsOfType<Key>();
        if (key.Length != 1)
            throw new System.Exception("Must have 1 key in a level");
        levelData.KeyInfo = new LevelItem( key[0].transform.position, key[0].transform.rotation);

        //Read Player
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        if (player.Length != 1)
            throw new System.Exception("Must have 1 player in a level");
        levelData.PlayerInfo = new LevelItem( player[0].transform.position, player[0].transform.rotation);


        string soPath = path + levelName + ".asset";
        EditorUtility.SetDirty(levelData);
        AssetDatabase.CreateAsset(levelData, soPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = levelData;
    }
    void OnGUI()
    {
        GUILayout.Label("Create Level", EditorStyles.boldLabel);
        levelName = EditorGUILayout.TextField("Level Name", levelName);

        if (GUILayout.Button("Generate Level"))
        {
            if (Directory.EnumerateFiles(path).Any(f => f.Contains(levelName)))
                throw new System.Exception("There is already a level with the same name in folder " + path);
            else
                GenerateLevel();
        }
        if (GUILayout.Button("Edit Level"))
        {
            if (Directory.EnumerateFiles(path).Any(f => f.Contains(levelName)))
                throw new System.Exception("There is already a level with the same name in folder " + path);
            else
                GenerateLevel();
        }
    }

}
#endif
