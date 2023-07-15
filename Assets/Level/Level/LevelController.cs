using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelManager manager;
    [SerializeField] private LootSystem lootSystem;
    [SerializeField] private PlayerLife playerLife;
    [SerializeField] private CinemachineFreeLook virtualCamera;
    [SerializeField] private ParticlesManager particlesManager;
    [SerializeField] private Trap levelBase;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private DoorOpenCutScene doorOpenCutScene;

    [Header("Containers")]
    [SerializeField] private Transform coinsContainer;
    [SerializeField] private Transform trapsContainer;
    [SerializeField] private Transform platformsContainer;

    [Header("Prefabs")]
    [SerializeField] private Door doorPrefab;
    [SerializeField] private Key keyPrefab;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private GameObject trapPrefab;
    [SerializeField] private GameObject platformPrefab;


    private Door door;
    private GameObject player;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerLife.SubscribeGameOver(manager);
        GenerateLevel(LevelSelector.Instance.GetCurrentLevel);
    }
    public void GenerateLevel(LevelData levelData)
    {
        levelBase.SubscribeTrapEntered(playerLife);

        CreateDoor(levelData.DoorInfo);
        CreateKey(levelData.KeyInfo);
        CreatePlayer(levelData.PlayerInfo);
        foreach (LevelItem item in levelData.CoinsInfo)
            CreateCoin(item);
        foreach (LevelItem item in levelData.TrapsInfo)
            CreateTrap(item);
        foreach (PlatformItem item in levelData.PlatformsInfo)
            CreatePlatform(item);
    }
    #region Door
    
    public void CreateDoor(LevelItem info)
    {
        door = Instantiate(doorPrefab);
        door.transform.position = info.position;
        door.transform.rotation = info.rotation;
        door.SubscribeDoorEntered(manager);
        door.SubscribeDoorEntered(particlesManager);
        doorOpenCutScene.SetDoor(door.transform);
    }
    #endregion

    #region Key
    public void CreateKey(LevelItem info)
    {
        Key key = Instantiate(keyPrefab);
        key.transform.position = info.position;
        key.transform.rotation = info.rotation;
        key.Subscribe(door);
        key.Subscribe(particlesManager);
        key.Subscribe(UIManager);
        key.Subscribe(doorOpenCutScene);
    }
    #endregion

    #region Player
    public void CreatePlayer(LevelItem info)
    {
        player = Instantiate(playerPrefab);
        player.transform.position = info.position;
        player.transform.rotation = info.rotation;
        virtualCamera.Follow = player.transform;
        virtualCamera.LookAt = player.transform;
    }
    #endregion

    #region Coins
    public void CreateCoin(LevelItem info)
    {
        Coin coin = Instantiate(coinPrefab,coinsContainer);
        coin.transform.position = info.position;
        coin.transform.rotation = info.rotation;
        coin.SubscribeCoinLooted(lootSystem);
        coin.SubscribeCoinLooted(particlesManager);
    }
    #endregion

    #region Traps
    public void CreateTrap(LevelItem info)
    {
        GameObject trapObject = Instantiate(trapPrefab, trapsContainer);
        trapObject.transform.position = info.position;
        trapObject.transform.rotation = info.rotation;
        PlayerHitAnimated playerHit = player.GetComponent<PlayerHitAnimated>();
        Trap trap = trapObject.GetComponentInChildren<Trap>();
        trap.SubscribeTrapEntered(playerHit);
        trap.SubscribeTrapEntered(playerLife);
        trap.SubscribeTrapEntered(particlesManager);
    }
    #endregion

    #region Platforms
    public void CreatePlatform(PlatformItem info)
    {
        GameObject platform = Instantiate(platformPrefab, platformsContainer);
        platform.transform.position = info.position;
        platform.transform.rotation = info.rotation;
        platform.transform.localScale = info.size;
    }
    #endregion
}
