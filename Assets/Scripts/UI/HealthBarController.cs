using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public HealthBarView m_view;

    public void ReduceHealth(int amount)
    {
        m_view.ReduceHp(amount);
    }
}
