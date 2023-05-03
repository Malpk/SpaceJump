using UnityEngine;
using TMPro;

public class IntText : MonoBehaviour
{
    [Min(3)]
    [SerializeField] private int _size = 3;
    [SerializeField] private TextMeshProUGUI _text;

    public void SetText(int value)
    {
        var text = value.ToString();
        while (_size > text.Length)
        {
            text = "0" + text;
        }
        _text.text = text;
    }
}
