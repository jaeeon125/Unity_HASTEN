using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    private GameObject []towers;
    private GameObject enemy;
    private float dist;

    private bool isAttacked; //플레이어한테 공격받고 있는지
    private bool isDestroy; //공격중인 건물을 파괴 했는지

    private NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        findEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        move();
            

    }

    void findEnemy()
    {
        //System.Array.Clear(towers, 0, towers.Length);
        towers = GameObject.FindGameObjectsWithTag("Tower");
        for(int i=0;i<towers.Length;i++)
            if (dist < Mathf.Abs(Vector3.Distance(towers[i].transform.position, this.transform.position)))
            {
                dist = Mathf.Abs(Vector3.Distance(towers[i].transform.position, this.transform.position));
                enemy = towers[i];
            }
    }

    void move()
    {
        nav.SetDestination(enemy.transform.position);
        nav.isStopped = false;
        nav.speed = 5f;
        if (nav.remainingDistance <= 10f)
        {
            nav.isStopped = true;
            Debug.Log("Stop");
        }
            
    }
}
