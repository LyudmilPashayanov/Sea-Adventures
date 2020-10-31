using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        FocusIsland,
        ChasePlayer,
        AttackTarget,
        AttackIsland,
        Pause
    }

    private State m_CurrentState;
    public BaseEnemyMovement m_PathfindingScript;

    public BaseEnemyAttack m_EnemyAttack;
    public BaseEnemyEyes m_EnemyEyes;
    public BaseHealth m_ShipHealth;

    public HealthBarController m_HealthBarController;
    private State m_LastActiveState;

    public EnemyCanvasController m_EnemyCanvas;

    private void Awake()
    {
        m_ShipHealth = GetComponent<BaseHealth>();
        m_ShipHealth.TakeDamageEvent += m_HealthBarController.ReduceHealth;
        m_HealthBarController.SetMaxHealth(m_ShipHealth.GetMaxHealth());
    }

    private void Update()
    {
        switch (m_CurrentState)
        {
            default:

            case State.FocusIsland:
                ChaseIsland();
                LookingForPlayer();
                break;

            case State.ChasePlayer:
                ChasePlayer();
                break;

            case State.AttackTarget:
                AttackPlayer();
                break;

            case State.AttackIsland:
                AttackIsland();
                break;

            case State.Pause:

                break;
        }
    }

    public void LookingForPlayer()
    {
        if (m_EnemyEyes.CheckForPlayer())
        {
            m_CurrentState = State.ChasePlayer;
        }
    }

    public void ChaseIsland()
    {
        m_EnemyCanvas.NoSign();
        Vector3 islandPos = IslandManager.Instance.transform.position;
        m_PathfindingScript.MoveTo(islandPos);
        if (Vector3.Distance(transform.position, islandPos) < m_EnemyAttack.AttackRange) // in range of island
        {
            m_CurrentState = State.AttackIsland;
        }
    }

    public void Pause()
    {
        m_LastActiveState = m_CurrentState;
        m_PathfindingScript.StopMoving();
        m_EnemyCanvas.NoSign();
        m_CurrentState = State.Pause;
    }

    public void Resume()
    {
        m_CurrentState = m_LastActiveState;
    }

    public void AttackPlayer()
    {
        Transform player = PlayerController_mobileJoystick.Instance.transform;
        m_EnemyCanvas.AttackMode();
        Debug.DrawLine(transform.position, PlayerController_mobileJoystick.Instance.transform.position, Color.green);
        if (m_EnemyAttack.TargetInAttackRange(player) && m_EnemyEyes.TargetInView(player))
        {
            m_PathfindingScript.StopMoving();
            m_EnemyAttack.AttackTarget(PlayerController_mobileJoystick.Instance.gameObject);
        }
        else if(m_EnemyEyes.TargetInView(player))
        {
            m_CurrentState = State.ChasePlayer;
        }
        else
        {
            m_CurrentState = State.FocusIsland;
        }   
    }

    public void AttackIsland()
    {
        m_PathfindingScript.StopMoving();
        m_EnemyCanvas.AttackMode();
        m_EnemyAttack.AttackTarget(IslandManager.Instance.gameObject);
    }

    public void ChasePlayer()
    {
        m_EnemyCanvas.FollowingMode();
        Transform player = PlayerController_mobileJoystick.Instance.transform;
        if (m_EnemyAttack.TargetInAttackRange(player))
        {
            m_PathfindingScript.StopMoving();
            m_CurrentState = State.AttackTarget;
        }
        else
        {   if(m_EnemyEyes.CheckForPlayer())
            {
                m_PathfindingScript.MoveTo(player.position);
            }
            else
            {
                m_CurrentState = State.FocusIsland;
            }
        }
    }
}
