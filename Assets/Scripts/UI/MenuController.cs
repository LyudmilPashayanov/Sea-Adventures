using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public MenuView m_view;
    public UpgradesController m_UpgradesController;
    public ShopController m_ShopController;
    
    public void StartLevelUI()
    {
        SetOffMainMenus();
        SetInGameUI(true);
    }

    public void SetActiveMainMenus()
    {
        m_view.SetActiveMainMenus(true);
        m_view.SetActiveMenu(true);
        m_UpgradesController.SetUpgradesOff();
        m_ShopController.SetShopOff();
    }

    public void SetOffMainMenus()
    {
        m_view.SetActiveMainMenus(false);
        m_view.SetActiveMenu(false);
        m_UpgradesController.SetUpgradesOff();
        m_ShopController.SetShopOff();
    }

    public void SetMainMenuActive(bool active)
    {
        if (active)
        {
            m_view.SetActiveMenu(true);
            m_UpgradesController.SetUpgradesOff();
            m_ShopController.SetShopOff();
        }
        else
        {
            m_view.SetActiveMenu(false);
        }
    }

    public void SetUpgradesActive(bool active)
    {
        if (active)
        {
            m_view.SetActiveMenu(false);
            m_UpgradesController.SetUpgradesActive();
            m_ShopController.SetShopOff();
        }
        else
        {
            m_UpgradesController.SetUpgradesOff();
            m_view.SetActiveMenu(true);
        }
    }

    public void SetShopActive(bool active)
    {
        if (active)
        {
            m_view.SetActiveMenu(false);
            m_UpgradesController.SetUpgradesOff();
            m_ShopController.SetShopActive();
        }
        else
        {
            m_ShopController.SetShopOff();
            m_view.SetActiveMenu(true);
        }
    }

    public void SetInGameUI(bool active)
    {
        m_view.SetInGameUI(active);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
