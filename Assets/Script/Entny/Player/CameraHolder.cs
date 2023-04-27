using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private bool _freeFly;
    [Range(0,1f)]
    [SerializeField] private float _smoothTime;
    [Header("Reference")]
    [SerializeField] private Player _player;

    private float _curretPosition;
    private float _velocity;
    public System.Action State;

    private void Awake()
    {
        if (_freeFly)
            State = SetFollowingPlayer;
        else
            State = SetUp;
    }

    private void OnValidate()
    {
        if(_player)
            _curretPosition = _player.transform.position.y;
        Awake();

    }

    public void SetHeight(float height)
    {
        _curretPosition = height;
        transform.position = new Vector2(transform.position.x, _curretPosition);
    }

    public void UpdateHeight(float height)
    {
        _curretPosition = height;
    }

    private void LateUpdate()
    {
        var target = Mathf.SmoothDamp(transform.position.y,
                    _curretPosition, ref _velocity, _smoothTime);
        target = target < transform.position.y ? transform.position.y : target;
        transform.position = new Vector2(transform.position.x, target);
    }

    public void SetFollowingPlayer()
    {
        State = StateFollowing;
    }

    public void SetUp()
    {
        State = StateUp;
    }

    private void StateFollowing()
    {
        var target = Mathf.SmoothDamp(transform.position.y,
            _player.transform.position.y, ref _velocity, _smoothTime);
        transform.position = new Vector2(transform.position.x, target);
    }
    private void StateUp()
    {
        
    }

}
