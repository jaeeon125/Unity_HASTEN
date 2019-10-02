using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMgr : MonoBehaviour
{
    public ArrayList CommonBuildings = new ArrayList();
    void Start()//건물 건설 시 띄울 건물 리스트들을 위해 건물들을 초기화 해놓는다.
    {
        //CommonBuildings.Add(new CBuilding("포탈", 9999999, 0));       //0번째 건물 - 포탈
    }

}
