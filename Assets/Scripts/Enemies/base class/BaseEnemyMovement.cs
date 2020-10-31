using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyMovement: MonoBehaviour
{
    public float m_MovementSpeed;

    public abstract void MoveTo(Vector3 position);
    public abstract void StopMoving();
}