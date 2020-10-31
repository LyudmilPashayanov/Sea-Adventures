using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDeployer : MonoBehaviour
{
    public WallTrap m_wallPrefab; // a base one in the future
    public List<WallTrap> m_deployedTraps;
    public WallTrap m_trapForDeploing;
    public Transform m_parentForTraps;
    public Transform m_DeployedTraps;

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        PreviewTrap();
    //    }
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        DeployTrap();
    //    }
    //}

    public void DeployTrap()
    {
        m_deployedTraps.Add(m_trapForDeploing);
        if (m_deployedTraps.Count > m_wallPrefab.m_maxTraps)
        {
            Destroy(m_deployedTraps[0].gameObject);
            m_deployedTraps.RemoveAt(0);
        }
        m_trapForDeploing.transform.SetParent(m_DeployedTraps);
        m_trapForDeploing.OnDeployed();
        m_trapForDeploing.OnDestroyed += RemoveTrap;
        UIController.Instance.m_InGameUIController.SetDeployTrapButton(false);
    }

    public void PreviewTrap()
    {
        m_trapForDeploing = Instantiate(m_wallPrefab, m_parentForTraps, false);
        UIController.Instance.m_InGameUIController.SetDeployTrapButton(true);
    }

    public void CancelTrapDeployment()
    {
        UIController.Instance.m_InGameUIController.SetDeployTrapButton(false);
        Destroy(m_trapForDeploing.gameObject);
    }

    public void RemoveTrap(WallTrap trapForRemoval)
    {
        int counter = 0;
        for (int i = 0; i < m_deployedTraps.Count; i++)
        {
            counter = i;
            if (m_deployedTraps[i] == trapForRemoval)
            {
                break;
            }           
        }
        m_deployedTraps.RemoveAt(counter);
    }

    public void RemoveAllTraps()
    {
        int allTraps = m_deployedTraps.Count;
        for (int i = 0; i < allTraps; i++)
        {
            Destroy(m_deployedTraps[i].gameObject);
            m_deployedTraps.RemoveAt(i);
        }
    }
}
