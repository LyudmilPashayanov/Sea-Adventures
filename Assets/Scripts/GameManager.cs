using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MenuController m_MenuController;
    public PlayerController_mobileJoystick playerController;

    void Start()
    {
        m_MenuController.SetActiveMainMenus();
        playerController.enabled = false;
    }

    public void StartLevel()
    {
        AdsManager.Instance.ShowRewardAd();
        m_MenuController.StartLevelUI();
        playerController.enabled = true;

    }
}
