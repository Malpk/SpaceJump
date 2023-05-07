using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int _money;
<<<<<<< Updated upstream
    [SerializeField] private IntText _moneyText;
=======
    [SerializeField] private IntText[] _moneyTexts;

    public event System.Action<int> OnTakeMoney;

    public int Money => _money;
>>>>>>> Stashed changes

    private void OnValidate()
    {
        if (_moneyText)
            _moneyText.SetText(_money);
    }

    public void TakeMoney(int money)
    {
        _money += money;
<<<<<<< Updated upstream
        _moneyText.SetText(_money);
=======
        UpdateUI();
        OnTakeMoney?.Invoke(money);
>>>>>>> Stashed changes
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
