using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonController : CUnit
{
    private enum State { Idle, Run, Attack, Die }
    private State state;
    private Animation appeareance;
    private Animator anim;
    private NavMeshAgent nav;
    private float AttackDist = 5f;

    // 현재 랜덤 타워 공격 후 HASTEN 공격으로 설정 -> HASTEN으로 공격 중 타워가 범위 안에 있으면 공격으로 수정해야함, 접근 지정자 수정
    void Start()
    {
        appeareance = GetComponent<Animation>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        this.nav.isStopped = true;
        appeareance.Play();
        state = State.Idle;
        this.StatusInit(100 + (int)(100 * (float)(GameMgr.getInst().Stage / 10)), 0, 3 + (int)(3 * (float)(GameMgr.getInst().Stage / 10)), 0, 5 + (int)(5 * (float)(GameMgr.getInst().Stage / 10)));
        StartCoroutine(appear());
    }

    private IEnumerator appear()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.GetComponent<Animation>());
        this.target = GameMgr.getInst().HASTEN.transform;
        this.state = State.Run;
        StartCoroutine(AttackAction());
    }

    public override IEnumerator AttackAction()
    {
        while(this.ALIVE)
        {
            switch (this.state)
            {
                case State.Run:
                    float dist = Vector3.Distance(this.transform.position, this.target.transform.position);

                    if (dist <= AttackDist)
                    {
                        this.nav.isStopped = true;
                        this.state = State.Attack;
                    }
                    else
                    {
                        this.anim.SetTrigger("Run");
                        this.nav.isStopped = false;
                        this.nav.SetDestination(target.transform.position);
                    }
                    yield return null;
                    break;
                case State.Attack:
                    this.transform.LookAt(target);
                    this.anim.SetTrigger("Attack");

                    if (this.target.tag == "Player")
                    {
                        float hpgage = (float)GameMgr.getInst().P_State.HP / (float)GameMgr.getInst().P_State.MAXHP;
                        GameMgr.getInst().P_State.getDamage(this.POWER);
                        GameMgr.getInst().PlayerSlider.GetComponent<PlayerHPBar>().Slider(hpgage);
                    }
                    else if (this.target.tag == "Tower")
                    {
                        //float hpgage = (float)this.target.getcomponent<Tower>().HP / (float)this.target.getcomponent<Tower>().MAXHP;
                        //this.target.getcomponent<Tower>().getdamage(this.power);
                    }
                    else
                    {
                        float hpgage = (float)this.target.GetComponent<HASTEN>().HP / (float)this.target.GetComponent<HASTEN>().MAXHP;
                        this.target.GetComponent<HASTEN>().getDamage(this.POWER);
                    }
                    yield return new WaitForSeconds(1.3f);
                    this.state = State.Run;
                    break;
            }
        }
    }

    public override IEnumerator die()
    {
        gainItem();
        this.ALIVE = false;
        this.anim.SetTrigger("Die");
        yield return new WaitForSeconds(1.3f);
        Destroy(this.gameObject);
    }

    public override void gainItem()
    {
        int _gold = (int)Random.Range(8, 12);
        int _wood = (int)Random.Range(1, 3);
        GameMgr.getInst().I_Mgr.gainGold(_gold);
        GameMgr.getInst().I_Mgr.gainWood(_wood);
        GameMgr.getInst().inven.gainItem("Red Crystal", Random.Range(0, 2));
        GameMgr.getInst().inven.gainItem("Blue Crystal", Random.Range(0, 2));
        GameMgr.getInst().inven.gainItem("Yellow Crystal", Random.Range(0, 2));
    }
}
