using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    public InGameUIView m_view;
    public HealthBarController m_PlayersHealthBarController;
    public HealthBarController m_IslandsHealthBarController;

    public void SetInGameUI(bool active)
    {
        m_view.SetInGameUI(active);
    }

    public void ShowWaveInfo(int numberOfWave, Action callback)
    {
        m_view.SetWaveNumber(numberOfWave, callback);
    }
    
    public void ShowAdsTab()
    {
        m_view.ShowAdsTab(true);
    }

    public void CloseAdsTab()
    {
        m_view.ShowAdsTab(false);
    }

    public void SwitchTabToAdWatched(bool watched)
    {
        m_view.AfterAdWatched(watched);
    }
}
