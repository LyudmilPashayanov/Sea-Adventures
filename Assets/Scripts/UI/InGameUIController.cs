using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    public InGameUIView m_view;
    public HealthBarController m_PlayersHealthBarController;

    public void SetInGameUI(bool active)
    {
        m_view.SetInGameUI(active);
    }

    public void ShowWaveInfo(int numberOfWave, Action callback)
    {
        m_view.SetWaveNumber(numberOfWave, callback);
    }
}
