using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilding
{
    string NAME { get; set; }
    int HP { get; set; }
    int COST { get; set; }
}
public class CBuilding : IBuilding  //건물 리스트들 초기화에 사용
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
    private int _COST;
    public int COST
    {
        get { return _COST; }
        set { _COST = value; }
    }
   public CBuilding(string name, int hp, int cost)
    {
        this.NAME = name;
        this.HP = hp;
        this.COST = cost;
    }
}

