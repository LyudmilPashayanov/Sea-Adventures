using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : BaseEnemyAttack
{
    RaycastHit hit;
    public int m_AttackRange = 20;
    public int m_AttackDamage = 10;
    public int m_AttackSpeed = 1; // bullets per second

    private float m_CurrentReload = 0;
    private bool m_ReloadReady = true;

    private void Start()
    {
        SetStats(m_AttackRange, m_AttackDamage, m_AttackSpeed);
    }

    private void Update()
    {
        ReloadWeapon();
    }

    public override void AttackTarget(GameObject target)
    {
        transform.LookAt(target.transform);
        if (m_ReloadReady)
        {
            Shoot(target);
            m_ReloadReady = false;
        }
    }

    public override void Shoot(GameObject target)
    { 
           target.GetComponent<ShipHealth>().TakeDamage(AttackDamage);
    }

    public void ReloadWeapon()
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

    public override bool TargetInAttackRange(Transform target)
    {
        if (Vector3.Distance(target.position, transform.position) < AttackRange)
        {
            return true;
        }
        return false;
    }
}
