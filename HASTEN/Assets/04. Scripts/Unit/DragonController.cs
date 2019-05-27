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

    public GameObject tower;
    public GameObject HASTEN;

    // Start is called before the first frame update
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
        this.state = State.Run;
        StartCoroutine(AttackAction());
    }

    public override IEnumerator AttackAction()
    {
        while(this.ALIVE)
        {
            this.anim.SetBool("isRun", false);
            switch (this.state)
            {
                case State.Run:
                    int ran = -1;
                    this.anim.SetBool("isRun", true);
                    this.nav.isStopped = false;
                    int towerCnt = tower.transform.childCount;
                    if (towerCnt > 0)
                    {
                        ran = Random.Range(0, towerCnt);
                        this.nav.SetDestination(tower.transform.GetChild(ran).transform.position);
                    }
                    else
                        this.nav.SetDestination(HASTEN.transform.position);
                    while (this.nav.remainingDistance > AttackDist)
                    {
                        
                        //yield return new WaitForSeconds(1f);
                        Debug.Log(this.nav.remainingDistance + " " + this.target);
                    }
                    this.nav.isStopped = true;
                    if (this.nav.remainingDistance <= AttackDist && !this.isAttacked && ran != -1)
                        this.target = tower.transform.GetChild(ran).transform;
                    else if (this.nav.remainingDistance <= AttackDist && ran == 0)
                        this.target = HASTEN.transform;
                    Debug.Log("A");
                    this.state = State.Attack;
                    yield return null;
                    break;
                case State.Attack:
                    this.transform.LookAt(target);
                    this.anim.SetTrigger("Attack");

                    float hpgage = (float)GameMgr.getInst().P_State.HP / (float)GameMgr.getInst().P_State.MAXHP;
                    GameMgr.getInst().P_State.getDamage(this.POWER);
                    GameMgr.getInst().PlayerSlider.GetComponent<PlayerHPBar>().Slider(hpgage);
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
        Destroy(this);
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
