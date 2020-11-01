using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class WallTrap : MonoBehaviour
{
    public int m_maxTraps = 3;
    public NavMeshObstacle m_navMeshComponent;
    public Material m_solidMat;
    public Action<WallTrap> OnDestroyed;

    public void OnDeployed()
    {
        m_navMeshComponent.enabled = true;
        gameObject.GetComponent<MeshRenderer>().material = m_solidMat;
        gameObject.tag = "Wall";
    }

    public void DestroyTrap()
    {
        OnDestroyed?.Invoke(this);
        Destroy(gameObject);
    }

    
}
