using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Movement
{
    water,
    flying
}

public enum StartingPoint
{
    top, left, right, bottom
}

public class NormalEnemyMovement : BaseEnemyMovement
{
    public NavMeshAgent agent;
    public StartingPoint m_StartingPoint;
    public float MovementSpeed = 6;

    void Start()
    {
        agent.speed = m_MovementSpeed;
        m_MovementSpeed = MovementSpeed;
    }

    public override void MoveTo(Vector3 position)
    {
        agent.isStopped = false;
        agent.SetDestination(position);
    }

    public override void StopMoving()
    {
        agent.isStopped =true;
    }
}
