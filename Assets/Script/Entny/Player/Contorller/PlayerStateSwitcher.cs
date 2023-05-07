using UnityEngine;

public class PlayerStateSwitcher : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CameraHolder _holder;

    private Vector3 _startPosition;

    private void Awake()
    {
        _player.SetBlock(true);
        _startPosition = _player.transform.position;
    }

    public void Play()
    {
        _player.transform.position = _startPosition;
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
        _holder.SetHeight(_startPosition.y);
    }

}
