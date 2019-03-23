using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform Target;

    public float Distance_Z;
    public float Distance_Y;
    private Vector3 targetPos = Vector3.zero;

    void Start()
    {
        targetPos = Target.position;
        transform.position = new Vector3(targetPos.x, targetPos.y + Distance_Y, targetPos.z - Distance_Z);
        transform.LookAt(Target);
    }

    void LateUpdate()
    {
        targetPos = Target.position;
        transform.position = new Vector3(targetPos.x, targetPos.y + Distance_Y, targetPos.z - Distance_Z);
    }

}
