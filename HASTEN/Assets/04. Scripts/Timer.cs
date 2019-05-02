using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    private float time = 300;
    public Text timer;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timer.text = string.Format("{0:00}", time);
        if (time <= 0)
            time = 300;
    }
}
