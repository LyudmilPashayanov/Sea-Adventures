using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsListView : MonoBehaviour
{
    public RectTransform m_LevelsListMenu;
    public List<Button> m_LevelButtons;

    public void SetLevelsListActive(bool active)
    {
        m_LevelsListMenu.gameObject.SetActive(active);
    }

    public void SetUnlockedLevels()
    {
        if (PlayfabManager.Instance.m_lastUnlockedLevel != 0)
        {
            int untilToUnlock = PlayfabManager.Instance.m_lastUnlockedLevel + 1;
            int counter = 0;
            foreach (Button item in m_LevelButtons)
            {
                if (untilToUnlock == counter)
                    return;
                item.interactable = true;
                counter++;
            }
        }
    }
}
