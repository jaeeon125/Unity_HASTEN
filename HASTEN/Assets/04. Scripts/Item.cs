using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item 
{
    public enum Type
    {
        Use, Mat
    }
    public Type itemType;
    public string itemName;
    public string itemCmt;
    public int itemCnt;

    public Item(Type type, string name, string cmt)
    {
        this.itemType = type;
        this.itemName = name;
        this.itemCmt = cmt;
    }

    public Item(Type type, string name, int cnt)
    {
        this.itemType = type;
        this.itemName = name;
        this.itemCnt = cnt;
    }
}
