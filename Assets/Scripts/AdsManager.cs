using GoogleMobileAds.Api;
using System.Collections.Generic;
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
        MobileAds.Initialize((initStatus) =>
        {
            Dictionary<string, AdapterStatus> map = initStatus.getAdapterStatusMap();
            foreach (KeyValuePair<string, AdapterStatus> keyValuePair in map)
            {
                string className = keyValuePair.Key;
                AdapterStatus status = keyValuePair.Value;
                switch (status.InitializationState)
                {
                    case AdapterState.NotReady:
                        // The adapter initialization did not complete.
                        MonoBehaviour.print("Adapter: " + className + " not ready.");
                        break;
                    case AdapterState.Ready:
                        // The adapter was successfully initialized.
                        MonoBehaviour.print("Adapter: " + className + " is initialized.");
                        break;
                }
            }
        });

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
