using UnityEngine;
using TMPro;

public class PrefixText : MonoBehaviour
{
    [SerializeField] private string _prefix;
    [SerializeField] private string _extens;
    [SerializeField] private TextMeshProUGUI _text;

    public void SetText(string text)
    {
        _text.text = _prefix + text + _extens;
    }
}
