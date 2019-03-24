using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Potal : CommonBuilding
{
    public Transform LinkPotal;

    public override void Active()
    {
        GameMgr.getInst().P_Trans.GetComponent<NavMeshAgent>().enabled = false;
        GameMgr.getInst().P_Trans.position = LinkPotal.position;
        GameMgr.getInst().P_Trans.GetComponent<NavMeshAgent>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            GameMgr.getInst().P_Trans.GetComponentInChildren<PlayerCtrl>().potal = this;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            GameMgr.getInst().P_Trans.GetComponentInChildren<PlayerCtrl>().potal = null;
    }
}
