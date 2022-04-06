using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable", order = 1)]
public class ConsumableScriptable : ItemScript
{
    public int effect = 0;

    public override void UseItem(PlayerController playerController)
    {
        // check to see player health
        // heal player with potion

        // set amt -1
        // if amt == 0, remove from inventory

        SetAmount(amountValue - 1);
        if (amountValue <= 0)
        {
            DeleteItem(playerController);
        }

    }

}
