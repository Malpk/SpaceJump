using UnityEngine;

public class DeadMenu : UIMenu
{
    [SerializeField] private GameStart _gameController;
    [SerializeField] private JumpScore _score;
    [SerializeField] private BordResult _result;
    [SerializeField] private GameSession _session;

    public void UpdateBord()
    {
        _result.SetRecord(_score.Score);
        _result.SetMoney(_session.TakeMoney);
    }

    public void BackMainMenu()
    {
        ShowMenu(MenuType.MainMenu);
        _gameController.BackMainMenu();
    }

    public void Restart()
    {
        ShowHUD();
        _gameController.Restart();
    }

    public void ShowHUD()
    {
        ShowMenu(MenuType.HUD);
    }
}
