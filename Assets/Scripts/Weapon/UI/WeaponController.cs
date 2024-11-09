using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[Serializable]
public class WeaponUIData
{
    public EWeaponType type;
    public Sprite img;
}

public class WeaponController : MonoBehaviour
{
    [SerializeField] private CombatSystem combatSystem;
    [SerializeField] private WeaponUIData[] weaponImages;
    
    [SerializeField] private Image equippedWeaponImage;
    [SerializeField] private Button FireWeaponButton, IceWeaponButton, ElectricWeaponButton;
    [SerializeField] private Button FireButton;

    [SerializeField] private TextMeshProUGUI fpsText;
    [SerializeField] private TextMeshProUGUI equipWeaponText;

    private void OnEnable()
    {
        FireWeaponButton.onClick.AddListener(() => SetNewWeapon(EWeaponType.Fireball));
        IceWeaponButton.onClick.AddListener(() => SetNewWeapon(EWeaponType.Iceball));
        ElectricWeaponButton.onClick.AddListener(() => SetNewWeapon(EWeaponType.Electric));
        FireButton.onClick.AddListener(() => FireWeapon());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Debug.Log($":: Fire");
            FireWeapon();
        }
        
        float fps = 1.0f / Time.deltaTime;
        fpsText.text = $"FPS: {Mathf.RoundToInt(fps)}";
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
        DisplayEquippedWeapon(weaponType);
    }

    private void DisplayEquippedWeapon(EWeaponType weaponType)
    {
        foreach (WeaponUIData data in weaponImages)
        {
            if (data.type == weaponType)
            {
                equipWeaponText.text = data.type.ToString();
                equippedWeaponImage.sprite = data.img;
            }
        }
    }

    public void FireWeapon()
    {
        combatSystem.FireWeapon();
    }
}