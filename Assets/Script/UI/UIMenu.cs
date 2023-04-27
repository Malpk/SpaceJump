using UnityEngine.Events;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent _onShow;
    [SerializeField] private UnityEvent _onHide;
    [Header("Reference")]
    [SerializeField] private Canvas _canvas;

    public void Show()
    {
        _onShow.Invoke();
        _canvas.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _onHide.Invoke();
        _canvas.gameObject.SetActive(false);
    }
}
