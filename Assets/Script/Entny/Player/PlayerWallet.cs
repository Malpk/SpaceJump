using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private IntText _moneyText;

    public int Money => _money;

    private void OnValidate()
    {
        if (_moneyText)
            _moneyText.SetText(_money);
    }

    public void SetMoney(int money)
    {
        _money = money;
        _moneyText.SetText(_money);
    }

    public void TakeMoney(int money)
    {
        _money += money;
        _moneyText.SetText(_money);
    }

    public bool GiveMoney(int money)
    {
        if (_money - money >= 0)
        {
            _money -= money;
            _moneyText.SetText(_money);
            return true;
        }
        return false;
    }
}
