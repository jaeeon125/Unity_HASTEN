using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilding
{
    string NAME { get; set; }
    int HP { get; set; }
    int GOLD { get; set; }
    int WOOD { get; set; }
}
public class CBuilding : MonoBehaviour, IBuilding  //건물 리스트들 초기화에 사용
{
    private string _NAME;
    public string NAME
    {
        get { return _NAME; }
        set { _NAME = value; }
    }
    private int _HP;
    public int HP
    {
        get { return _HP; }
        set { _HP = value; }
    }
    private int _GOLD;
    public int GOLD
    {
        get { return _GOLD; }
        set { _GOLD = value; }
    }
    private int _WOOD;
    public int WOOD
    {
        get { return _WOOD; }
        set { _WOOD = value; }
    }
   public void BuildingInit(string name, int hp, int gold, int wood)
    {
        this.NAME = name;
        this.HP = hp;
        this.GOLD = gold;
        this.WOOD = wood;
    }
    public void getDamage(int power)
    {
        this.HP -= power;
        if (this.HP <= 0)
            Destroy(this);
    }
}

