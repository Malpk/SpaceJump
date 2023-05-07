using System.Collections.Generic;
using UnityEngine;

public class MapBulder : MonoBehaviour
{
    [SerializeField] private int _startHeight = -3;
    [SerializeField] private int _heightSteap = 6;
    [SerializeField] private int _mapRadius = 20;
    [SerializeField] private float _jumpDistance = 10f;
    [SerializeField] private float _spawnDistance = 3f;
    [Header("SpawnerReference")]
    [SerializeField] private Vector2 _heightOffset;
    [SerializeField] private SpawnPoint[] _offsetsX;
    [SerializeField] private ItemHolder _poolHolder;
    [Header("Reference")]
    [SerializeField] private Player _player;
    [SerializeField] private JumpScore _score;

    private float _curretPositionX = 0;
    private List<PoolItem> _platforms = new List<PoolItem>();
    public int Height { get; private set; }

    public void Clear()
    {
        Height = _startHeight;
        _curretPositionX = 0f;
        while (_platforms.Count > 0)
        {
            _platforms[0].Delete();
        }
    }

    public List<PoolItem> Spawn()
    {
        var distance = Mathf.Abs(_player.transform.position.y -Height);
        var list = new List<PoolItem>();
        if (distance < _spawnDistance)
        {
            var rangePoints = _offsetsX[Random.Range(0, _offsetsX.Length)].RangsPosition;
            foreach (var range in rangePoints)
            {
                var platform = CreatePlatform();
                platform.transform.position = GetPosition(range);
                list.Add(platform);
            }
        }
        return list;
    }

    private PoolItem CreatePlatform()
    {
        var platform = _poolHolder.GetPool(_score.CurreHeight).
            Create(transform);
        platform.OnDelete += DeleteJumpPlatform;
        _platforms.Add(platform);
        return platform;
    }

    private Vector2 GetPosition(Vector2 range)
    {
        Height += _heightSteap +
            (int)Random.Range(_heightOffset.x, _heightOffset.y);
        var x = Random.Range(range.x, range.y) / (_mapRadius * 2);
        x *= _jumpDistance * 2;
        x -= _curretPositionX;
        x = Mathf.Clamp(x, -_mapRadius, _mapRadius);
        if (_curretPositionX + _jumpDistance > _mapRadius)
            _curretPositionX -= _jumpDistance;
        else if (_curretPositionX - _jumpDistance < -_mapRadius)
            _curretPositionX += _jumpDistance;
        else
            _curretPositionX = x + Random.Range(-_jumpDistance, _jumpDistance);
        return Vector2.up * Height + Vector2.right * x;
    }

    private void DeleteJumpPlatform(PoolItem platform)
    {
        platform.OnDelete -= DeleteJumpPlatform;
        _platforms.Remove(platform);
    }
}
