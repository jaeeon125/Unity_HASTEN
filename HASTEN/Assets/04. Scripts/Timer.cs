﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public GameObject NightMonster;
    public GameObject BuildMode;

    private float time = 10;
    private bool isNight = false;

    public Text timer;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timer.text = string.Format("{0:00}", time);
        if (time <= 0)
        {
            isNight = !isNight;
            time = 10;
            if(isNight)
            {
                GameMgr.getInst().G_light.intensity = 0.2f;
                GameObject Dragon = Instantiate(Resources.Load("Dragon")) as GameObject;
                Dragon.transform.parent = NightMonster.transform;
                BuildMode.gameObject.SetActive(false);
                GameMgr.getInst().Stage++;
            }
            else
            {
                GameMgr.getInst().G_light.intensity = 1f;
                GameMgr.getInst().Stage++;
                GameMgr.getInst().HASTEN.GetComponent<HASTEN>().HP = GameMgr.getInst().HASTEN.GetComponent<HASTEN>().MAXHP;
                BuildMode.gameObject.SetActive(true);
            }
        }
    }
}
