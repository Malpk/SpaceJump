using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private bool _playOnStart;
    [SerializeField] private UIMenu _menu;
    [SerializeField] private UIMenu _deadMenu;
    [SerializeField] private CameraHolder _holder;
    [SerializeField] private Player _player;
    [SerializeField] private MainSpawner _maps;
    [SerializeField] private JumpScore _score;

    private Vector3 _startPosition;

    private void Awake()
    {
        _player.SetBlock(true);
        _startPosition = _player.transform.position;
        Play();
    }

    private void Play()
    {
        _player.transform.position = _startPosition;
        _player.Reset();
        _score.Reset();
        _holder.enabled = true;
        _player.Play();
        _maps.Play();
    }

    private void Stop()
    {
        _holder.enabled = false;
        _player.Stop();
        _maps.Stop();
    }

    public void StartGame()
    {
        _player.SetBlock(false);
    }

    public void Restart()
    {
        _holder.SetHeight(_startPosition.y);
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
        Play();
    }
}
