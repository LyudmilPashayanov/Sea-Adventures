using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardedAdsGoogle : MonoBehaviour
{
    private string m_AdUnit = "";
    private RewardedAd m_RewardedAd = null;
    private bool m_RewardReceived = false;

    public void Init()
    {
        CreateAndLoadAd();
    }

    private void CreateAndLoadAd()
    {    
#if UNITY_ANDROID //ca-app-pub-3708989579228050/4090049015
            m_AdUnit = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            m_AdUnit = "ca-app-pub-6665445387809242/1536364218";
#else
            m_AdUnit = "unexpected_platform";
#endif

        m_RewardedAd = new RewardedAd(m_AdUnit);

        // Called when an ad request has successfully loaded.
        m_RewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        m_RewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        m_RewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        m_RewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        m_RewardedAd.OnUserEarnedReward += HandleUserReward;
        m_RewardedAd.OnAdClosed += HandleCoinAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        m_RewardedAd.LoadAd(request);
    }

    public bool IsLoaded()
    {
        return m_RewardedAd.IsLoaded();
    }

    public void ShowAd()
    {
        m_RewardReceived = false;
        if (!m_RewardedAd.IsLoaded())
        {
            Debug.Log("Try to load the Ad again.");
            CreateAndLoadAd();
        }
        StartCoroutine(ShowAdAsync(m_RewardedAd));
    }

    private IEnumerator ShowAdAsync(RewardedAd ad)
    {
        int count = 30;
        while (!ad.IsLoaded() && --count >= 0)
        {
            yield return new WaitForSeconds(0.1f);
        }

        if (ad.IsLoaded())
        {
            Debug.Log("ShowAdAsync");
            ad.Show();
#if UNITY_EDITOR
            HandleUserReward(null, null);
            HandleCoinAdClosed(null, null);
#endif
        }
        else
        {          
            Debug.Log("NO AD: ");
            //TopBarWidget.Instance.HideCoinShop();
        }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        Debug.Log("HandleRewardedAdFailedToLoad event received with message: " + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        Debug.Log("HandleRewardedAdFailedToShow event received with message: " + args.Message);
        HandleAdClose();
    }

    public void HandleCoinAdClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardedAdClosed event received: ");
        HandleAdClose();
        CreateAndLoadAd();
    }

    public void HandleUserReward(object sender, Reward args)
    {
        //Debug.Log("HandleRewardedAdRewarded event received for " + args.Amount.ToString() + " " + args.Type + " : " + m_CurrentPlacement);
        m_RewardReceived = true;
        //HandleAdClose();
    }

    private void HandleAdClose()
    {
        if (m_RewardReceived)
        {
           //give the rewards to the palyer
        }
        else
        {
           //ad canceled
           //don't give the rewards
        }
        m_RewardReceived = false;
    }
}
