using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    private float attackRange;
    private float rangeOfView;
    private float attackDamage;
    private float attackSpeed; // bullets per second


    public float AttackRange { get => attackRange; set => attackRange = value; }
    public float RangeOfView { get => rangeOfView; set => rangeOfView = value; }
    public float AttackDamage { get => attackDamage; set => attackDamage = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    

    public abstract void SetStats(float atcRange, float atcDamage, float atcSpeed, float rangeOfView);

    public abstract void AttackTarget(GameObject target);

    public abstract void Shoot(GameObject target);

    public abstract bool CheckForPlayer();

    public abstract bool TargetInView(Transform target);

    public abstract bool TargetInAttackRange(Transform target);
}
