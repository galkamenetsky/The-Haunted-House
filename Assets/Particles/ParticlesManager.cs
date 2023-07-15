using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ParticlesManager : MonoBehaviour, ICoinLootedObeserver, IEnterDoorObserver, ITrapEnteredObserver, IKeyCollectObserver
{
    [Header("References")]
    [SerializeField] private Transform particleContainer;
  

    [Header("Prefabs")]
    [SerializeField] private ParticleSystem coinPraticlePrefab;
    [SerializeField] private ParticleSystem trapPraticlePrefab;
    [SerializeField] private ParticleSystem keyPraticlePrefab;
    [SerializeField] private ParticleSystem doorPraticlePrefab;

    //Pool Info
    [SerializeField] private int minCapacity;
    [SerializeField] private int maxCapacity;

    //Pools
    private ObjectPool<ParticleSystem> coinParticlePool;
    private ObjectPool<ParticleSystem> trapParticlePool;
    private ObjectPool<ParticleSystem> keyParticlePool;
    private ObjectPool<ParticleSystem> doorParticlePool;

    
    private void Awake()
    {
        coinParticlePool = InitPool(coinPraticlePrefab);
        trapParticlePool = InitPool(trapPraticlePrefab);
        keyParticlePool= InitPool(keyPraticlePrefab);
        doorParticlePool = InitPool(doorPraticlePrefab);
    }
    #region InitPool
    private ObjectPool<ParticleSystem> InitPool(ParticleSystem particle)
    {
        GameObject container = new GameObject(particle.name);
        container.transform.SetParent(particleContainer);

        return new ObjectPool<ParticleSystem>(() => {
            ParticleSystem p = Instantiate(particle, container.transform);
            return p;
        }, p => {
            p.gameObject.SetActive(true);
        }, p => {
            p.gameObject.SetActive(false);
        }, p => {
            Destroy(p.gameObject);
        }, true, minCapacity, maxCapacity);
    }

    #endregion

    #region Particle Execute
    public void OnCoinLooted(Coin coin) => PlayParticle(coinParticlePool.Get(), coin.transform.position);

    public void OnKeyCollected(Key key) => PlayParticle(keyParticlePool.Get(), key.transform.position);

    public void OnEnterDoor(Door door) => PlayParticle(doorParticlePool.Get(), door.transform.position);
    
    public void OnTrapEnterd(Trap trap) => PlayParticle(trapParticlePool.Get(), trap.transform.position);

    private void PlayParticle(ParticleSystem particle, Vector3 pos)
    {
        particle.transform.position = pos;
        particle.Play();
    }
    #endregion
}
