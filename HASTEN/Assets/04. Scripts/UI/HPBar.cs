using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    private Slider SliderBar;
    private float time;

    private void Awake()
    {
        SliderBar = GameMgr.getInst().HPBar;
        time = 3f;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if(time<=0)
            this.gameObject.SetActive(false);
        GameMgr.getInst().IsHPBarActive = false;
    }

    public void Slider(float hpPercent)
    {
        time = 3f;
        SliderBar.value = hpPercent;
    }
}
