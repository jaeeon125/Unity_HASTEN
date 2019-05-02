using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Inventory playerInven; //플레이어 인벤토리
    public enum Type
    {
        Use, Mat
    }
    //string, 이미지, 설명, 
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.tag=="Item")
        {
            Debug.Log("A");
            playerInven.gainItem(other.name);
            Destroy(this);
            
        }
    }
}
