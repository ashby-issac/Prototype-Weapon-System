using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private List<Weapon> availableweapons = new List<Weapon>();
    [SerializeField] private EWeaponType currentWeaponType;
    
    private Weapon currentWeapon;

    public void SwitchWeapon(EWeaponType weaponType)
    {
        var weaponIndex = availableweapons.FindIndex(availWeapon => availWeapon.WeaponType == weaponType);
        if (weaponIndex != -1)
        {
            currentWeaponType = availableweapons[weaponIndex].WeaponType;
            currentWeapon = availableweapons[weaponIndex];
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
