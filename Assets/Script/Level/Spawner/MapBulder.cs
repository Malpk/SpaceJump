using System.Collections.Generic;
using UnityEngine;

public class MapBulder : MonoBehaviour
{
    [SerializeField] private int _startHeight = -3;
    [SerializeField] private int _heightSteap = 6;
    [SerializeField] private int _mapRadius = 20;
    [SerializeField] private int _countPlatform = 3;
    [SerializeField] private float _spawnDistance = 3f;
    [SerializeField] private Vector2 _jumpDistance;
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

    private void Update()
    {
    }

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
            var positions = CutLine(new Vector2(0, _mapRadius*2));
            Height += _heightSteap;
            foreach (var position in positions)
            {
                var platform = CreatePlatform();
                var upPosition = Height + (int)Random.Range(_heightOffset.x, _heightOffset.y);
                platform.transform.position = position + Vector2.up * upPosition;
                list.Add(platform);
            }
            Height += (int)_heightOffset.y;
        }
        return list;
    }

    public List<Vector2> CutLine(Vector2 line)
    {
        var steap = Random.Range(_jumpDistance.x, _jumpDistance.y)+1f;
        var list = new List<Vector2>();
        var position = Random.Range(line.x, line.y);
        list.Add(Vector2.right * (position - _mapRadius));
        if (Mathf.Abs(line.y - position) >= steap)
            list.AddRange(CutLine(new Vector2(position + steap, line.y)));
        if (Mathf.Abs(line.x - position) >= steap)
            list.AddRange(CutLine(new Vector2(line.x, position - steap)));
        return list;
    }

    public Vector2 GetPlatform(Vector2 position)
    {
        if (_platforms.Count > 0)
        {
            var platformPosition = _platforms[0].transform.position;
            var distance = Vector2.Distance(position, platformPosition);
            foreach (var platform in _platforms)
            {
                var newDistance = Vector2.Distance(position, platform.transform.position);
                if (distance > newDistance)
                {
                    distance = newDistance;
                    platformPosition = platform.transform.position;
                }
            }
            return platformPosition;
        }
        return Vector2.zero;
    }

    private PoolItem CreatePlatform()
    {
        var platform = _poolHolder.GetPool(_score.CurreHeight).
            Create(transform);
        platform.OnDelete += DeleteJumpPlatform;
        _platforms.Add(platform);
        return platform;
    }

    private void DeleteJumpPlatform(PoolItem platform)
    {
        platform.OnDelete -= DeleteJumpPlatform;
        _platforms.Remove(platform);
    }
}
