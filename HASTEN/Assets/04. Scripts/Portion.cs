using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Portion : MonoBehaviour
{
    private int portionCnt;

    private void Start()
    {
        portionCnt = GameMgr.getInst().inven.inven[4].itemCnt;
        this.transform.GetChild(0).GetComponent<Text>().text = portionCnt.ToString();
    }
    public void onPortionClick()
    {
        if(portionCnt > 0)
        {
            GameMgr.getInst().P_State.HP += 50;
            GameMgr.getInst().P_State.HP = GameMgr.getInst().P_State.HP > GameMgr.getInst().P_State.MAXHP ? GameMgr.getInst().P_State.MAXHP : GameMgr.getInst().P_State.HP;
            float hpGage = (float)GameMgr.getInst().P_State.HP / (float)GameMgr.getInst().P_State.MAXHP;
            GameMgr.getInst().PlayerSlider.GetComponent<PlayerHPBar>().Slider(hpGage);
            portionCnt--;
            this.transform.GetChild(0).GetComponent<Text>().text = portionCnt.ToString();
        }
    }
}
