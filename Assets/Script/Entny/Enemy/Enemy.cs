using UnityEngine;

[RequireComponent(typeof(PoolItem))]
public class Enemy : MonoBehaviour, IMapItem
{
    [SerializeField] private float _deltaSpeed;
    [SerializeField] private float _distance;
    [Header("Reference")]
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private SpriteRenderer _spriteRender;

    private int _direction;
    private int[] _directions = new int[] { -1, 1 };
    private float _trigerDitance = 0.05f; 
    private Vector2 _targetPosition;
    private PoolItem _item;

    private void Awake()
    {
        _item = GetComponent<PoolItem>();
    }

    public void Play()
    {
        _direction = _directions[Random.Range(0, _directions.Length)];
        var offset = Vector2.right * _direction * _distance;
        SetTarget();
        _rigidBody.MovePosition(offset + Vector2.up * _rigidBody.position.y);
        enabled = true;
    }
    public void Stop()
    {
        enabled = false;
    }

    private void Update()
    {
        _rigidBody.MovePosition(Vector2.MoveTowards(_rigidBody.position, 
            _targetPosition, _deltaSpeed));
        if (_trigerDitance >= Vector2.Distance(_rigidBody.position, _targetPosition))
        {
            _direction = -_direction;
            SetTarget();
        }
    }

    private void SetTarget()
    {
        _spriteRender.flipX = _direction < 0;
        _targetPosition = Vector2.right * _direction * _distance + Vector2.up * transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.Dead();
        }
    }

    public void Delete()
    {
        _item.Delete();
    }
}
