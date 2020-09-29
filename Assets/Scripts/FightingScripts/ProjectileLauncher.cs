using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    private Projectile m_ProjectivePrefab;
    [SerializeField]
    private Transform m_WeaponMountPoint;


    public void Awake()
    {
        gameObject.GetComponent<AttackingScript>().OnFire += HandleFire;
    }

    private void HandleFire()
    {
        Rigidbody spawnedProjectile = Instantiate(m_ProjectivePrefab.GetComponent<Rigidbody>(), m_WeaponMountPoint.position, m_WeaponMountPoint.rotation);
        spawnedProjectile.AddForce(spawnedProjectile.transform.forward * m_ProjectivePrefab.m_Speed);
    }
}
