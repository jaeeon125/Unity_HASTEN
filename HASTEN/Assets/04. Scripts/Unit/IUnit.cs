using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    int HP { get; set; }
    int MP { get; set; }
    int ARMOR { get; set; }
    float SPEED { get; set; }
    int POWER { get; set; }
    bool ALIVE { get; set; }

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

    public void StatusInit(int hp, int mp, int armor, float speed, int power)
    {
        HP = hp;
        MP = mp;
        ARMOR = armor;
        SPEED = speed;
        POWER = power;
        ALIVE = true;
    }

    public void getDamage(int power)
    {
        int damage = (int)(power * Random.Range(0.8f, 1.2f)) - this.ARMOR;

        if (damage <= 0)
            damage = 1;
        this.HP -= damage;
        this.HP = this.HP < 0 ? 0 : this.HP;
        //Text
        Debug.Log(damage + ", " + HP);
        //사망
        if (this.HP == 0)
            Dead();
    }

    public virtual void Dead()
    {
        this.ALIVE = false;
    }
}
