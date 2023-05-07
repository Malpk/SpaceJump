using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnAdditionProbility;
    [Header("Reference")]
    [SerializeField] private MapBulder _mapBuilder;
    [SerializeField] private SpawnAddition[] _spawners;

    public void ClearMap()
    {
        _mapBuilder.Clear();
        foreach (var spawner in _spawners)
        {
            spawner.Clear();
        }
    }

    public void Play()
    {
        enabled = true;
    }

    public void Stop()
    {
        enabled = false;
    }

    private void Update()
    {
        var platforms = _mapBuilder.Spawn();
        if (platforms.Count > 0)
        {
            SpawnAddition(platforms);
        }
    }


    private bool SpawnAddition(List<PoolItem> platforms)
    {
        UpdateSapawners();
        if (TryGetReadySpawners(out List<SpawnAddition> spawns))
        {
            var probility = Random.Range(0f, 1f);
            if (probility <= _spawnAdditionProbility)
            {
                spawns[Random.Range(0, spawns.Count)].
                    Spawn(platforms, _mapBuilder.Height);
                return true;
            }
        }
        return false;
    }

    private void UpdateSapawners()
    {
        foreach (var spawner in _spawners)
        {
            spawner.UpdateState();
        }
    }

    private bool TryGetReadySpawners(out List<SpawnAddition> list)
    {
        list = new List<SpawnAddition>();
        foreach (var spawn in _spawners)
        {
            if (spawn.IsReady(_mapBuilder.Height))
            {
                list.Add(spawn);
            }
        }
        return list.Count > 0;
    }
}
