using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> inven = new List<Item>();
    private bool isOnInventory;
    public GameObject inventory;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;

    private void Start()
    {
        inven.Add(new Item(Item.Type.Mat, "Red Crystal", 0));
        inven.Add(new Item(Item.Type.Mat, "Blue Crystal", 0));
        inven.Add(new Item(Item.Type.Mat, "Yellow Crystal", 0));
        inven.Add(new Item(Item.Type.Mat, "Spider Web", 0));
    }
    public void onInventory()
    {
        isOnInventory = !isOnInventory;
        if (isOnInventory)
            setItemCnt();
        inventory.gameObject.SetActive(isOnInventory);
    }

    public void gainItem(string name, int cnt)
    {
        foreach(Item _item in inven)
        {
            if (_item.itemName == name)
            {
                _item.itemCnt += cnt;
                return;
            }
        }
    }

    void setItemCnt()
    {
        foreach(Item _item in inven)
        {
            switch (_item.itemName)
            {
                case "Red Crystal":
                    item1.transform.GetChild(2).GetComponent<Text>().text = _item.itemCnt.ToString();
                    break;
                case "Blue Crystal":
                    item2.transform.GetChild(2).GetComponent<Text>().text = _item.itemCnt.ToString();
                    break;
                case "Yellow Crystal":
                    item3.transform.GetChild(2).GetComponent<Text>().text = _item.itemCnt.ToString();
                    break;
                case "Spider Web":
                    item4.transform.GetChild(2).GetComponent<Text>().text = _item.itemCnt.ToString();
                    break;
                default:
                    Debug.Log("error : Item Road");
                    break;
            }
        }
        
    }
}
