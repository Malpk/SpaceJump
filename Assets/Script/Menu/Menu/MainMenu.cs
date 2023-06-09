using UnityEngine;
using System.Runtime.InteropServices;

public class MainMenu : UIMenu
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerStateSwitcher _gameStart;


    [DllImport("__Internal")]
    private static extern void ShowLeaderBoradExtern();

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

    public void ShowLeaderBorad()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        ShowLeaderBoradExtern();
#endif
    }
}
