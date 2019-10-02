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
        StartCoroutine(waitTime());
        if (other.tag == "Tower" && Dragon.target != GameMgr.getInst().P_State.transform)
            Dragon.target = other.transform;
    }
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(3f);
    }
}
