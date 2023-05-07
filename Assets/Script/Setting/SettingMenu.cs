using UnityEngine;

public class SettingMenu : UIMenu
{
    [SerializeField] private DataSaver _save;
    [SerializeField] private MusicSetting _setting;

    public void Save()
    {
        _setting.SaveSetting();
        _save.Save();
        ShowMenu(MenuType.MainMenu);
    }

    public void Canel()
    {
        _setting.UpdateSetting();
        ShowMenu(MenuType.MainMenu);
    }


}
