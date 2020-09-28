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

    public void StartGame()
    {
        AdsManager.Instance.ShowRewardAd();
        m_MenuController.SetOffMainMenus();
        playerController.enabled = true;
    }
}
