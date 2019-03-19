using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform Target;

    public float Distance_Z = 8.0f;
    public float Distance_Y = 10.0f;
    private Vector3 targetPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = Target.position;
        transform.position = new Vector3(targetPos.x, targetPos.y + Distance_Y, targetPos.z - Distance_Z);
        transform.LookAt(Target);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetPos = Target.position;
        transform.position = new Vector3(targetPos.x, targetPos.y + Distance_Y, targetPos.z - Distance_Z);
    }
}
