using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesView : MonoBehaviour
{
    public RectTransform m_UpgradesMenu;

    public void SetUpgradesActive(bool active)
    {
        m_UpgradesMenu.gameObject.SetActive(active);
    }
}
