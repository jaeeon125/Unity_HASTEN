using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreNPC : MonoBehaviour
{
    List<Item> storeList = new List<Item>();

    public GameObject StoreBtn;
    public GameObject StorePanel;
    public GameObject CmtImg;
    public Text cmtTxt;
    public bool In = false;
    public bool StoreOn = false;

    private void Start()
    {
        storeList.Add(GameMgr.getInst().I_Mgr.getItem(0));  //파인 애플
        StoreBtn.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            In = true;
            if(!StoreOn)
                StoreBtn.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            In = false;
            StoreBtn.SetActive(false);
        }
    }
    public void OnStore()
    {
        StoreBtn.SetActive(false);
        StorePanel.SetActive(true);
        StoreOn = true;
    }
    public void ExitStore()
    {
        if(In)
            StoreBtn.SetActive(true);
        StorePanel.SetActive(false);
        StoreOn = false;
    }
    public void OnCmt(int number)
    {
        CmtImg.SetActive(true);
        cmtTxt.text = storeList[number].itemName + "\n" + storeList[number].itemCmt;
    }
    public void ExitCmt()
    {
        CmtImg.SetActive(false);
    }
}
