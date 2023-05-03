using UnityEngine;
using UnityEngine.UI;

public class ShopCellUI : MonoBehaviour
{
    [SerializeField] private Image _icon;

    public ContentData Content { get; private set; }

    public void SetContent(ContentData data)
    {
        Content = data;
        _icon.sprite = data.Icon;
    }
}
