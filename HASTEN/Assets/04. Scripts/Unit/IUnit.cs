using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    int HP { get; set; }
    int MP { get; set; }
    int ARMOR { get; set; }
    int SPEED { get; set; }
    int POWER { get; set; }
    bool ALIVE { get; set; }

    void getDamage(int damage);
}
public class CUnit : IUnit
{
    public int HP { get { return HP; } set { HP = value; } }
    public int MP { get { return MP; } set { MP = value; } }
    public int ARMOR { get { return ARMOR; } set { ARMOR = value; } }
    public int SPEED { get { return SPEED; } set { SPEED = value; } }
    public int POWER { get { return POWER; } set { POWER = value; } }
    public bool ALIVE { get { return ALIVE; } set { ALIVE = value; } }

    public CUnit(int hp, int mp, int armor, int speed, int power)
    {
        HP = hp;
        MP = mp;
        ARMOR = armor;
        SPEED = speed;
        POWER = power;
        ALIVE = true;
    }

    public void getDamage(int damage)
    {
        damage -= this.ARMOR;
        if (damage < 0)
            this.HP -= 1;
        else
            this.HP -= damage;
    }
}
