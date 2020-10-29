using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfabManager : MonoBehaviour
{
    static PlayfabManager instance;
    public static PlayfabManager Instance { get { return instance; } }
    private string m_TitleId = "C16C1";
    private string m_PlayFabID="";
    private int m_userAdsWatched = 0;
    private int m_userAdsPlayerButNotFinished=0;
    private int m_userAdsOffered = 0;
    public int m_lastUnlockedLevel;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayFabSettings.TitleId = m_TitleId;
        Login();
    }

   public void Login()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        var request = new LoginWithAndroidDeviceIDRequest
        {
            AndroidDevice = SystemInfo.deviceModel,
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        Debug.Log(" Logging with android account!!!");
        PlayFabClientAPI.LoginWithAndroidDeviceID(request, OnLoginSuccess, OnPlayFabError);
#endif
#if UNITY_EDITOR
        LoginWithCustomIDRequest request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,

            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnPlayFabError);
#endif
    }

    protected void OnLoginSuccess(PlayFab.ClientModels.LoginResult result)
    {

        m_PlayFabID = result.PlayFabId;
        Debug.Log("PlayFabID: " + m_PlayFabID);
        GetPlayerData();
    }

    //private void GetTitleData()
    //{
    //    PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(),
    //     result =>
    //     {
    //         if (result.Data == null || !result.Data.ContainsKey("MonsterName")) Debug.Log("No MonsterName");
    //         else Debug.Log("MonsterName: " + result.Data["MonsterName"]);
    //     }, 
    //     OnPlayFabError);
    //}

    public void GetPlayerData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = m_PlayFabID,
            Keys = null
        }, result =>
        {
            Debug.Log("Got user data:");
            if (result.Data == null || !result.Data.ContainsKey("ads_Watched")) Debug.Log("existing Ads number");
            else
            {
                m_userAdsWatched = Convert.ToInt32(result.Data["ads_Watched"].Value);
                Debug.Log("this user ads = " + m_userAdsWatched);
            }
            if (result.Data.ContainsKey("ads_StartedButNotFinished"))
            {
                m_userAdsPlayerButNotFinished = Convert.ToInt32(result.Data["ads_StartedButNotFinished"].Value);
                Debug.Log("m_userAdsPlayerButNotFinished = " + m_userAdsPlayerButNotFinished);
            }
            if (result.Data.ContainsKey("ads_Offered"))
            {
                m_userAdsOffered = Convert.ToInt32(result.Data["ads_Offered"].Value);
                Debug.Log("m_userAdsOffered = " + m_userAdsOffered);
            }
            if (result.Data.ContainsKey("LastUnlockedLevel"))
            {
                m_lastUnlockedLevel = Convert.ToInt32(result.Data["LastUnlockedLevel"].Value);
                Debug.Log("m_lastUnlockedLevel = " + m_lastUnlockedLevel);
            }

        }, OnPlayFabError);
    }

    public void RecordAdWatched()
    {
        m_userAdsWatched += 1;
        UpdateUserDataRequest request = new UpdateUserDataRequest();
        request.Data = new Dictionary<string, string>() {
            {"ads_Watched", (m_userAdsWatched).ToString()} } ;
    

    PlayFabClientAPI.UpdateUserData(request,

        result => Debug.Log("Successfully updated user data"),
    
        OnPlayFabError);
    }

    public void RecordAdPlayedButNotFinished()
    {
        m_userAdsPlayerButNotFinished += 1;
        UpdateUserDataRequest request = new UpdateUserDataRequest();
        request.Data = new Dictionary<string, string>() {
            {"ads_StartedButNotFinished", (m_userAdsPlayerButNotFinished).ToString()} };


        PlayFabClientAPI.UpdateUserData(request,

            result => Debug.Log("Successfully updated user data"),

            OnPlayFabError);
    }

    public void RecordAdOffered()
    {
        m_userAdsOffered += 1;
        UpdateUserDataRequest request = new UpdateUserDataRequest();
        request.Data = new Dictionary<string, string>() {
            {"ads_Offered", (m_userAdsOffered).ToString()} };


        PlayFabClientAPI.UpdateUserData(request,

            result => Debug.Log("Successfully updated user data"),

            OnPlayFabError);
    }

    public void IncreaseLevel()
    {
        UpdateUserDataRequest request = new UpdateUserDataRequest();
        request.Data = new Dictionary<string, string>() {
            {"LastUnlockedLevel", (m_lastUnlockedLevel).ToString()} };


        PlayFabClientAPI.UpdateUserData(request,

            result => Debug.Log("Successfully updated user data"),

            OnPlayFabError);
    }

    public void OnPlayFabError(PlayFabError error)
    {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        Debug.Log("ON PLAYFAB ERROR  " + error.ErrorMessage);
#endif
        ShowConnectionError();
    }

    public void ShowConnectionError()
    {
        UIController.Instance.ShowInternetError(true);
    }
}
