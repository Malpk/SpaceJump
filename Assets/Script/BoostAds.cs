using UnityEngine;

public class BoostAds : MonoBehaviour
{
    [SerializeField] private int _bannerSteap;
    [SerializeField] private int _countMoneySession;
    [Header("Reference")]
    [SerializeField] private YandexSdk _sdk;
    [SerializeField] private GameStart _gameController;
    [SerializeField] private PlayerWallet _wallet;

    private int _countDeath;

    private void OnEnable()
    {
        _wallet.OnTakeMoney += AddMoney;
    }

    private void OnDisable()
    {
        _wallet.OnTakeMoney -= AddMoney;
    }

    public void Reset()
    {
        _countMoneySession = 0;
    }

    private void AddMoney(int money)
    {
        _countMoneySession += money;
    }

    public void TwoMoney()
    {
        _sdk.ShowRewardAds(() => _wallet.TakeMoney(_countMoneySession));
    }

    public void ReturnPlayerGame()
    {
        _sdk.ShowRewardAds(_gameController.ReturnPlayerGame);
    }

    public void ShowBanner()
    {
        _countDeath++;
        if (_countDeath > _bannerSteap)
        {
            _sdk.ShowBannerAds();
            _countDeath = 0;
        }
    }

}
