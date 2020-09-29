using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackingScript : MonoBehaviour
{
    public event Action OnFire = delegate { };

    public void FireMainWeapon()
    {
        OnFire();
    }
}
