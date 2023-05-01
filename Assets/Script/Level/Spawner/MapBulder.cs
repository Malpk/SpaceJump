using System.Collections.Generic;
using UnityEngine;

public class MapBulder : MonoBehaviour
{
    [SerializeField] private float _spawnAdditionProbility;
    [SerializeField] private float _startHeight = -3;
    [SerializeField] private float _spawnDistance = 3f;
    [SerializeField] private float _heightSteap = 6f;
    [SerializeField] private float _deleteDistance = 5f;
    [Header("SpawnerReference")]
    [SerializeField] private Vector2 _heightOffset;
    [SerializeField] private SpawnPoint[] _offsetsX;
    [SerializeField] private ItemHolder _poolHolder;
    [SerializeField] private SpawnAddition[] _spawners;
    [Header("Reference")]
    [SerializeField] private Player _player;

    private float _curretHeaight;

    private List<PoolItem> _platforms = new List<PoolItem>();

    private void Awake()
    {
        _curretHeaight = _startHeight;
    }

    private void OnValidate()
    {
        _spawnDistance = _spawnDistance > 3 ? _spawnDistance : 3f;
    }

    public void Play()
    {
        enabled = true;
        _curretHeaight = 0f;
        _curretHeaight = _startHeight;
        foreach (var spawner in _spawners)
        {
            spawner.Clear();
        }
        while (_platforms.Count > 0)
        {
            _platforms[0].Delete();
        }
    }

    public void Stop()
    {
        enabled = false;
    }

    private void Update()
    {
        var distance = Mathf.Abs(_player.transform.position.y - _curretHeaight);
        if (distance < _spawnDistance)
        {
            var rangePoints = _offsetsX[Random.Range(0, _offsetsX.Length)].RangsPosition;
            var list = new List<PoolItem>();
            foreach (var range in rangePoints)
            {
                var platform = CreatePlatform();
                platform.transform.position = GetPosition(range);
                list.Add(platform);
            }
            SpawnAddition(list);
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
                    Spawn(platforms, (int)_curretHeaight);
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
            if (spawn.IsReady)
            {
                list.Add(spawn);
            }
        }
        return list.Count > 0;
    }

    private PoolItem CreatePlatform()
    {
        var platform = _poolHolder.GetPool(_player.Height).
            Create(transform);
        platform.OnDelete += DeleteJumpPlatform;
        _platforms.Add(platform);
        return platform;
    }

    private Vector2 GetPosition(Vector2 range)
    {
        _curretHeaight += _heightSteap +
            Random.Range(_heightOffset.x, _heightOffset.y);
        var up = Vector2.up * _curretHeaight;
        var right = Vector2.right * Random.Range(range.x, range.y);
        return up + right;
    }

    private void DeleteJumpPlatform(PoolItem platform)
    {
        platform.OnDelete -= DeleteJumpPlatform;
        _platforms.Remove(platform);
    }
}
