using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandManager : MonoBehaviour
{
    private static IslandManager instance;
    public static IslandManager Instance { get { return instance; } }

    public BaseHealth m_IslandHealth;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    { 
        m_IslandHealth = gameObject.GetComponent<IslandHealth>();
        m_IslandHealth.TakeDamageEvent += UIController.Instance.m_InGameUIController.m_IslandsHealthBarController.ReduceHealth;
        UIController.Instance.m_InGameUIController.m_IslandsHealthBarController.SetMaxHealth(m_IslandHealth.GetMaxHealth());
        m_IslandHealth.OnResetHealth += UIController.Instance.m_InGameUIController.m_IslandsHealthBarController.ResetHealth;
    }




}
