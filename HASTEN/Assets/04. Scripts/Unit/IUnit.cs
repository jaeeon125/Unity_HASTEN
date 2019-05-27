using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public interface IUnit
{
    int HP { get; set; }
    int MP { get; set; }
    int ARMOR { get; set; }
    float SPEED { get; set; }
    int POWER { get; set; }
    bool ALIVE { get; set; }
    int MAXHP { get; set; }
    bool isAttacked { get; set; }
    Transform target { get; set; }

    void getDamage(int damage);
}
public class CUnit : MonoBehaviour, IUnit
{
    private int _HP;
    public int HP { get { return _HP; } set { _HP = value; } }
    private int _MP;
    public int MP { get { return _MP; } set { _MP = value; } }
    private int _ARMOR;
    public int ARMOR { get { return _ARMOR; } set { _ARMOR = value; } }
    private float _SPEED;
    public float SPEED { get { return _SPEED; } set { _SPEED = value; } }
    private int _POWER;
    public int POWER { get { return _POWER; } set { _POWER = value; } }
    private bool _ALIVE;
    public bool ALIVE { get { return _ALIVE; } set { _ALIVE = value; } }
    private int _MAXHP;
    public int MAXHP { get { return _MAXHP; } set { _MAXHP = value; } }
    private bool _isAttacked;
    public bool isAttacked { get { return _isAttacked; } set { _isAttacked = value; } }
    private Transform _target;
    public Transform target { get { return _target; } set { _target = value; } }

    public Transform Can;
    
    public void StatusInit(int hp, int mp, int armor, float speed, int power)
    {
        HP = hp;
        MP = mp;
        ARMOR = armor;
        SPEED = speed;
        POWER = power;
        ALIVE = true;
        MAXHP = hp;
    }

    public void getDamage(int power)
    {
        if (ALIVE)
        {
            int damage = (int)(power * Random.Range(0.8f, 1.2f)) - this.ARMOR;
            hitUI hitAn = GetComponent<hitUI>();
            damage = damage <= 0 ? 1 : damage;
            StartCoroutine(hitAn.hit(damage));
            this.HP -= damage;
            this.HP = this.HP < 0 ? 0 : this.HP;
            //사망
            if (this.HP == 0)
            {
                StopAllCoroutines();
                StartCoroutine(die());
            }
                
        }
    }

    public Vector3 RandomDirection()
    {
        Vector3 dir = new Vector3(this.transform.position.x + Random.Range(-30, 30), this.transform.position.y
            , this.transform.position.z + Random.Range(-30, 30));
        return dir;
    }

    public virtual void gainItem() { }
    public virtual Vector3 RandomDirection(Vector3 dir) { return new Vector3(0, 0, 0); }
    public virtual IEnumerator die() { yield return null; }
    public virtual IEnumerator IdleAction() { yield return null; }
    public virtual IEnumerator AttackAction() { yield return null; }
}
