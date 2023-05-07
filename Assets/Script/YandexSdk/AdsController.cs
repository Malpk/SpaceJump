using UnityEngine;

public class AdsController : MonoBehaviour
{
    [SerializeField] private YandexSdk _sdk;
    [SerializeField] private DeadMenu _deadMenu;
    [SerializeField] private GameStart _game;
    [SerializeField] private GameSession _session;
    [Header("Buttons")] 
    [SerializeField] private GameObject _dubleAds;
    [SerializeField] private GameObject  _returnAds;

    public void Reset()
    {
        _returnAds.SetActive(true);
        _dubleAds.SetActive(true);
    }

    public void ShowReturnAds()
    {
        _sdk.ShowRewardAds(ReturnGame);
        _returnAds.SetActive(false);
    }

    public void ShowDubleAds()
    {
        _sdk.ShowRewardAds(DubleMoney);
        _dubleAds.SetActive(false);
    }

    private void ReturnGame()
    {
        _deadMenu.ShowHUD();
        _game.ReturnGame();
    }

    private void DubleMoney()
    {
        _session.DubleMoney();
        _deadMenu.UpdateBord();
    }
}
