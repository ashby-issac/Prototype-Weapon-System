using UnityEngine;

public enum EWeaponType
{
    None,
    Fireball,
    Iceball,
    Electric
}

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    
    [SerializeField] protected int ammos;
    [SerializeField] protected int magCap;
    [SerializeField] protected float fireRate;
    [SerializeField] protected EWeaponType weaponType;

    public EWeaponType WeaponType;
    
    public abstract void Fire();
}