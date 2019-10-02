using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreBtn : MonoBehaviour
{
    private StoreNPC storeNPC;

    public void Start()
    {
        storeNPC = GameObject.Find("Store_Fairy").GetComponent<StoreNPC>();
    }
    public void OnCmt()
    {
        GameMgr.getInst().ButtonIndex = transform.GetSiblingIndex();
        storeNPC.OnCmt(GameMgr.getInst().ButtonIndex);
    }
}
