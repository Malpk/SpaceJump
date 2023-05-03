using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private IntText[] _moneyTexts;

    public int Money => _money;

    private void OnValidate()
    {
        if (_moneyTexts.Length > 0)
            UpdateUI();
    }

    public void SetMoney(int money)
    {
        _money = money;
        UpdateUI();
    }

    public void TakeMoney(int money)
    {
        _money += money;
        UpdateUI();
    }

    public bool GiveMoney(int money)
    {
        if (_money - money >= 0)
        {
            _money -= money;
            UpdateUI();
            return true;
        }
        return false;
    }

    private void UpdateUI()
    {
        foreach (var text in _moneyTexts)
        {
            if(text)
                text.SetText(_money);
        }
    }
}
