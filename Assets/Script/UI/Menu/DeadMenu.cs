using UnityEngine;

public class DeadMenu : UIMenu
{
    [SerializeField] private GameStart _gameController;
    [SerializeField] private JumpScore _score;
    [SerializeField] private PlayerWallet _wallet;

    public void ShowDead()
    {
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
