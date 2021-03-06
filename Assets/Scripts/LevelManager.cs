﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class LevelManager : MonoBehaviour
{
    public int id;
    public List<Wave> waves = new List<Wave>();
    public event Action OnLevelPassed;
    private List<EnemyAI> m_CurrentEnemies = new List<EnemyAI>();  // have a base class "enemyType"
    // have my (normal enemy, charger enemy, etc.) derive from enemyType 
    private int m_CurrentWave = 0;

    public void StartLevel()
    {
        UIController.Instance.m_InGameUIController.ShowWaveInfo(m_CurrentWave + 1, waves.Count, StartWave);
    }

    public void StartWave()
    {
        foreach (EnemyAI item in waves[m_CurrentWave].enemies)
        {
            EnemyAI newEnemy = Instantiate(/* enemyType, */ item, GetRandomStartingPosition(), Quaternion.identity);
            m_CurrentEnemies.Add(newEnemy);
            newEnemy.m_ShipHealth.OnDie += RemoveEnemyFromList;
        }
    }

    public void StartNextWave()
    {
        if (m_CurrentWave+1 == waves.Count)
        {
            LevelPassed();
            return;
        }
        m_CurrentWave++;

        StartLevel();
    }

    public void PauseLevel()
    {
        foreach (EnemyAI item in m_CurrentEnemies)
        {
            item.Pause();
        }
    }

    public void ResumeLevel()
    {
        foreach (EnemyAI item in m_CurrentEnemies)
        {
            item.Resume();
        }
    }

    public void ClearCurrentWave() // turned on after an Ad
    {
        while(m_CurrentEnemies.Count >= 1)
        { 
            m_CurrentEnemies[0].m_ShipHealth.Die();
        }
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        m_CurrentEnemies.Remove(enemy.GetComponent<EnemyAI>());
        Debug.Log("enemy died !!! ");
        //check if it was the last active enemy
        if (m_CurrentEnemies.Count == 0)
        {
            // wave cleared
            // start next wave
            StartNextWave();
        }
    }

    public void StopLevel()
    {
        for (int i = 0; i < m_CurrentEnemies.Count; i++)
        {
            Destroy(m_CurrentEnemies[i].gameObject);
        }
        waves.Clear();
        m_CurrentEnemies.Clear();
        OnLevelPassed = null;
    }

    public void LevelPassed()
    {
        OnLevelPassed?.Invoke();
    }

    public Vector3 GetRandomStartingPosition()
    {
        Vector3 startingPos = new Vector3();

        StartingPoint sp = (StartingPoint)UnityEngine.Random.Range(0, 4);
        if (sp == StartingPoint.bottom)
        {
            startingPos = new Vector3(UnityEngine.Random.Range(-96, 28), 0, -28);
        }
        else if (sp == StartingPoint.top)
        {
            startingPos = new Vector3(UnityEngine.Random.Range(-96, 28), 0, 96);
        }
        else if (sp == StartingPoint.left)
        {
            startingPos = new Vector3(-96, 0, UnityEngine.Random.Range(-28, 96));
        }
        else if (sp == StartingPoint.right)
        {
            startingPos = new Vector3(28, 0, UnityEngine.Random.Range(-28, 96));
        }
        return startingPos;
    }
}
