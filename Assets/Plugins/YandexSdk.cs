using UnityEngine;
using System.Runtime.InteropServices;

public class YandexSdk : MonoBehaviour
{
    private System.Action _action;
    
    public bool IsReady { get; private set; } = true;

    [DllImport("__Internal")]
    private static extern void RewardShowAdsExtern();
    [DllImport("__Internal")]
    private static extern void ShowBannerAdsExtern();

    public void ShowRewardAds(System.Action action)
    {
        IsReady = false;
        _action = action;
#if UNITY_WEBGL && !UNITY_EDITOR
         RewardShowAdsExtern();
#else
        Reward();
        CompliteAds();
#endif
    }

    public void ShowBannerAds()
    {
        IsReady = false;
#if UNITY_WEBGL && !UNITY_EDITOR
        ShowBannerAdsExtern();
#else
        CompliteAds();
#endif
    }

    public void Reward()
    {
        _action();
    }

    public void CompliteAds()
    {
        IsReady = true;
    }
}
