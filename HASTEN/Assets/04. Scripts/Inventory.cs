using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryPanel;
    private bool isOnInventory;

    public void onInventory()
    {
        if (isOnInventory)
            InventoryPanel.gameObject.SetActive(false);
        else
            InventoryPanel.gameObject.SetActive(true);
        isOnInventory = !isOnInventory;
    }
}
