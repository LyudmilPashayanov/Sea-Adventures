using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : EnemyAttack
{
    RaycastHit hit;
    public float m_AttackRange = 20;
    public float m_RangeOfView = 30;
    public float m_AttackDamage = 10;
    public float m_AttackSpeed = 1f; // bullets per second

    private float m_CurrentReload = 0;
    private bool m_ReloadReady = true;

    private void Start()
    {
        SetStats(m_AttackRange, m_AttackDamage, m_AttackSpeed, m_RangeOfView);
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

    public override bool CheckForPlayer()
    {
        Transform player = PlayerController_mobileJoystick.Instance.transform;
        if (Vector3.Distance(transform.position, player.position) < RangeOfView)
        {
            // check if there is a wall infornt of the player
            Debug.DrawLine(transform.position, player.position, Color.yellow);
            if (TargetInView(player))
            {
                return true;
            }
        }
        else
        {
             Debug.DrawLine(transform.position, player.position, Color.red);
        }
        return false;
    }

    public override bool TargetInView(Transform target)
    {
        if (Physics.Linecast(transform.position, target.position, out hit))
        {
            if (hit.transform.tag != "Wall")
            {
                return true;
            }
        }
        return false;
    }

    public override bool TargetInAttackRange(Transform target)
    {
        if (Vector3.Distance(target.position, transform.position) < AttackRange && TargetInView(target))
        {
            return true;
        }
        return false;
    }

    public override void SetStats(float atcRange, float atcDamage, float atcSpeed, float rangeOfView)
    {
        AttackSpeed = atcSpeed;
        RangeOfView = rangeOfView;
        AttackRange = atcRange;
        AttackDamage = atcDamage;
    }
}
