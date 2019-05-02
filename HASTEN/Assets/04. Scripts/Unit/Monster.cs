using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : CUnit
{ 
    public enum State
    {
        Idle, Attack, Trace, Hit
    }

    private Animator Anim;
    public State state;
    private NavMeshAgent nav;
    public Transform target;

    public bool isAttacked;
    private float AttackDist = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Anim = this.GetComponent<Animator>();
        this.nav = this.GetComponent<NavMeshAgent>();
        this.state = State.Idle;
        this.StatusInit(80, 0, 3, 0, 5);

        this.nav.isStopped = true;
        StartCoroutine(IdleAction());
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public IEnumerator IdleAction()    //기본 상태 // 랜덤 이동
    {
        this.Anim.SetBool("IsWalk", false);
        while (this.ALIVE)
        {
            if (this.nav.isStopped && !isAttacked)
            {
                this.Anim.SetBool("IsWalk", true);
                this.nav.isStopped = false;
                this.nav.SetDestination(RandomDirection());
                yield return new WaitForSeconds(Random.Range(3, 7));
            }
            else if(!this.nav.isStopped && !isAttacked)
            {
                this.Anim.SetBool("IsWalk", false);
                this.nav.isStopped = true;
                yield return new WaitForSeconds(2.0f);
            }
            else
            {
                break;
            }
        }
        this.Anim.SetBool("IsWalk", true);
        yield return null;
    }

    public IEnumerator AttackAction()
    {
        this.state = State.Trace;
        while (this.target) //타겟이 null이 아닐 때
        {
            switch (this.state)
            {
                case State.Attack:
                    this.transform.LookAt(target);
                    this.Anim.SetTrigger("Attack");
                    //타겟 hp 
                    this.state = State.Trace;
                    break;
                case State.Trace:
                    float dist = Vector3.Distance(this.transform.position, target.position);
                    if (dist <= AttackDist)
                    {
                        this.nav.isStopped = true;
                        this.state = State.Attack;
                        yield return new WaitForSeconds(2.0f);
                    }
                    else if(dist > AttackDist && dist < 25.0f)
                    {
                        this.nav.isStopped = false;
                        this.nav.SetDestination(target.position);
                        this.Anim.SetTrigger("Walk");
                        yield return new WaitForSeconds(1.0f);
                    }
                    else //추적 끝
                    {
                        target = null;
                    }
                    break;
                //case State.Hit:
                //    Debug.Log("Hit");
                //    this.nav.isStopped = true;
                //    this.Anim.SetTrigger("Hit");
                //    yield return new WaitForSeconds(0.5f);
                //    this.state = State.Trace;
                //    break;
                default:
                    break;
            }
            // trace 범위 벗어나거나 플레이어가 죽을 경우 target = null 로 바꿔서
            // while문 빠져나가고 다시 idleaction 호출
            yield return null;
        }
        this.nav.isStopped = true;
        this.Anim.SetTrigger("Idle");
        this.isAttacked = false;
        StartCoroutine(IdleAction());
        yield return null;
    }
    public Vector3 RandomDirection()
    {
        Vector3 dir = new Vector3(this.transform.position.x + Random.Range(-30, 30), this.transform.position.y
            , this.transform.position.z + Random.Range(-30, 30));
        return dir;
    }

    public override void Dead()
    {
        base.Dead();
        Debug.Log("죽음");
    }
}
