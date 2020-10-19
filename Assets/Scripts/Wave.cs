using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    public List<EnemyAI> enemies= new List<EnemyAI>();        // enemyAI could be changed to a base class
                                         // for when we introduce different types of enemy AIs.    
}
