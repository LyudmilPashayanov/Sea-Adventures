using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    public RectTransform m_MainMenus;
    public RectTransform m_Menu;

    public void SetActiveMainMenus(bool active)
    {
        m_MainMenus.gameObject.SetActive(active);
    }

    public void SetActiveMenu(bool active)
    {
        m_Menu.gameObject.SetActive(active);
    }
}
