using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class EnemyAttack : MonoBehaviour
{
    private float attackRange;
    private float attackDamage;
    private float attackSpeed; // bullets per second

    public float AttackRange { get => attackRange; set => attackRange = value; }
    public float AttackDamage { get => attackDamage; set => attackDamage = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }


    public virtual void SetStats(float atcRange, float atcDamage, float atcSpeed)
    {
        AttackSpeed = atcSpeed;
        AttackRange = atcRange;
        AttackDamage = atcDamage;
    }

    public abstract void AttackTarget(GameObject target);

    public abstract void Shoot(GameObject target);

    public abstract bool TargetInAttackRange(Transform target);
}
