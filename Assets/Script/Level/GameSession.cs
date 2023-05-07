using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;

    private int _countTakeMoney = 0;

    public int TakeMoney => _countTakeMoney;

    private void OnEnable()
    {
        _wallet.OnTakeMoney += UpdateTakeMoney;
    }

    private void OnDisable()
    {
        _wallet.OnTakeMoney -= UpdateTakeMoney;
    }

    public void Reset()
    {
        _countTakeMoney = 0;
    }
    public void DubleMoney()
    {
        _wallet.TakeMoney(_countTakeMoney);
    }
    private void UpdateTakeMoney(int money)
    {
        _countTakeMoney += money;
    }

}
