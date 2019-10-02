using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SatelliteController : CBuilding
{
    private void Start()
    {
        this.BuildingInit(this.gameObject.name, 100, 50, 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
            other.gameObject.GetComponent<NavMeshAgent>().speed -= 2;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
            other.gameObject.GetComponent<NavMeshAgent>().speed += 2;
    }
}
