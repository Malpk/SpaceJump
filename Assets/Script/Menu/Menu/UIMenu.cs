using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private MenuType _type;
    [Header("Reference")]
    [SerializeField] private Canvas _canvas;

    public event System.Action<MenuType> OnShowMenu;

    public MenuType TypeMenu => _type;

    public void Show()
    {
        _canvas.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _canvas.gameObject.SetActive(false);
    }

    protected void ShowMenu(MenuType menu)
    {
        OnShowMenu?.Invoke(menu);
        Hide();
    }
}
