using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    NONE,
    PISTOL,
    MACHINE_GUN
}

public enum WeaponFiringPattern
{ 
    SEMI_AUTO,
    FULL_AUTO,
    THREE_SHOT_BURST,
    FIVE_SHOT_BURST
}


[System.Serializable]
public struct WeaponStats
{
    public WeaponType weaponType;
    public WeaponFiringPattern firingPattern;
    public string weaponName;
    public float damage;
    public int bulletsInClip;
    public int clipSize;
    public float fireStartDelay;
    public float fireRate;
    public float fireDistance;
    public LayerMask weaponHitLayers;
}

public class WeaponComponent : MonoBehaviour
{
    public Transform gripLocation;
    protected WeaponHolder weaponHolder;
    public WeaponStats weaponStats;

    public bool isFiring = false;
    public bool isReloading = false;

    protected Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        
    }

    public void Initialize(WeaponHolder _weaponHolder)
    {
        weaponHolder = _weaponHolder;
    }

    // decide whether auto or semi-auto
    public virtual void StartFiringWeapon() 
    {
        isFiring = true;

        switch (weaponStats.firingPattern)
        {
            case WeaponFiringPattern.FULL_AUTO:
                InvokeRepeating(nameof(FireWeapon), weaponStats.fireStartDelay, weaponStats.fireRate);
                break;
            case WeaponFiringPattern.SEMI_AUTO:
                FireWeapon();
                break;
            case WeaponFiringPattern.THREE_SHOT_BURST:
                //for now
                FireWeapon();
                break;
            case WeaponFiringPattern.FIVE_SHOT_BURST:
                //for now
                FireWeapon();
                break;
        }

    }

    public virtual void StopFiringWeapon() 
    {
        isFiring = false;
        CancelInvoke(nameof(FireWeapon));
    }

    protected virtual void FireWeapon() 
    {
        Debug.Log("Firing " + weaponStats.weaponName);
        weaponStats.bulletsInClip--;
    }


}
