using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum EWeaponType
{
    None,
    Fireball,
    Iceball,
    Electric
}

public interface IFire
{
    void Fire();
}

public abstract class Weapon : MonoBehaviour, IFire
{
    [SerializeField] protected EWeaponType weaponType;
    [SerializeField] protected GameObject vfxPrefab;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected Material weaponEffectMat;
    [SerializeField] protected MeshRenderer meshRenderer;

    [SerializeField] protected int ammos;
    [SerializeField] protected int magCap;
    [SerializeField] protected float fireRate;

    public EWeaponType WeaponType => weaponType;

    protected bool canFire = true;
    protected  float fireTimer;

    protected abstract void Spawn();
    
    public virtual void Fire()
    {
        if (canFire)
        {
            canFire = false;
            fireTimer = 0;
            Spawn();
        }
    }

    private void OnEnable()
    {
        ChangeWeaponEffects();
    }

    private void Update()
    {
        if (!canFire && fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
        else
        {
            fireTimer = 0;
            canFire = true;
        }
    }

    public void ChangeWeaponEffects()
    {
        meshRenderer.material = weaponEffectMat;
    }
}