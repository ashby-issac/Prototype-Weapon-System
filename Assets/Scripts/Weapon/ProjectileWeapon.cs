using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    protected override void Spawn()
    {
        Instantiate(vfxPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public override void Fire()
    {
        base.Fire();
        
        Debug.Log($" ProjectileWeapon ");
        // Extra functionality
    }
}