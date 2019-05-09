using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool isOnInventory;
    public GameObject inventory;

    public void onInventory()
    {
        isOnInventory = !isOnInventory;
        inventory.gameObject.SetActive(isOnInventory);
    }
}
