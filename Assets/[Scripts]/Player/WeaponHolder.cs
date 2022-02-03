using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private GameObject weaponToSpawn;
    [SerializeField] private GameObject weaponSocket;

    private PlayerController playerController;
    Sprite crosshairImage;

    void Start()
    {
        GameObject spawnedWeapon = Instantiate(weaponToSpawn, weaponSocket.transform.position, weaponSocket.transform.rotation, weaponSocket.transform);
        
    }

    void Update()
    {
        
    }
}
