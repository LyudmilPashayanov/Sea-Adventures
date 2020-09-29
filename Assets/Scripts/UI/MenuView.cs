using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    public RectTransform m_MainMenus;
    public RectTransform m_Menu;
    public RectTransform m_InGameUI;


    public void SetActiveMainMenus(bool active)
    {
        m_MainMenus.gameObject.SetActive(active);
    }

    public void SetActiveMenu(bool active)
    {
        m_Menu.gameObject.SetActive(active);
    }

    public void SetInGameUI(bool active)
    {
        m_InGameUI.gameObject.SetActive(active);
    }
}

