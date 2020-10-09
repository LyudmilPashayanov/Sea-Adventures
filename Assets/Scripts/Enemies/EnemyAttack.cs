using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float m_AttackRange = 20;
    public float m_RangeOfView = 30;
    public float m_AttackDamage = 10;
    public float m_AttackSpeed = 1f; // bullets per second

    private float m_CurrentReload = 0;
    private bool reloadReady=true;
    private void Update()
    {
        if (!reloadReady)
        {
            m_CurrentReload += Time.deltaTime;
            if(m_CurrentReload >= m_AttackSpeed)
            {
                reloadReady = true;
                m_CurrentReload = 0;
            }
        }
    }

    public void AttackTarget(GameObject target)
    {
        transform.LookAt(target.transform);
        Shoot(target);
    }

    public void Shoot(GameObject target)
    {
        if (reloadReady)
        {
            Debug.Log("SHOOT AT TARGET: " + target.name);
            reloadReady = false;
        }
    }
}
