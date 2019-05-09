using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
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
=======
public class Inventory 
{
>>>>>>> develop
}
