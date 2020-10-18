using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Movement
{
    water,
    flying
}

public class EnemyPathfinding : MonoBehaviour
{
    public NavMeshAgent agent;
    public StartingPoint m_StartingPoint;
    public float m_MovementSpeed = 6;

    void Start()
    {
        agent.speed = m_MovementSpeed;
    }

    public void MoveTo(Vector3 position)
    {
        agent.isStopped = false;
        agent.SetDestination(position);
    }

    public void StopMoving()
    {
        agent.isStopped =true;
    }
}
