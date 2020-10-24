using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsListController : MonoBehaviour
{
    public LevelsListView m_view;

    public void SetLevelsListActive()
    {
        m_view.SetLevelsListActive(true);
        m_view.SetUnlockedLevels();
    }

    public void SetLevelsListsOff()
    {
        m_view.SetLevelsListActive(false);
    }
}
