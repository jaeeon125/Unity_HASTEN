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
                Dead();
        }
    }
    
    public virtual void Dead()
    {
        StartCoroutine(die());
    }

    IEnumerator die()
    {
        gainItem();
        this.ALIVE = false;
        this.GetComponent<Animator>().SetTrigger("Die");
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }

    void gainItem()
    {
        int _gold = (int)Random.Range(8, 12);
        int _wood = (int)Random.Range(1, 3);
        GameMgr.getInst().I_Mgr.gainGold(_gold);
        GameMgr.getInst().I_Mgr.gainWood(_wood);
    }
}
