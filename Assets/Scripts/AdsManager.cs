using GoogleMobileAds.Api;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    static AdsManager instance;
    public static AdsManager Instance { get { return instance; } }
    RewardedAdsGoogle m_RewardAdPlacement = null;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        m_RewardAdPlacement = gameObject.GetComponent<RewardedAdsGoogle>();
        m_RewardAdPlacement.Init();
    }

    public void ShowInterstitialAd()
    {
        //        interstistialAd.ShowAd();
    }

    public bool IsAdLoaded()
    {
        if (m_RewardAdPlacement != null)
        {
            return m_RewardAdPlacement.IsLoaded();
        }
        return false;
    }

    public void ShowRewardAd()
    {
        if (m_RewardAdPlacement != null)
        {
            m_RewardAdPlacement.ShowAd();
        }
    }
}
