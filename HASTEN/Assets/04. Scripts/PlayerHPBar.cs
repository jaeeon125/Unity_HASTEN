using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHPBar : MonoBehaviour
{
    private Slider PlayerHP;

    private void Start()
    {
        PlayerHP = GameMgr.getInst().PlayerSlider;
        //PlayerHP.GetComponent<RectTransform>().sizeDelta =
        //    new Vector2(GameMgr.getInst().ControllCanvas.GetComponent<RectTransform>().rect.width, 50);
    }

    public void Slider(float hpPercent)
    {
        PlayerHP.value = hpPercent;
    }
}