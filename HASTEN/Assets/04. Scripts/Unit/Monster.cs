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

    public Animator Anim;
    public State state;
    private NavMeshAgent nav;

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

    public override IEnumerator IdleAction()    //기본 상태 // 랜덤 이동
    {
        while (this.ALIVE)
        {
            this.Anim.SetBool("IsWalk", false);
            if (this.nav.isStopped && !isAttacked)
            {
                this.Anim.SetBool("IsWalk", true);
                this.nav.isStopped = false;
                this.nav.SetDestination(this.RandomDirection());
                yield return new WaitForSeconds(Random.Range(3, 7));
            }
            else if(!this.nav.isStopped && !isAttacked)
            {
                this.Anim.SetBool("IsWalk", false);
                this.nav.isStopped = true;
                yield return new WaitForSeconds(2.0f);
            }
            else
                break;
        }
        this.Anim.SetBool("IsWalk", true);
        yield return null;
    }

    public override IEnumerator AttackAction()
    {
        this.state = State.Trace;
        while (this.target && this.ALIVE) //타겟이 null이 아닐 때
        {
            switch (this.state)
            {
                case State.Attack:
                    this.transform.LookAt(target);
                    this.Anim.SetTrigger("Attack");
                    yield return new WaitForSeconds(0.9f);
                    this.state = State.Trace;
                    break;
                case State.Trace:
                    float dist = Vector3.Distance(this.transform.position, target.position);
                    if (dist <= AttackDist)
                    {
                        this.nav.isStopped = true;
                        this.state = State.Attack;
                        yield return null;
                    }
                    else if(dist > AttackDist && dist < 25.0f)
                    {
                        this.nav.isStopped = false;
                        this.nav.SetDestination(target.position);
                        this.Anim.SetTrigger("Walk");
                        yield return new WaitForSeconds(1.0f);
                    }
                    else //추적 끝
                        target = null;
                    break;
            }
            yield return null;
        }
        this.nav.isStopped = true;
        this.Anim.SetTrigger("Idle");
        this.isAttacked = false;
        StartCoroutine(IdleAction());
        yield return null;
    }

    public override IEnumerator die()
    {
        this.ALIVE = false;
        this.Anim.SetBool("IsWalk", false);
        gainItem();
        this.GetComponent<Animator>().SetTrigger("Die");
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.state == State.Attack && other.tag == "Player")
        {
            float hpgage = (float)GameMgr.getInst().P_State.HP / (float)GameMgr.getInst().P_State.MAXHP;
            GameMgr.getInst().P_State.getDamage(this.POWER);
            GameMgr.getInst().PlayerSlider.GetComponent<PlayerHPBar>().Slider(hpgage);
        }
    }

    public override void gainItem()
    {
        int _gold = (int)Random.Range(8, 12);
        int _wood = (int)Random.Range(1, 3);
        GameMgr.getInst().I_Mgr.gainGold(_gold);
        GameMgr.getInst().I_Mgr.gainWood(_wood);
    }
}
