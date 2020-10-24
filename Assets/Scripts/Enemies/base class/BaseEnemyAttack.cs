using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class BaseEnemyAttack : MonoBehaviour
{
    private int attackRange;
    private int attackDamage;
    private int attackSpeed; // bullets per second
           
    public int AttackRange { get => attackRange; set => attackRange = value; }
    public int AttackDamage { get => attackDamage; set => attackDamage = value; }
    public int AttackSpeed { get => attackSpeed; set => attackSpeed = value; }


    public virtual void SetStats(int atcRange, int atcDamage, int atcSpeed)
    {
        AttackSpeed = atcSpeed;
        AttackRange = atcRange;
        AttackDamage = atcDamage;
    }

    public abstract void AttackTarget(GameObject target);

    public abstract void Shoot(GameObject target);

    public abstract bool TargetInAttackRange(Transform target);
}
