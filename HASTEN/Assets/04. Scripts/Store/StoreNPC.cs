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

    public GameObject PortionCnt;
    private void Start()
    {
        storeList.Add(GameMgr.getInst().I_Mgr.getItem(0));  //파인 애플
        storeList.Add(GameMgr.getInst().I_Mgr.getItem(1));  //무기
        storeList.Add(GameMgr.getInst().I_Mgr.getItem(2));  //무기
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
        if (In)
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
    public void PurchaseItem()
    {
        int index = GameMgr.getInst().ButtonIndex;
        Debug.Log(index);
        switch (index)
        {
            case 0:
                if(int.Parse(GameMgr.getInst().I_Mgr.GoldText.text.ToString()) >= 30)
                {
                    GameMgr.getInst().I_Mgr.gainGold(-30);
                    GameMgr.getInst().inven.inven[4].itemCnt++;
                    PortionCnt.GetComponent<Text>().text = GameMgr.getInst().inven.inven[4].itemCnt.ToString();
                }
                break;
            case 1:
                if (int.Parse(GameMgr.getInst().I_Mgr.GoldText.text.ToString()) >= 100 && int.Parse(GameMgr.getInst().I_Mgr.WoodText.text.ToString()) >= 10)
                {
                    GameMgr.getInst().I_Mgr.gainGold(-100);
                    GameMgr.getInst().I_Mgr.gainWood(-10);
                    GameMgr.getInst().P_State.POWER += 10;
                }
                break;
            case 2:
                if (int.Parse(GameMgr.getInst().I_Mgr.GoldText.text.ToString()) >= 0 && int.Parse(GameMgr.getInst().I_Mgr.WoodText.text.ToString()) >= 0)
                {
                    GameMgr.getInst().I_Mgr.gainGold(-100);
                    GameMgr.getInst().I_Mgr.gainWood(-10);
                    GameMgr.getInst().P_State.ARMOR -= 100;
                }
                break;
        }
    }
}
