using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraCtrl : MonoBehaviour
{
    public Transform Target;

    private bool TouchScreen = false;
    private float firstTouch = 0f;

    private float Distance_Y = 19;
    private float Distance_Z = 16;

    private Vector3 targetPos = Vector3.zero;

    private float dragSpeed = 10f;

    void Start()
    {
        targetPos = Target.position;
        transform.position = new Vector3(targetPos.x, targetPos.y + Distance_Y, targetPos.z - Distance_Z);
        transform.LookAt(Target);
        StartCoroutine(FollowCam());
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                TouchScreen = true;
                StartCoroutine(ScreenMove());
            }
        }
        if (Input.GetMouseButtonUp(0) && TouchScreen)
            TouchScreen = false;
    }
    IEnumerator ScreenMove()
    {
        while (TouchScreen)
        {
            firstTouch = Input.mousePosition.x;
            yield return null;
            float dist = firstTouch - Input.mousePosition.x;
            
            if (dist > 0)
                this.transform.RotateAround(Target.position, Vector3.down, dragSpeed * Time.deltaTime * Mathf.Abs(dist));
            else if (dist < 0)
                this.transform.RotateAround(Target.position, Vector3.up, dragSpeed * Time.deltaTime * Mathf.Abs(dist));

            yield return null;
        }
    }
    IEnumerator FollowCam()
    {
        while (true)
        {
            Vector3 befPos = Target.position;
            yield return null;
            Vector3 curPos = Target.position;

            this.transform.position -= (befPos - curPos);
        }
    }


    //void Rayser()
    //{
    //    Vector3 ScreenPos = Camera.main.WorldToScreenPoint(playerCollider.transform.position);
    //    Ray ray = Camera.main.ScreenPointToRay(ScreenPos);
    //    RaycastHit[] hitInfos = Physics.RaycastAll(ray);
    //    foreach (RaycastHit hitInfo in hitInfos)
    //    {
    //        Debug.Log(hitInfo.collider.name);
    //        if ((hitInfo.collider.gameObject.tag != "Player") && (hitInfo.collider.gameObject.tag != "Monster"))
    //        {
    //            Material translucent = hitInfo.collider.gameObject.GetComponent<Renderer>().material;
    //            translucent.SetFloat("_Mode", 2);
    //            translucent.color = new Color(translucent.color.r, translucent.color.g, translucent.color.b, 0.5f);
    //            translucent.renderQueue = 3000;
    //        }

    //    }
    //}
}