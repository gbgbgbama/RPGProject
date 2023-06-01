using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int itemId;
    public bool canOverlayItem = false;

    private void Start()
    {
        canOverlayItem = ItemManage.instance.items[itemId].isOverlay;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canOverlayItem && ItemManage.instance.items[itemId].num > 0)
            {
                ItemManage.instance.items[itemId].AddNum();
            }
            else
            {
                if (ItemManage.instance.items[itemId].num == 0) ItemManage.instance.items[itemId].AddNum();
                InventoryItems.itemId = itemId;
                InventoryItems.iconUpdate = true;
            }

            Destroy(gameObject);
        }
    }
}