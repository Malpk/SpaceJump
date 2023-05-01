using UnityEngine;

[System.Serializable]
public class ItemCounter
{
    [SerializeField] private int _spawnCount;
    [SerializeField] private Pool _pool;

    private int _count;

    public Pool Pool => _pool;

    public void Reset()
    {
        _count = _spawnCount;
    }

    public PoolItem Spawn(Transform parent = null)
    {
        _count = 0;
        return _pool.Create(parent);
    }

    public bool UpdateCount()
    {
        _count++;
        return _count >= _spawnCount;
    }


}
