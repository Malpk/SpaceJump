using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMovement = 5;
    [SerializeField] private AnimationCurve _JumpCurve;
    [SerializeField] private AudioClip _jumpSound;
    [Header("Events")]
    [SerializeField] private UnityEvent<float> _onJump;
    [Header("Reference")]
    [SerializeField] private AudioSource _source;
    [SerializeField] private GravitySet _gravity;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private SpriteRenderer _sprite;

    private bool _isJump;
    private float _jumpDuration = 1f;
    private float _jumpHeight = 2f;
    private float _startHeight;
    private float _jumpProgress = 0f;

    private System.Action<float> _curretState;

    private void Awake()
    {
        BreakJump();
    }

    public void BreakJump()
    {
        _isJump = false;
        _curretState = MoveState;
    }

    public void Jump(float height, float duration)
    {
        if (!_isJump)
        {
            _isJump = true;
            _jumpProgress = 0f;
            _jumpHeight = height;
            _jumpDuration = duration;
            _startHeight = _rigidBody.position.y;
            _onJump.Invoke(_startHeight + height);
            _curretState = MoveJumpState;
            _source.PlayOneShot(_jumpSound);
        }
    }

    public void Move(float move)
    {
        if (move != 0)
        {
            _sprite.flipX = move > 0;
        }
        _curretState(move);
    }

    private void MoveJumpState(float move)
    {
        _jumpProgress = Mathf.Clamp01(_jumpProgress + 
            Time.fixedDeltaTime / _jumpDuration);
        var x = _rigidBody.position.x + _speedMovement * move * Time.fixedDeltaTime;
        var y = _startHeight + _jumpHeight * _JumpCurve.Evaluate(_jumpProgress);
        _rigidBody.MovePosition(new Vector2(x, y));
        if (_jumpProgress >= 1f)
        {
            _gravity.Reset();
            _gravity.UpdateGravity();
            BreakJump();
        }
    }

    private void MoveState(float input)
    {
        var move = Vector2.right * _speedMovement * input * Time.fixedDeltaTime;
        _gravity.UpdateGravity();
        move += Vector2.down * GetScale();
        _rigidBody.MovePosition(_rigidBody.position + move);
    }

    private float GetScale()
    {
        if (_gravity.Contact)
        {
            var y = _rigidBody.position.y - _gravity.Contact.point.y;
            if (_gravity.GravityScale * Time.fixedDeltaTime >= y)
                return y;
        }
        return _gravity.GravityScale * Time.fixedDeltaTime;
    }
}
