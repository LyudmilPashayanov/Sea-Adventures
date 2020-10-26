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

    public void ResetHealth()
    {
        m_view.ResetHealth();
    }

    public void SetMaxHealth(int maxHealth)
    {
        m_view.SetMaxHealth(maxHealth);
    }
}
