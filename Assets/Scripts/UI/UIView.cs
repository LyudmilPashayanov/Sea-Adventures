using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : MonoBehaviour
{
    public RectTransform m_MainMenus;
    public RectTransform m_Menu;
    public RectTransform m_InternetErrorTab;
    public RectTransform m_ConnectingText;

    public void SetConnectingTextOff()
    {
        m_ConnectingText.gameObject.SetActive(false);
    }

    public void SetActiveMainMenus(bool active)
    {
        m_MainMenus.gameObject.SetActive(active);
    }

    public void SetActiveMenu(bool active)
    {
        m_Menu.gameObject.SetActive(active);
    }

    public void ShowInternetError(bool active)
    {
        m_InternetErrorTab.gameObject.SetActive(active);
    }
}

