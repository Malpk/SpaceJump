using UnityEngine;


public class AdsButton : MonoBehaviour
{
    [SerializeField] private GameObject _dubleAds;
    [SerializeField] private GameObject  _returnAds;

    public void Reset()
    {
        _returnAds.SetActive(true);
        _dubleAds.SetActive(true);
    }

    public void ShowReturnAds()
    {
        _returnAds.SetActive(false);
    }

    public void ShowDubleAds()
    {
        _dubleAds.SetActive(false);
    }
}
