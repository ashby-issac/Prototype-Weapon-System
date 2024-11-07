using UnityEngine;

public class IceWeapon : Weapon
{
    public override void Fire()
    {
        Debug.Log("Fire Iceball");
        Debug.Log("Spawn the iceball");
    }
}