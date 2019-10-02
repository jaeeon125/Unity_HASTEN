using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerListButton : MonoBehaviour
{
    private RectTransform rectTransform;
    private bool isActive;

    public GameObject AttackUI;
    public GameObject JumpUI;
    public GameObject PortionUI;
    public GameObject JoyStick;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
        isActive = false;
    }

    public void onClick()
    {
        if (!isActive)
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "종료";
            Time.timeScale = 0;
            AttackUI.gameObject.SetActive(false);
            JumpUI.gameObject.SetActive(false);
            PortionUI.gameObject.SetActive(false);
            JoyStick.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "제작 모드";
            Time.timeScale = 1;
            AttackUI.gameObject.SetActive(true);
            JumpUI.gameObject.SetActive(true);
            PortionUI.gameObject.SetActive(true);
            JoyStick.gameObject.SetActive(true);
        }
        isActive = !isActive;
    }
}
