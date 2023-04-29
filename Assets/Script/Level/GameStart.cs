using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private bool _playOnStart;
    [SerializeField] private UIMenu _menu;
    [SerializeField] private UIMenu _deadMenu;
    [SerializeField] private CameraHolder _holder;
    [SerializeField] private Player _player;
    [SerializeField] private MapBulder _maps;

    private Vector3 _startPosition;

    private void Awake()
    {
        _player.SetBlock(true);
        Play();
        _startPosition = _player.transform.position;
    }

    private void Play()
    {
        _player.Play();
        _player.Reset();
        _holder.enabled = true;
        _maps.Play();
    }

    private void Stop()
    {
        _player.Stop();
        _holder.enabled = false;
        _maps.Stop();
    }

    public void StartGame()
    {
        _player.SetBlock(false);
        _menu.Hide();
    }

    public void Restart()
    {
        _holder.SetHeight(_startPosition.y);
        _player.transform.position = _startPosition;
        _deadMenu.Hide();
        _player.SetBlock(false);
        Play();
    }

    public void Dead()
    {
        Stop();
        _player.SetBlock(true);
        _deadMenu.Show();
    }

    public void MainMenu()
    {
        _menu.Show();
        _deadMenu.Hide();
        _holder.SetHeight(_startPosition.y);
        _player.transform.position = _startPosition;
        Play();
    }
}
