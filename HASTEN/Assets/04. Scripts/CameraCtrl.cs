using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private Camera myCamera;
    public Transform Target;
    public int Distance = 6;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = Target.position;
        myCamera.transform.LookAt(Target);
        myCamera.transform.position = new Vector3(targetPos.x, targetPos.y + Distance, targetPos.z - Distance);
    }
}
