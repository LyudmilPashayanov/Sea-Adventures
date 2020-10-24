using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    static UIController instance = null;
    public static UIController Instance { get { return instance; } }
    public UIView m_view;
    public LevelsListController m_LevelsListController;
    public ShopController m_ShopController;
    public InGameUIController m_InGameUIController;

    private void Awake()
    {
        instance = this;
    }

    public void StartLevelUI()
    {
        SetOffMainMenus();
        m_InGameUIController.SetInGameUI(true);
    }

    public void SetActiveMainMenus()
    {
        m_view.SetActiveMainMenus(true);
        m_view.SetActiveMenu(true);
        m_LevelsListController.SetLevelsListsOff();
        m_ShopController.SetShopOff();
        m_InGameUIController.SetInGameUI(false);
    }

    public void SetOffMainMenus()
    {
        m_view.SetActiveMainMenus(false);
        m_view.SetActiveMenu(false);
        m_LevelsListController.SetLevelsListsOff();
        m_ShopController.SetShopOff();
    }

    public void SetMainMenuActive(bool active)
    {
        if (active)
        {
            m_view.SetActiveMenu(true);
            m_LevelsListController.SetLevelsListsOff();
            m_ShopController.SetShopOff();
            m_InGameUIController.SetInGameUI(false);
        }
        else
        {
            m_view.SetActiveMenu(false);
        }
    }

    public void SetLevelsListActive(bool active)
    {
        if (active)
        {
            m_view.SetActiveMenu(false);
            m_LevelsListController.SetLevelsListActive();
            m_ShopController.SetShopOff();
        }
        else
        {
            m_LevelsListController.SetLevelsListsOff();
            m_view.SetActiveMenu(true);
        }
    }

    public void SetShopActive(bool active)
    {
        if (active)
        {
            m_view.SetActiveMenu(false);
            m_LevelsListController.SetLevelsListsOff();
            m_ShopController.SetShopActive();
        }
        else
        {
            m_ShopController.SetShopOff();
            m_view.SetActiveMenu(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
