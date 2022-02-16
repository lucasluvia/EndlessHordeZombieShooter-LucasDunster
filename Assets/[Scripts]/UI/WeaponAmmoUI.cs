using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponAmmoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI weaponNameText;
    [SerializeField] TextMeshProUGUI currentAmmoCountText;
    [SerializeField] TextMeshProUGUI totalBulletCountText;

    [SerializeField] WeaponComponent weaponComponent;

    void Start()
    {
        weaponComponent = FindObjectOfType<WeaponComponent>();
    }

    void Update()
    {
        if (!weaponComponent)
        {
            weaponComponent = FindObjectOfType<WeaponComponent>();
            if (!weaponComponent) return;
        }

        weaponNameText.text = weaponComponent.weaponStats.weaponName;
        currentAmmoCountText.text = weaponComponent.weaponStats.bulletsInClip.ToString();
        totalBulletCountText.text = weaponComponent.weaponStats.totalBullets.ToString();

    }
}
