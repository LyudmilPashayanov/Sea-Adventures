using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        FocusMPI,
        ChasePlayer,
        AttackTarget,
        AttackIsland
    }

    private State m_CurrentState;
    public Vector3 m_StartingPosition;
    public EnemyPathfinding m_PathfindingScript;
    public EnemyAttack m_EnemyAttack;
    private void Update()
    {
        switch (m_CurrentState)
        {
            default:
            case State.FocusMPI:
                FindIsland();
                FindTarget();
                break;
            case State.ChasePlayer:
                ChasePlayer();
                break;
            case State.AttackTarget:
                m_EnemyAttack.AttackTarget(PlayerController_mobileJoystick.Instance.gameObject);

                break;
            case State.AttackIsland:
                AttackIsland();
                break;
        }
    }

    public void FindTarget()
    {
        if(Vector3.Distance(transform.position,PlayerController_mobileJoystick.Instance.transform.position) < m_EnemyAttack.m_RangeOfView)
        {
            m_CurrentState = State.ChasePlayer;
        }
    }

    public void FindIsland()
    {
        Vector3 islandPos = IslandManager.Instance.transform.position;
        m_PathfindingScript.MoveTo(islandPos);
        if (Vector3.Distance(transform.position, islandPos) < m_EnemyAttack.m_AttackRange) // in range of island
        {
            m_CurrentState = State.AttackIsland;
        }
    }

    public void AttackIsland()
    {
        m_PathfindingScript.StopMoving();
        m_EnemyAttack.AttackTarget(IslandManager.Instance.gameObject);
    }

    public void ChasePlayer()
    {
        Vector3 playerPos = PlayerController_mobileJoystick.Instance.transform.position;
        
        if(Vector3.Distance(playerPos,transform.position) < m_EnemyAttack.m_AttackRange)
        {
            m_PathfindingScript.StopMoving();
            m_EnemyAttack.AttackTarget(PlayerController_mobileJoystick.Instance.gameObject);
        }
        else
        {   if(Vector3.Distance(playerPos, transform.position) < m_EnemyAttack.m_RangeOfView+3)
            {
                m_PathfindingScript.MoveTo(playerPos);
            }
            else
            {
                m_CurrentState = State.FocusMPI;
            }
        }
    }
}
