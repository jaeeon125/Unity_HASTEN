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

    public Item(Type type, string name, string cmt)
    {
        this.itemType = type;
        this.itemName = name;
        this.itemCmt = cmt;
    }
}
