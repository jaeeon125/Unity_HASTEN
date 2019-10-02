using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerListAction : MonoBehaviour
{
    public void ButtonClick()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}
