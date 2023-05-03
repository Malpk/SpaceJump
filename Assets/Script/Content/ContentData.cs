using UnityEngine;

[CreateAssetMenu(menuName ="Shop/Content")]
public class ContentData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Sprite _content;

    public int ID => _id;
    public int Price => _price;
    public Sprite Content => _content;
    public Sprite Icon => _icon;
}
