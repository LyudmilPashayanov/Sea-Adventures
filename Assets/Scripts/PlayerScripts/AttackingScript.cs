using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackingScript : MonoBehaviour
{
    public event Action OnFire = delegate { };
    public float attackSpeed = 0.4f;
    private bool cooldown;

    private void Update()
    {
        if (cooldown)
        {
            attackSpeed -= Time.deltaTime;
            if(attackSpeed <=0)
            {
                cooldown = false;
                attackSpeed = 0.4f;
            }
        }
    }

    public void FireMainWeapon()
    {
        if (cooldown == false)
        {
            OnFire();
            cooldown = true;
        }
    }
}
