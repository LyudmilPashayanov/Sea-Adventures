using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : EnemyAttack
{
    RaycastHit hit;
    public float m_AttackRange = 20;
    public float m_AttackDamage = 10;
    public float m_AttackSpeed = 1f; // bullets per second

    private float m_CurrentReload = 0;
    private bool m_ReloadReady = true;

    private void Start()
    {
        SetStats(m_AttackRange, m_AttackDamage, m_AttackSpeed);
    }

    private void Update()
    {
        if (!m_ReloadReady)
        {
            m_CurrentReload += Time.deltaTime;
            if (m_CurrentReload >= AttackSpeed)
            {
                m_ReloadReady = true;
                m_CurrentReload = 0;
            }
        }
    }

    public override void AttackTarget(GameObject target)
    {
        transform.LookAt(target.transform);
        Shoot(target);
    }

    public override void Shoot(GameObject target)
    {
        if (m_ReloadReady)
        {
            Debug.Log("SHOOT AT TARGET: " + target.name + " for DAMAGER: "+ AttackDamage );
            m_ReloadReady = false;
        }
    }

    public override bool TargetInAttackRange(Transform target)
    {
        if (Vector3.Distance(target.position, transform.position) < AttackRange)
        {
            return true;
        }
        return false;
    }
}
