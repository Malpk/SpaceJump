using UnityEngine;

public class EnemySpawner : SpawnAddition
{
    [SerializeField] private float _probilitySpawn = 0.1f;
    [SerializeField] private ItemHolder _enemyHolder;

    private EnemyMovement _curretSpawn;

    public override bool IsReady => true;

    protected override PoolItem Create(int height)
    {
        var item = _enemyHolder.GetPool(height).Create();
        _curretSpawn = item.GetComponent<EnemyMovement>();
        OnPlay += PlaySpawn;
        return item;
    }

    private void PlaySpawn()
    {
        OnPlay -= PlaySpawn;
        _curretSpawn.Play();
        _curretSpawn = null;
    }

}
