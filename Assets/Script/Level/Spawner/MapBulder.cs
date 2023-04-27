using System.Collections.Generic;
using UnityEngine;

public class MapBulder : MonoBehaviour
{
    [SerializeField] private float _startHeight = -3;
    [SerializeField] private float _spawnDistance = 3f;
    [SerializeField] private float _heightSteap = 6f;
    [SerializeField] private float _deleteDistance = 5f;
    [SerializeField] private SpawnPoint[] _offsetsX;
    [SerializeField] private ItemHolder _poolHolder;
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Vector2 _heightOffset;
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
        _spawner.Clear();
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
            _spawner.Spawn(list,(int)_curretHeaight);
        }
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
