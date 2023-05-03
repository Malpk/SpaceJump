using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _border;
    [SerializeField] private float _height;
    [SerializeField] Transform _targets;


    private int _direction = 1;
    private int[] _directions = new int[] { -1, 1 };
    private Vector2 _target;
    private Vector2 _curretPosition;

    private void Start()
    {
        _direction = _directions[Random.Range(0, _directions.Length)];
        _curretPosition = Vector2.right * transform.position.x;
        SetTarget();
    }

    public void FixedUpdate()
    {
        _curretPosition = Vector2.MoveTowards(_curretPosition, _target, 
            _speed * Time.fixedDeltaTime);
        transform.up = _curretPosition - (Vector2)transform.position;
        _targets.transform.position = _curretPosition;
        if (_curretPosition == _target)
        {
            SetTarget();
        }
    }

    private void SetTarget()
    {
        var y = transform.position.y + _height;
        var x = _border * -_direction;
        _target = new Vector2(x, y);
        _curretPosition = new Vector2(_curretPosition.x,y);
        _direction = -_direction;
    }
}
