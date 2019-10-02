using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : CBuilding
{
    public GameObject particle;
    bool isTarget;
    int monsterID;
    // Start is called before the first frame update
    void Start()
    {
        this.BuildingInit(this.gameObject.name, 100, 50, 10);
        isTarget = false;
        monsterID = -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy") && monsterID == -1)
        {
            monsterID = other.gameObject.GetInstanceID();
            isTarget = true;
            StartCoroutine(TowerAttack(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetInstanceID() == monsterID)
        {
            isTarget = false;
            monsterID = -1;
        }
            
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if(!isTarget && other.gameObject.tag.Equals("Enemy"))
    //    {
    //        monsterID = other.gameObject.GetInstanceID();
    //        isTarget = true;
    //        StartCoroutine(TowerAttack(other));
    //    }
    //}

    IEnumerator TowerAttack(Collider other)
    {
        while(isTarget)
        {
            Vector3 flame_pos = new Vector3(this.transform.position.x, this.transform.position.y + 10, this.transform.position.z);
            GameObject flame = Instantiate(particle, flame_pos, particle.transform.rotation);
            flame.transform.LookAt(other.transform.position);
            //while (flame)
            //{
            //    flame.transform.LookAt(other.transform.position);
            //    Debug.Log(other.transform.position);
            //    yield return new WaitForSeconds(0.1f);
            //}

            yield return new WaitForSeconds(3f);
        }
    }

    public bool getIsTarget() { return isTarget; }
    public void setIsTarget(bool _isTarget) { isTarget = _isTarget; }
}
