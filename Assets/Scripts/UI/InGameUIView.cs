using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InGameUIView : MonoBehaviour
{
    [SerializeField] private RectTransform m_InGameUI;
    [SerializeField] private RectTransform m_WaveTextUI;
    [SerializeField] private TextMeshProUGUI m_WaveText;
    [SerializeField] private TextMeshProUGUI m_CountdownText;

    public void SetInGameUI(bool active)
    {
        m_InGameUI.gameObject.SetActive(active);
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
}
