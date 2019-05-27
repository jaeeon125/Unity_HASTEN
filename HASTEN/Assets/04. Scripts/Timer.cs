using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    private float time = 300;
    private bool isNight;

    public Text timer;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timer.text = string.Format("{0:00}", time);
        if (time <= 0)
        {
            time = 300;
            if(isNight)
                GameMgr.getInst().G_light.intensity = 0.2f;
            else
            {
                GameMgr.getInst().G_light.intensity = 1f;
                GameMgr.getInst().Stage++;
                GameMgr.getInst().HASTEN.GetComponent<HASTEN>().HP = GameMgr.getInst().HASTEN.GetComponent<HASTEN>().MAXHP;
            }
                
            isNight = !isNight;
        }
    }
}
