using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    [SerializeField] private List<ContentData> _contents;

    private void OnValidate()
    {
        for (int i = 0; i < _contents.Count; i++)
        {
            for (int j = i + 1; j < _contents.Count && _contents[i]; j++)
            {
                if (_contents[j])
                {
                    if (_contents[i].ID == _contents[j].ID)
                        Debug.LogError($"The id is repeated " +
                            $"at {_contents[j].name} and {_contents[i]}");
                }
            }
        }
    }

    public bool TryGetContent(int id, out ContentData data)
    {
        foreach (var content in _contents)
        {
            if (content.ID == id)
            {
                data = content;
                return true;
            }
        }
        data = null;
        return false;
    }
}
