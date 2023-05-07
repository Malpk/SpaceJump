using UnityEngine;

public class ShopMenu : UIMenu
{
    [SerializeField] private DataSaver _saver;

    public void BackMenu()
    {
        ShowMenu(MenuType.MainMenu);
    }

    public void SaveChoose()
    {
        _saver.Save();
    }
}
