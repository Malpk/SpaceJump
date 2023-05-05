using System.Collections.Generic;
using UnityEngine;

public class PlayerContent : MonoBehaviour
{
    [SerializeField] private PlayerSkin _player;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private List<ContentData> _contents;
    [SerializeField] private DataHolder _dataHolder;

    public ContentData ChooseContent { get; private set; }

    private void Start()
    {
        if (!ChooseContent)
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
    public bool Contain(ContentData target)
    {
        foreach (var content in _contents)
        {
            if (content.ID == target.ID)
                return true;
        }
        return false;
    }

    public string Save()
    {
        var data = new PlayerContentData();
        data.ChooseContent = ChooseContent ? ChooseContent.ID : -1;
        data.Contens = new int[_contents.Count];
        for (int i = 0; i < _contents.Count; i++)
        {
            data.Contens[i] = _contents[i].ID;
        }
        return JsonUtility.ToJson(data);
    }

    public void Load(string dataString)
    {
        var data = JsonUtility.FromJson<PlayerContentData>(dataString);
        if (_dataHolder.TryGetContent(data.ChooseContent, out ContentData choose))
            Select(choose);
        foreach (var ID in data.Contens)
        {
            if (_dataHolder.TryGetContent(ID, out ContentData content))
                AddContent(content);
        }
    }
}
