using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private Camera myCamera;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position;
        myCamera.transform.position = new Vector3(targetPos.x, targetPos.y + 6, targetPos.z - 8);
    }
}
