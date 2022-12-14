using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    // Weapons (new() will not work due to outdated C# version)
    [SerializeField] List<GameObject> weapons = new List<GameObject>();
    byte currentWeaponIndex;

    // Activate the default weapon
    private void Awake() {
        // Activate the first weapon
        weapons[0].SetActive(true);
        currentWeaponIndex = 0;
    }

    // Switch weapons when letter e is held
    private void Update()
    {
        // Check for key down
        if (Input.GetKeyDown(KeyCode.F)) SwitchWeapon();
    }

    // Switch the weapon
    private void SwitchWeapon()
    {
        // Deactivate the current weapon
        weapons[currentWeaponIndex].SetActive(false);

        // Activate the next weapon
        currentWeaponIndex = ((byte)(currentWeaponIndex+1 != weapons.Count ? currentWeaponIndex+1 : 0));
        weapons[currentWeaponIndex].SetActive(true);
    }

    // Add weapon
    public void AddWeapon(GameObject weapon) => weapons.Add(weapon); 
}