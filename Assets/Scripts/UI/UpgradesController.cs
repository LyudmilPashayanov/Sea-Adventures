using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesController : MonoBehaviour
{
    public UpgradesView m_view;

    public void SetUpgradesActive()
    {
        m_view.SetUpgradesActive(true);
    }

    public void SetUpgradesOff()
    {
        m_view.SetUpgradesActive(false);
    }
}
