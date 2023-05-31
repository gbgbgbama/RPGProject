using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int number;
    public bool canOverlayItem = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canOverlayItem && InventoryItems.pickupItemNum[number] > 0)
            {
                InventoryItems.pickupItemNum[number]++;
                print("�񵽵�" + InventoryItems.pickupItemNum[number] + "��" + number + "����Ʒ");
            }
            else
            {
                if (InventoryItems.pickupItemNum[number] == 0) InventoryItems.pickupItemNum[number]++;
                InventoryItems.newIcon = number;
                InventoryItems.iconUpdate = true;
                print("�񵽵�" + InventoryItems.pickupItemNum[number] + "��" + number + "����Ʒ");
            }

            Destroy(gameObject);
        }
    }
}