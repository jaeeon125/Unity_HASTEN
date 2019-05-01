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

    private Animator Anim;
    private State state;
    private NavMeshAgent nav;
    public bool isAttacked;
    private float attackRange = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Anim = this.GetComponent<Animator>();

        this.nav = this.GetComponent<NavMeshAgent>();
        this.state = State.Idle;
        this.StatusInit(100, 0, 10, 0, 10);
        
        StartCoroutine(Action());
    }

    // Update is called once per frame
    void Update()
    {
        if (this.nav.remainingDistance <= 0.8f || this.nav.isStopped)
            this.Anim.SetBool("IsRun", false);
    }

    IEnumerator Action()
    {
        while (this.ALIVE)
        {
            if (isAttacked)
                this.state = State.Attack;
            
            switch (this.state)
            {
                case State.Idle:
                    float time = Random.Range(3, 7);
                    if (this.nav.isStopped)
                    {
                        this.nav.isStopped = false;
                        this.Anim.SetBool("IsRun", true);
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
                    this.nav.isStopped = false;
                    this.nav.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
                    this.Anim.SetBool("IsWalk", true);
                    while(this.ALIVE || GameObject.FindGameObjectWithTag("Player"))
                        if (this.nav.remainingDistance < attackRange)
                        {
                            this.nav.isStopped = true;
                            this.transform.LookAt(GameObject.FindWithTag("Player").transform);
                            this.Anim.SetTrigger("Attack");
                        }
                        
                    break;
                case State.Trace:
                    break;
                default:
                    break;
            }
            yield return null;
        }
    }
    public Vector3 RandomDirection()
    {
        Vector3 dir = new Vector3(this.transform.position.x + Random.Range(-30, 30), this.transform.position.y
            , this.transform.position.z + Random.Range(-30, 30));
        return dir;
    }
}
