using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingEvent : MonoBehaviour
{
    public GameObject timer;
    public GameObject wood;
    public GameObject gold;
    public GameObject buildMode;
    public GameObject inventory;
    public GameObject portion;
    public GameObject attack;
    public GameObject jump;
    public GameObject joyStick;
    public GameObject settingCanvas;

    private bool isActive;

    public void onClick()
    {
        timer.gameObject.SetActive(isActive);
        wood.gameObject.SetActive(isActive);
        gold.gameObject.SetActive(isActive);
        buildMode.gameObject.SetActive(isActive);
        inventory.gameObject.SetActive(isActive);
        portion.gameObject.SetActive(isActive);
        attack.gameObject.SetActive(isActive);
        jump.gameObject.SetActive(isActive);
        joyStick.gameObject.SetActive(isActive);
        settingCanvas.gameObject.SetActive(!isActive);

        if (isActive)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
        isActive = !isActive;
    }
}
