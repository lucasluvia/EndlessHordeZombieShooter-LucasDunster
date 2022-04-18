using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] float turretLifetime = 5.0f;
    GameObject player;
    bool playerContained;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Object.Destroy(gameObject, turretLifetime);
    }

    float elapsed = 0f;
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            if (playerContained)
            {
                player.GetComponent<PlayerHealthComponent>().TakeDamage(-1f);

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerContained = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerContained = false;
        }
    }
}
