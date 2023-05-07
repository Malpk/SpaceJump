using System.Collections.Generic;
using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] private List<UIMenu> _menus;

    private void OnEnable()
    {
        foreach (var menu in _menus)
        {
            menu.OnShowMenu += ShowMenu;
        }
    }

    private void OnDisable()
    {
        foreach (var menu in _menus)
        {
            menu.OnShowMenu -= ShowMenu;
        }
    }

    public void ShowMenu(MenuType type)
    {
        var uiMenu = GetMenu(type);
        uiMenu.Show();
    }

    private UIMenu GetMenu(MenuType type)
    {
        foreach (var menu in _menus)
        {
            if (menu.TypeMenu == type)
                return menu;
        }
        return null;
    }

}
