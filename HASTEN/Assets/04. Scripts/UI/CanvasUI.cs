using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(Camera.main.transform);
        //this.transform.Rotate(0, this.transform.rotation.y, this.transform.rotation.z);
    }
}
