using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    static UIController instance = null;
    public static UIController Instance { get { return instance; } }
    public UIView m_view;
    public LevelsListController m_LevelsListController;
    public TutorialController m_TutorialController;
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
        m_TutorialController.SetTutorialOff();
        m_InGameUIController.SetInGameUI(false);
    }

    public void SetOffMainMenus()
    {
        m_view.SetActiveMainMenus(false);
        m_view.SetActiveMenu(false);
        m_LevelsListController.SetLevelsListsOff();
        m_TutorialController.SetTutorialOff();
    }

    public void SetMainMenuActive(bool active)
    {
        if (active)
        {
            m_view.SetActiveMenu(true);
            m_LevelsListController.SetLevelsListsOff();
            m_TutorialController.SetTutorialOff();
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
            m_TutorialController.SetTutorialOff();
        }
        else
        {
            m_LevelsListController.SetLevelsListsOff();
            m_view.SetActiveMenu(true);
        }
    }

    public void SetTutorialActive(bool active)
    {
        if (active)
        {
            m_view.SetActiveMenu(false);
            m_LevelsListController.SetLevelsListsOff();
            m_TutorialController.SetTutorialActive();
        }
        else
        {
            m_TutorialController.SetTutorialOff();
            m_view.SetActiveMenu(true);
        }
    }

    public void ShowInternetError(bool active)
    {
        m_view.ShowInternetError(active);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
