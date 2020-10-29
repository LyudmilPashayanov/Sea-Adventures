using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameUIView : MonoBehaviour
{
    [SerializeField] private RectTransform m_InGameUI;
    [SerializeField] private RectTransform m_WaveTextUI;
    [SerializeField] private TextMeshProUGUI m_WaveText;
    [SerializeField] private TextMeshProUGUI m_CountdownText;
    [SerializeField] private RectTransform m_AdsTab;
    [SerializeField] private RectTransform m_ButtonsBeforeAd;
    [SerializeField] private RectTransform m_ButtonAdWatched;
    [SerializeField] private RectTransform m_ButtonAdNotWatched;
    [SerializeField] private TextMeshProUGUI m_AdTabDescription;
    [SerializeField] private RectTransform m_AttackButton;
    [SerializeField] private RectTransform m_DeployTrapButton;
    [SerializeField] private Button m_TrapButton;

    public void SetTrapDeployButton()
    {
        m_AttackButton.gameObject.SetActive(false);
        m_DeployTrapButton.gameObject.SetActive(true);
        m_TrapButton.onClick.RemoveAllListeners();
        UnityEngine.Events.UnityAction action1 = () => { PlayerController_mobileJoystick.Instance.m_PlayersTrapDeployer.CancelTrapDeployment(); };
        m_TrapButton.onClick.AddListener(action1);
        m_TrapButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "X";
    }

    public void CancelTrapDeployment()
    {
        m_AttackButton.gameObject.SetActive(true);
        m_DeployTrapButton.gameObject.SetActive(false);
        m_TrapButton.onClick.RemoveAllListeners();
        UnityEngine.Events.UnityAction action1 = () => { PlayerController_mobileJoystick.Instance.m_PlayersTrapDeployer.PreviewTrap(); };
        m_TrapButton.onClick.AddListener(action1);
        m_TrapButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Trap";
    }

    public void SetInGameUI(bool active)
    {
        m_InGameUI.gameObject.SetActive(active);
        if (active)
        {
            CancelTrapDeployment();
        }
    }

    public void SetWaveNumber(int waveNumber,Action callback)
    {
        m_WaveText.text = "Wave " + waveNumber.ToString();
        m_WaveTextUI.gameObject.SetActive(true);
        StartCoroutine(WaveTextSettingOff(callback));
    }

    IEnumerator WaveTextSettingOff(Action callback)
    {
        m_CountdownText.text = "3";
        yield return new WaitForSecondsRealtime(0.8f);
        m_CountdownText.text = "2";
        yield return new WaitForSecondsRealtime(0.8f);
        m_CountdownText.text = "1";
        yield return new WaitForSecondsRealtime(0.8f);
        m_WaveTextUI.gameObject.SetActive(false);
        callback.Invoke();
    }

    public void ShowAdsTab(bool active)
    {
        if (active)
        {
            m_AdTabDescription.text = "You've failed the level :( <br> You can watch an Ad <br> and continue from where you died:";
            m_ButtonsBeforeAd.gameObject.SetActive(true);
            m_ButtonAdWatched.gameObject.SetActive(false);
            m_ButtonAdNotWatched.gameObject.SetActive(false);
            m_AdsTab.gameObject.SetActive(true);
        }
        else
        {
            m_AdsTab.gameObject.SetActive(false);
        }
    }

    public void AfterAdWatched(bool watched)
    {
        m_ButtonsBeforeAd.gameObject.SetActive(false);
        if (watched)
        {
            m_AdTabDescription.text = "Thanks for watching the Ad.<br>I have cleared the enemies for you :)";
            m_ButtonAdNotWatched.gameObject.SetActive(false);
            m_ButtonAdWatched.gameObject.SetActive(true);
        }
        else
        {
            m_AdTabDescription.text = "The Ad was closed too early<br>You should replay the level.";
            m_ButtonAdNotWatched.gameObject.SetActive(true);
            m_ButtonAdWatched.gameObject.SetActive(false);
        }
    }



}
