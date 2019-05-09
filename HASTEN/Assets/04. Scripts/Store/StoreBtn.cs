using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreBtn : MonoBehaviour
{
    public int BtnNumber;
    private StoreNPC storeNPC;

    public void Start()
    {
        storeNPC = GameObject.Find("Store_Fairy").GetComponent<StoreNPC>();
    }
    public void OnCmt()
    {
        storeNPC.OnCmt(this.BtnNumber);
    }
}
