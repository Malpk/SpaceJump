using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private bool _playOnStart;
    [SerializeField] private DataSaver _saver;
    [SerializeField] private JumpScore _score;
    [SerializeField] private MainSpawner _maps;
    [SerializeField] private AdsController _ads;
    [SerializeField] private PlayerStateSwitcher _player;

    private void Start()
    {
        Play();
    }

    private void Play()
    {
        _player.Play();
        _score.Reset();
        _maps.Play();
    }

    private void Stop()
    {
        _player.Stop();
        _maps.Stop();
    }


    public void Restart()
    {
        _player.Reset();
        _ads.Reset();
        _maps.ClearMap();
        Play();
        _player.StartGame();
    }

    public void ReturnGame()
    {
        Play();
        _player.SetLastPosition();
        _player.StartGame();
    }

    public void Dead()
    {
        Stop();
        _saver.Save();
    }

    public void BackMainMenu()
    {
        _player.Reset();
        _ads.Reset();
        _maps.ClearMap();
        Play();
    }
}
