using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : CUnit
{ 
    public enum State
    {
        Idle, Attack, Trace
    }

    private Animation Anim;
    private State state;
    private NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        this.nav = this.GetComponent<NavMeshAgent>();
        this.state = State.Idle;
        this.StatusInit(100, 0, 10, 0, 10);
        
        StartCoroutine(Action());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Action()
    {
        while (this.ALIVE)
        {
            switch (this.state)
            {
                case State.Idle:
                    float time = Random.Range(3, 7);
                    if (this.nav.isStopped)
                    {
                        this.nav.isStopped = false;
                        this.nav.SetDestination(RandomDirection());
                        yield return new WaitForSeconds(time);
                    }
                    else
                    {
                        this.nav.isStopped = true;
                        yield return new WaitForSeconds(2.0f);
                    }
                    break;
                case State.Attack:
                    break;
                case State.Trace:
                    break;
                default:
                    break;
            }
        }
    }
    public Vector3 RandomDirection()
    {
        Vector3 dir = new Vector3(this.transform.position.x + Random.Range(-30, 30), this.transform.position.y
            , this.transform.position.z + Random.Range(-30, 30));
        return dir;
    }

}
