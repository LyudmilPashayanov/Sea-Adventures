using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    public enum StartingPoint
    {
        top,left,right,bottom
    }

    public NavMeshAgent agent;
    public StartingPoint m_StartingPoint;
    public float m_MovementSpeed = 6;
    void Start()
    {
       transform.position = GetRandomStartingPosition();
        agent.speed = m_MovementSpeed;
    }

    public Vector3 GetRandomStartingPosition()
    {
        Vector3 startingPos = new Vector3();

        StartingPoint sp = (StartingPoint)Random.Range(0, 3);
        m_StartingPoint = sp;

        if(m_StartingPoint == StartingPoint.bottom)
        {
            startingPos = new Vector3(Random.Range(-100, 30), 0, -30);
        }
        else if (m_StartingPoint == StartingPoint.top)
        {
            startingPos = new Vector3(Random.Range(-100, 30), 0, 100);
        }
        else if (m_StartingPoint == StartingPoint.left)
        {
            startingPos = new Vector3(-100, 0, Random.Range(-30, 100));
        }
        else if (m_StartingPoint == StartingPoint.right)
        {
            startingPos = new Vector3(30, 0, Random.Range(-30, 100));
        }
        return startingPos;
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
