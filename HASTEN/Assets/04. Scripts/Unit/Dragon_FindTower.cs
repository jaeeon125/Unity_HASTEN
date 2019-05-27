using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_FindTower : MonoBehaviour
{
    private DragonController Dragon;
    private void Start()
    {
        Dragon = GetComponentInParent<DragonController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Tower" && Dragon.target != GameMgr.getInst().P_State.transform)
            Dragon.target = other.transform;
    }
}
