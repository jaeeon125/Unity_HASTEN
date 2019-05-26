using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCtrl : MonoBehaviour
{
    public enum State {
        Idle, Run, Attack, InPotal
    }
    public Transform parentTrans;   //어택 후 부모 객체의 각도 변경을 위해

    private Animator Anim;
    private PlayerState p_State;        //Player의 능력치 등
    private State e_State;      //Animation -> 상태 설정
    private bool AttackEnd = false;
    private bool AttackMotion = false;  //어택 모션이 곂치는 경우가 있어서 예외 처리
    private Vector3 EndAngles = Vector3.zero;
    //
    public Potal potal = null;
    //

    private BoxCollider axe;

    public void setState(State state)
    {
        this.e_State = state;
        this.setAction();   //상태 변경시 Animation변경
    }
    public State getState()
    {
        return e_State;
    }

    private void Start()
    {
        p_State = this.GetComponentInParent<PlayerState>();
        Anim = this.GetComponent<Animator>();
        setState(State.Idle);   //시작 시 Idle 상태로 설정

        axe = GetComponentInChildren<BoxCollider>();
        axe.enabled = false;

    }
    private void Update()   
    {
        if (Input.GetKeyDown(KeyCode.Space))    // 테스트용 나중에 어플로 만들때는 지워야함
            OnAttack();
    }

    public void setAction() //Animation 변경
    {
        switch (this.e_State)
        {
            case State.Idle:
                this.Anim.SetBool("IsRun", false);
                break;
            case State.Run:
                this.Anim.SetBool("IsRun", true);
                break;
            case State.Attack:
                if (!AttackMotion) //모션이 겹치는 경우가 있어서 예외 처리
                {
                    AttackMotion = true;
                    this.Anim.SetTrigger("Attack01");   //첫 공격 모션 설정
                    StartCoroutine(ComboAttack());
                }
                break;
            case State.InPotal:
                StartCoroutine(OnPotal());
                break;
            default:
                break;
        }
    }
    IEnumerator OnPotal()
    {
        GameMgr.getInst().ControllCanvas.SetActive(false);
        this.Anim.SetTrigger("InPotal");    
        //조이스틱 등 버튼들 조작 불가 상태 추가
        yield return new WaitForSeconds(1.0f);
        this.Anim.SetTrigger("IsIdle"); //공격 후 다시 Idle 상태로 설정
        this.e_State = State.Idle;
        GameMgr.getInst().ControllCanvas.SetActive(true);
    }
    IEnumerator ComboAttack()
    {
        int AttackCnt = 1;
        while (true)
        {
            AttackEnd = true;
            yield return new WaitForSeconds(1.2f);
            AttackCnt += 1;
            if (!AttackEnd && AttackCnt != 4)//AttackEnd가 거짓으로 변했다면 1.5초 안에 버튼을 다시 클릭했다는 것
                this.Anim.SetTrigger("Attack0" + AttackCnt.ToString());
            else
                break;
        }
        AttackMotion = false;
        this.Anim.SetTrigger("IsIdle"); //공격 후 다시 Idle 상태로 설정
        axe.enabled = false;
        if (GameMgr.getInst().Joystick.MoveFlag)
            this.setState(State.Run);
        else
            this.setState(State.Idle);
        yield return null;
        parentTrans.eulerAngles = EndAngles; //EndAttack으로 설정한 각도 적용
    }
    public void EndAttack(Vector3 angles) //어택이 끝날 시 플레이어가 보는 각도 재설정
    {
        EndAngles = angles;
    }
    public void OnAttack()  //Attack_Btn 클릭 시
    {
        axe.enabled = true;
        AttackEnd = false;
        if(this.e_State != State.Attack)    //이미 어택이 실행 중일 때는 다시 코루틴을 호출 하지 않기 위해
            this.setState(State.Attack);
    }
    public void OnJump()
    {
        if (potal)
        {
            potal.Active();
            this.setState(State.InPotal);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (!other.GetComponent<CUnit>().isAttacked)
            {
                other.GetComponent<CUnit>().isAttacked = true;
                other.GetComponent<CUnit>().target = this.transform;
                other.GetComponent<CUnit>().StartCoroutine(other.GetComponent<CUnit>().AttackAction());
                other.GetComponent<CUnit>().gameObject.transform.LookAt(this.transform.position);
            }
            other.GetComponent<CUnit>().getDamage(p_State.POWER);
            if (!GameMgr.getInst().IsHPBarActive)
            {
                GameMgr.getInst().HPBar.gameObject.SetActive(true);
                GameMgr.getInst().IsHPBarActive = true;
            }
            float Hpgage = (float)other.GetComponent<CUnit>().HP / (float)other.GetComponent<CUnit>().MAXHP;
            GameMgr.getInst().HPBar.GetComponent<HPBar>().Slider(Hpgage);
        }
    }
}
