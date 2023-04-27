using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _spawnOffset;
    [SerializeField] private Pool _enemyPool;
    [SerializeField] private ItemHolder _enemyHolder;

    private bool[] _spawns = new bool[] { true,false, false, false, false, false, false, false };

    private List<PoolItem> _enemys = new List<PoolItem>();

    public void Clear()
    {
        while (_enemys.Count > 0)
        {
            _enemys[0].Delete();
        }
    }

    public void Spawn(List<PoolItem> platforms, int height)
    {
        if (_spawns[Random.Range(0, _spawns.Length)])
        {
            var item = _enemyHolder.GetPool(height).Create();
            item.OnDelete += ReturnEnemy;
            _enemys.Add(item);
            var enemy = item.GetComponent<EnemyMovement>();
            enemy.transform.position = GetPosition(platforms) + _spawnOffset;
            enemy.Play();
        }
    }

    private Vector2 GetPosition(List<PoolItem> platforms)
    {
        if (platforms.Count == 1)
            return platforms[0].transform.position;
        Vector2 max = platforms[0].transform.position;
        for (int i = 1; i < platforms.Count; i++)
        {
            if (platforms[i].transform.position.y > max.y)
            {
                max = platforms[i].transform.position;
            }
        }
        return max;
    }

    private void ReturnEnemy(PoolItem enemy)
    {
        enemy.OnDelete -= ReturnEnemy;
        _enemys.Remove(enemy);
    }
}
