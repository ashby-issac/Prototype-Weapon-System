using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private CombatSystem combatSystem;

    [SerializeField] private Button FireWeaponButton, IceWeaponButton, ElectricWeaponButton;
    [SerializeField] private Button FireButton;

    private void OnEnable()
    {
        FireWeaponButton.onClick.AddListener(() => SetNewWeapon(EWeaponType.Fireball));
        IceWeaponButton.onClick.AddListener(() => SetNewWeapon(EWeaponType.Iceball));
        ElectricWeaponButton.onClick.AddListener(() => SetNewWeapon(EWeaponType.Electric));
        FireButton.onClick.AddListener(() => FireWeapon());
    }

    private void OnDisable()
    {
        FireWeaponButton.onClick.RemoveAllListeners();
        IceWeaponButton.onClick.RemoveAllListeners();
        ElectricWeaponButton.onClick.RemoveAllListeners();

        FireButton.onClick.RemoveAllListeners();
    }

    public void SetNewWeapon(EWeaponType weaponType)
    {
        combatSystem.SwitchWeapon(weaponType);
    }

    public void FireWeapon()
    {
        combatSystem.FireWeapon();
    }
}