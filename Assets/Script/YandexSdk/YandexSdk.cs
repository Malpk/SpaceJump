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

    public bool ShowRewardAds(System.Action action)
    {
        if (IsReady)
        {
            IsReady = false;
            _action = action;
#if UNITY_WEBGL && !UNITY_EDITOR
         RewardShowAdsExtern();
#else
            Reward();
            CompliteAds();
#endif
            return true;
        }
        return false;
    }

    public void ShowBannerAds()
    {
        if (IsReady)
        {
            IsReady = false;
#if UNITY_WEBGL && !UNITY_EDITOR
        ShowBannerAdsExtern();
#else
            CompliteAds();
#endif
        }
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
