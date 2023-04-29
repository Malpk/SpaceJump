using UnityEngine;

public class AirBall : MonoBehaviour
{
    [SerializeField] private float _timeActive = 1f;
    [SerializeField] private float _upSpeed = 1f;
    [SerializeField] private float _moveSpeed = 5f;
    [Header("Reference")]
    [SerializeField] private Rigidbody2D _rigidBody;

    private float _progress = 0f;
    private Vector3 _startScale;
    
    public event System.Action OnComplite;

    private void OnValidate()
    {
        _timeActive = _timeActive > 1 ? _timeActive : 1;
        _upSpeed = _upSpeed > 1 ? _upSpeed : 1;
        _moveSpeed = _moveSpeed > 5 ? _moveSpeed : 5;
    }

    private void Awake()
    {
        enabled = false;
    }

    public void Use()
    {
        enabled = true;
        _progress = 0f;
        _startScale = transform.localScale;
    }

    public void Complite()
    {
        enabled = false;
        gameObject.SetActive(false);
        transform.localScale = _startScale;
        OnComplite?.Invoke();
    }

    private void FixedUpdate()
    {
        _progress += Time.fixedDeltaTime / _timeActive;
        Move(Input.GetAxis("Horizontal"));
        if (_progress >= 1f)
        {
            Complite();
        }
    }

    private void Move(float direction)
    {
        var move = Vector2.right * _moveSpeed * direction + Vector2.up * _upSpeed;
        _rigidBody.MovePosition(_rigidBody.position + move * Time.fixedDeltaTime);
        if (direction != 0)
        {
            var directionInt = direction > 0 ? 1 : -1;
            transform.localScale = new Vector3(_startScale.x * directionInt,
                _startScale.y, _startScale.z);
        }
    }
}
