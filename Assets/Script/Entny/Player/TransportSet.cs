using UnityEngine;

public class TransportSet : MonoBehaviour
{
    [SerializeField] private Player _user;
    [SerializeField] private AirBall _transport;

    public void Enter(AirBall ball)
    {
        _transport = ball;
        _transport.Use();
        _transport.OnComplite += Exit;
        _user.Stop();
        _user.SetBlock(true);
        ball.transform.position = _user.transform.position;
        _user.transform.parent = ball.transform;

    }

    public void Exit()
    {
        _transport.OnComplite -= Exit;
        _transport = null;
        _user.transform.parent = null;
        _user.Play();
        _user.SetBlock(false);
    }
}
