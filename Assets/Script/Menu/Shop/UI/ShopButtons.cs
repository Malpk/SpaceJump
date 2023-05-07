using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    [SerializeField] private Image _selectWarning;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _selectButton;
    
    private GameObject _curretButton;

    public void UpdateState(ContentState state)
    {
        switch (state)
        {
            case ContentState.Buy:
                ShowElement(_selectButton.gameObject);
                return;
            case ContentState.NotBuy:
                ShowElement(_buyButton.gameObject);
                return;
            case ContentState.Select:
                ShowElement(_selectWarning.gameObject);
                break;
        }

    }

    private void ShowElement(GameObject uiElement)
    {
        if (_curretButton != uiElement)
        {
            uiElement.SetActive(true);
            if(_curretButton)
                _curretButton.SetActive(false);
            _curretButton = uiElement;
        }
    }
}
