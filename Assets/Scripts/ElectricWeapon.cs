using UnityEngine;

public class ElectricWeapon : Weapon
{
    public override void Fire()
    {
        Debug.Log("Fire Electric beam");
        Debug.Log("Spawn the electric beam");
    }
}
