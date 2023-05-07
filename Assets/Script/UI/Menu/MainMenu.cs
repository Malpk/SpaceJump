using UnityEngine;

public class MainMenu : UIMenu
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerStateSwitcher _gameStart;

    public void StartGame()
    {
        _animator.SetBool("start", true);
    }

    public void ShowMainMenu()
    {
        _animator.SetBool("start", false);
    }

    public void ShowShop()
    {
        ShowMenu(MenuType.Shop);
    }

    public void ShowSetting()
    {
        ShowMenu(MenuType.Setting);
    }

    private void StartGameAnimationEvent()
    {
        ShowMenu(MenuType.HUD);
        _gameStart.StartGame();
    }
}
