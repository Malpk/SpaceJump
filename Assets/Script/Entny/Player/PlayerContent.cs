using System.Collections.Generic;
using UnityEngine;

public class PlayerContent : MonoBehaviour
{
    [SerializeField] private PlayerSkin _player;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private List<ContentData> _contents;

    public ContentData ChooseContent { get; private set; }

    private void Awake()
    {
        if(_contents.Count > 0)
            ChooseContent = _contents[0];
    }

    public void Select(ContentData content)
    {
        ChooseContent = content;
        _player.SetSkin(content.Content);
    }

    public bool Buy(ContentData content)
    {
        if (_playerWallet.GiveMoney(content.Price))
        {
            AddContent(content);
            Select(content);
            return true;
        }
        return false;
    }

    public void AddContent(ContentData content)
    {
        if (!_contents.Contains(content))
            _contents.Add(content);
    }
    public bool Contain(ContentData content)
    {
        return _contents.Contains(content);
    }
}
