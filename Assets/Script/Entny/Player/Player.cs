using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private bool _playOnStart;
    [SerializeField] private float _JumpHeight;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private UnityEvent OnDead;
    [Header("Reference")]
    [SerializeField] private GravitySet _gravitySet;
    [SerializeField] private PlayerSound _sound;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private PlayerMovement _movement;

    public bool IsPlay { get; private set; }


    private void Start()
    {
        if (_playOnStart)
            SetBlock(false);
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
        _gravitySet.Reset();
    }

    public void SetBlock(bool block)
    {
        IsPlay = !block;
    }

    public void TakeMoney(int money)
    {
        _wallet.TakeMoney(money);
        _sound.TakeMoney();
    }

    private void FixedUpdate()
    {
        var x = IsPlay ? Input.GetAxis("Horizontal") : 0;
        _movement.Move(x);
        SetDirection(x);
        if (_gravitySet.IsGround)
            Jump(_JumpHeight, _jumpDuration);
    }
    public void SetDirection(float direction)
    {
        if (direction != 0)
        {
            var x = direction > 0 ? -1 : 1;
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        }
    }
    public void Jump(float height, float duration)
    {
        if (_movement.Jump(height, duration))
        {
            _sound.Jump();
        }
    }

    public void Dead()
    {
        if (IsPlay)
        {
            OnDead?.Invoke();
        }
    }
}
