using UnityEngine;

public class TransportSet : MonoBehaviour
{
    [SerializeField] private Player _user;
    [SerializeField] private AirBall _transport;

    public bool IsReady => !_transport;
    public Transform CurretParent { get; private set; }

    private void Awake()
    {
        CurretParent = transform;
    }

    public void Enter(AirBall ball)
    {
        _transport = ball;
        _transport.OnComplite += Exit;
        _transport.transform.localScale = _user.transform.localScale;
        _transport.transform.position = _user.transform.position;
        _transport.Use(_user);
        CurretParent = ball.transform;
    }

    public void Exit()
    {
        _transport.OnComplite -= Exit;
        CurretParent = transform;
        _transport = null;
    }
}
