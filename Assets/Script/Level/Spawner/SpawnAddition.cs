using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnAddition : MonoBehaviour
{
    [SerializeField] private Vector2 _spawnOffset;

    private List<PoolItem> _activeItem = new List<PoolItem>();

    protected event System.Action OnPlay;
    protected event System.Action OnReset;
    protected event System.Action OnUpdate;

    public abstract bool IsReady(int height);

    protected abstract PoolItem Create(int height);

    public void UpdateState()
    {
        OnUpdate?.Invoke();
    }

    public void Clear()
    {
        while (_activeItem.Count > 0)
        {
            _activeItem[0].Delete();
        }
        OnReset?.Invoke();
    }

    public PoolItem Spawn(List<PoolItem> platforms, int height)
    {
        var item = Create(height);
        var platform = GetPlatform(platforms);
        platform.SetItem(item.transform);
        item.OnDelete += ReturnEnemy;
        _activeItem.Add(item);
        OnPlay?.Invoke();
        return item;
    }


    private JumpPlatform GetPlatform(List<PoolItem> platforms)
    {
        if (platforms.Count == 1)
            return platforms[0].GetComponent<JumpPlatform>();
        var max = platforms[0];
        for (int i = 1; i < platforms.Count; i++)
        {
            if (platforms[i].transform.position.y > max.transform.position.y)
            {
                max = platforms[i];
            }
        }
        return max.GetComponent<JumpPlatform>();
    }

    private void ReturnEnemy(PoolItem enemy)
    {
        enemy.OnDelete -= ReturnEnemy;
        _activeItem.Remove(enemy);
    }
}
