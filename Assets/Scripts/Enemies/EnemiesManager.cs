using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public EnemyAI enemyPrefab;
    public List<EnemyAI> enemies = new List<EnemyAI>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemies.Add(Instantiate(enemyPrefab));
        }
    }
}
