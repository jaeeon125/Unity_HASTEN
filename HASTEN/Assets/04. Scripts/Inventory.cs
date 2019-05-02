using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Item
{
    Dictionary<string, int> item;

    public void gainItem(string name)
    {
        if (item.ContainsKey(name))
            item[name]++;
        else
            item.Add(name, 1);
    }

    void useItem(string name, int cnt)
    {
        if (item[name] > cnt)
            item[name] -= cnt;
        else
            item.Remove(name);
    }

    void inventoryClick()
    {
        int size = item.Count;
        //for (int i = 0; i < size; i++)
            
    }
}
