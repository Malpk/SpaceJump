using UnityEngine;

public class HudMenu : UIMenu
{
    [SerializeField] private DeadMenu _deadMenu;

    public void ShowDeadMenu()
    {
        _deadMenu.UpdateBord();
        ShowMenu(MenuType.DeadMenu);
    }
}
