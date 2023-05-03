using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private PlayerContent _playerContent;
    [SerializeField] private ContentData[] _contens;
    [Header("UI Reference")]
    [SerializeField] private ShopCellUI _left;
    [SerializeField] private ShopCellUI _right;
    [SerializeField] private ShopCellUI _center;
    [SerializeField] private ShopButtons _shopButtons;

    private void Start()
    {
        UpdateShop();
    }

    public void Buy()
    {
        if (_playerContent.Buy(_center.Content))
            _shopButtons.UpdateState(ContentState.Select);
    }

    public void Select()
    {
        _playerContent.Select(_center.Content);
        _shopButtons.UpdateState(ContentState.Select);
    }

    public void Next()
    {
        var content = _contens[_contens.Length - 1];
        for (int i = _contens.Length-1; i > 0; i--)
        {
            _contens[i] = _contens[i - 1];
        }
        _contens[0] = content;
        UpdateShop();
    }

    public void Previus()
    {
        var content = _contens[0];
        for (int i = 0; i < _contens.Length - 1; i++)
        {
            _contens[i] = _contens[i + 1];
        }
        _contens[_contens.Length - 1] = content;
        UpdateShop();
    }

    private void UpdateShop()
    {
        _left.SetContent(_contens[_contens.Length - 1]);
        _right.SetContent(_contens[1]);
        _center.SetContent(_contens[0]);
        ChooseButton();
    }

    private void ChooseButton()
    {
        if (_playerContent.ChooseContent != _center.Content)
        {
            if (_playerContent.Contain(_center.Content))
            {
                _shopButtons.UpdateState(ContentState.Buy);
            }
            else
            {
                _shopButtons.UpdateState(ContentState.NotBuy);
            }
        }
        else
        {
            _shopButtons.UpdateState(ContentState.Select);
        }
    }

}
