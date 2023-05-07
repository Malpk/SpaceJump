using UnityEngine;

public class DeadMenu : UIMenu
{
    [SerializeField] private GameStart _gameController;
    [SerializeField] private JumpScore _score;
    [SerializeField] private BordResult _result;
    [SerializeField] private GameSession _session;

    public void ShowDead()
    {
        _result.SetRecord(_score.Score);
        _result.SetMoney(_session.TakeMoney);
        Show();
    }

    public void BackMainMenu()
    {
        ShowMenu(MenuType.MainMenu);
        _gameController.BackMainMenu();
    }

    public void Restart()
    {
        ShowMenu(MenuType.HUD);
        _gameController.Restart();
    }
}
