using UnityEngine;

public class PlayerStateSwitcher : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameSession _session;
    [SerializeField] private MapBulder _map;
    [SerializeField] private CameraHolder _holder;

    private Vector3 _startPosition;

    private void Awake()
    {
        _player.SetBlock(true);
        _startPosition = _player.transform.position;
    }

    public void Play()
    {
        _player.Reset();
        _player.Play();
        _holder.enabled = true;
    }
    public void Stop()
    {
        _holder.enabled = false;
        _player.Stop();
        _player.SetBlock(true);
    }

    public void StartGame()
    {
        _player.SetBlock(false);
    }

    public void Reset()
    {
        _player.transform.position = _startPosition;
        _session.Reset();
        _holder.SetHeight(_startPosition.y);
    }

    public void SetLastPosition()
    {
        _player.transform.position = _map.GetPlatform(_player.transform.position)
            + Vector2.up * 3f;
        _holder.SetHeight(_player.transform.position.y);
    }

}
