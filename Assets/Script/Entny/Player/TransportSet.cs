using UnityEngine;

public class TransportSet : MonoBehaviour
{
    [SerializeField] private Player _user;
    [SerializeField] private SpriteRenderer _playerBody;
    [SerializeField] private AirBall _transport;

    public void Enter(AirBall ball)
    {
        _transport = ball;
        _transport.OnComplite += Exit;
        ball.transform.localScale = 
            new Vector3(_playerBody.flipX ? 1 : -1, 1, 1);
        ball.transform.position = _user.transform.position;
        _transport.Use(_user);
    }

    public void Exit()
    {
        _transport.OnComplite -= Exit;
        _transport = null;
    }
}
