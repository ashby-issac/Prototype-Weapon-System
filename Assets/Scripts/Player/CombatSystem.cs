using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class WeaponData
{
    public EWeaponType type;
    public Weapon weapon;
}

public class CombatSystem : MonoBehaviour
{
    // Initialize in the inspector for testing or add data when equipping weapons
    [SerializeField] private List<WeaponData> availWeaponDatas = new List<WeaponData>(); // Fire, Ice, Electric

    private EWeaponType currentWeaponType = EWeaponType.None;
    private Weapon currentWeapon = null;

    public void SwitchWeapon(EWeaponType weaponType)
    {
        if (currentWeapon != null)
            currentWeapon.gameObject.SetActive(false);

        var weaponData = availWeaponDatas.Find(availWeapon => availWeapon.type == weaponType);
        if (weaponData != null)
        {
            currentWeaponType = weaponData.type;
            currentWeapon = weaponData.weapon;
            currentWeapon.gameObject.SetActive(true);
        }
    }

    public void FireWeapon()
    {
        if (currentWeapon)
            currentWeapon.Fire();
        else
            Debug.Log("No weapon selected");
    }
}