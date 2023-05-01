using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private bool _playOnStart;
    [SerializeField] private float _distanceSide;
    [SerializeField] private float _JumpHeight;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private UnityEvent OnDead;
    [Header("Reference")]
    [SerializeField] private JumpScore _score;
    [SerializeField] private GravitySet _gravitySet;
    [SerializeField] private PlayerMovement _movement;

    private bool _isPlay;
    public int Height => _score.CurreHeight;


    private void Start()
    {
        if (_playOnStart)
            SetBlock(false);
        _score.SetStartPosition(transform.position.y);
    }

    public void Play()
    {
        enabled = true; 
    }

    public void Stop()
    {
        enabled = false;
        _movement.BreakJump();
    }

    public void Reset()
    {
        _score.Reset();
        _gravitySet.Reset();
    }

    public void SetBlock(bool block)
    {
        _isPlay = !block;
    }

    private void Update()
    {
        if (_distanceSide < Mathf.Abs(transform.position.x))
        {
            var direction = -transform.position.x / Mathf.Abs(transform.position.x);
            transform.position = new Vector2(direction * (_distanceSide - 1), transform.position.y);
        }
    }
    
    private void FixedUpdate()
    {
        var x = _isPlay ? Input.GetAxis("Horizontal") : 0;
        _movement.Move(x);
        if(_gravitySet.IsGround)
            Jump(_JumpHeight, _jumpDuration);
    }

    public void SetSpriteDirection(float direction)
    { 
    }

    public void Jump(float height, float duration)
    {
        _movement.Jump(height, duration);
    }

    public void Dead()
    {
        if (_isPlay)
        {
            OnDead?.Invoke();
        }
    }
}
