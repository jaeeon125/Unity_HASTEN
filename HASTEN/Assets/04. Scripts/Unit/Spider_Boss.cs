using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider_Boss : CUnit
{
    public enum State
    {
        attack1, attack2, attack3, die, idle, run, walk, Attack
    }
    List<string> animArr;
    private Animation Anim;
    private State state;
    private NavMeshAgent nav;
    private float AttackDist = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Anim = this.GetComponent<Animation>();
        nav = this.GetComponent<NavMeshAgent>();
        animArr = new List<string>();
        AnimationArray();
        this.state = State.idle;
        this.StatusInit(15, 0, 2, 1, 10);
        StartCoroutine(IdleAction());
    }

    void AnimationArray()
    {
        foreach(AnimationState state in Anim)
            animArr.Add(state.name);
    }

    public override IEnumerator die()
    {
        gainItem();
        this.Anim.Play(animArr[(int)State.die]);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

    public override IEnumerator IdleAction()    //기본 상태 // 랜덤 이동
    {
        while (this.ALIVE)
        {
            if (this.nav.isStopped && !isAttacked)
            {
                this.Anim.Play(animArr[(int)State.walk]);
                this.nav.isStopped = false;
                this.nav.SetDestination(this.RandomDirection());
                yield return new WaitForSeconds(Random.Range(3, 7));
            }
            else if (!this.nav.isStopped && !isAttacked)
            {
                this.Anim.Play(animArr[(int)State.idle]);
                this.nav.isStopped = true;
                yield return new WaitForSeconds(2.0f);
            }
            else
                break;
        }
        yield return null;
    }

    public override IEnumerator AttackAction()
    {
        this.state = State.run;
        while (this.target && this.ALIVE) //타겟이 null이 아닐 때
        {
            switch (this.state)
            {
                case State.Attack:
                    this.transform.LookAt(target);
                    int attackMode = Random.Range(0, 3);
                    this.Anim.Play(animArr[attackMode]);

                    float hpgage = (float)GameMgr.getInst().P_State.HP / (float)GameMgr.getInst().P_State.MAXHP;
                    GameMgr.getInst().P_State.getDamage(this.POWER);
                    GameMgr.getInst().PlayerSlider.GetComponent<PlayerHPBar>().Slider(hpgage);

                    this.state = State.run;
                    break;
                case State.run:
                    float dist = Vector3.Distance(this.transform.position, target.position);
                    if (dist <= AttackDist)
                    {
                        this.nav.isStopped = true;
                        this.state = State.Attack;
                        yield return new WaitForSeconds(2.0f);
                    }
                    else if (dist > AttackDist && dist < 25.0f)
                    {
                        this.nav.isStopped = false;
                        this.nav.SetDestination(target.position);
                        this.Anim.Play(animArr[(int)State.run]);
                        yield return new WaitForSeconds(1.0f);
                    }
                    else //추적 끝
                        target = null;
                    break;
            }
            yield return null;
        }
        this.nav.isStopped = true;
        this.Anim.Play(animArr[(int)State.idle]);
        this.isAttacked = false;
        StartCoroutine(IdleAction());
        yield return null;
    }

    public override void gainItem()
    {
        int _gold = (int)Random.Range(20, 30);
        int _wood = (int)Random.Range(5, 7);
        GameMgr.getInst().I_Mgr.gainGold(_gold);
        GameMgr.getInst().I_Mgr.gainWood(_wood);
        GameMgr.getInst().inven.gainItem("Spider Web", 1);
    }
}
