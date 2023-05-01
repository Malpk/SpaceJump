using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : SpawnAddition
{
    [SerializeField] private ItemCounter[] _ites;

    private List<Pool> _pools;

    public override bool IsReady => _pools.Count > 0;

    private void OnEnable()
    {
        OnUpdate += UpdateItems;
        OnReset += Reset;
    }

    private void OnDisable()
    {
        OnUpdate -= UpdateItems;
        OnReset -= Reset;
    }

    protected override PoolItem Create(int height)
    {
        return _pools[Random.Range(0, _pools.Count)].Create();
    }

    private void UpdateItems()
    {
        _pools = new List<Pool>();
        foreach (var item in _ites)
        {
            if (item.UpdateCount())
            {
                _pools.Add(item.Pool);
            }
        }
    }

    private void Reset()
    {
        foreach (var item in _ites)
        {
            item.Reset();
        }
    }

}
